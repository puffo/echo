using UnityEngine;
using System.Collections;

public class PingController : MonoBehaviour 
{

	public float RadiusSpeed = 2.0f;
	public float DecaySpeed = 0.1f;
	public float StartDelay = 0.0f;
	public float StartIntensity = 3.0f;
	public float MaxDistance = 150.0f;

	public bool triggerSound = true;

	public EnergyLevelScale energyBar;
	
	private float timer = 0.0f;
	private SphereCollider col = null;

	void Start()
	{
		if (energyBar == null)
		{
			energyBar = GameObject.Find("Frontbar").GetComponent<EnergyLevelScale>();
		}
		col = GetComponent<SphereCollider>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			StartPing ();
		}

		if (timer > 0.0f) 
		{
			timer -= Time.deltaTime;
		} 
		else
		{
			if (light.range < MaxDistance) 
			{
				light.range = light.range + RadiusSpeed * Time.deltaTime;
				light.intensity = Mathf.Max (0.0f, light.intensity - DecaySpeed * Time.deltaTime);
				col.radius = light.range;
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		// Find the CreatureController and fire the UpdateVisuals script if/when it's found.
		CreatureController creature = LookForCreatureController(c.gameObject);
		if (creature != null) {
			creature.UpdateVisuals ();
			if (triggerSound == true)
				creature.PlayPing();
		}
	}

	void OnDrawGizmos()
	{
		// Draw the expanding sphere so we can see visually which creatures are supposed to be updating.
		if (null != col)
			Gizmos.DrawWireSphere(transform.position + col.center, col.radius);

		Gizmos.DrawWireCube (transform.position, Vector3.one * 2.0f);
	}

	/// <summary>
	/// Traverses the hierarchy to find any CreatureController in the object's parents.
	/// </summary>
	/// <returns>The CreatureController.</returns>
	/// <param name="child">Child.</param>
	CreatureController LookForCreatureController(GameObject child)
	{
		CreatureController result = GetComponent<CreatureController>();
		Transform par = child.transform;
		
		while (par != null) 
		{
			par = par.parent;
			if (par != null)
			{
				result = par.GetComponent<CreatureController>();
				break;
			}
		}

		return result;
	}

	public void StartPing()
	{
		if ( triggerSound && energyBar.TakeEnergy() )
		{
			light.range = 0.0f;
			light.intensity = StartIntensity;
			timer = StartDelay;
		}
	}
}