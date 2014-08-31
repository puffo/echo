using UnityEngine;
using System.Collections;

public class EnergyLevelScale : MonoBehaviour {

	public Transform theBar;
	
	public float minEnergy = 0.01f;
	public float maxEnergy = 3.38f;

	public float rechargePerSec = 0.004f;
	public float energyCost = 1.0f;

	public float fireDelay = 1f;

	public float energyLevel;
	private float timer = 0;

	private float yScale;
	private float zScale;

	public Material okColour;
	public Material badColour;

	//private Material currentMat;

	// Use this for initialization
	void Start () {
		energyLevel = maxEnergy;
		yScale = theBar.localScale.y;
		zScale = theBar.localScale.z;
		//currentMat = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		RepresentEnergy();
		RechargeEnergy();
		//Debug.Log(energyLevel);
	}

	public bool TakeEnergy() {
		if ((energyLevel - energyCost) < 0)
		{
			//Debug.Log("Not enough energy");
			return false; 
		}
		else 
		{
			energyLevel -= energyCost;
			return true;
		}
	}

	void RechargeEnergy() {
		//Debug.Log(timer);
		if (timer > fireDelay)
		{
			timer = 0;
			if (energyLevel < maxEnergy)
			{
				energyLevel += (rechargePerSec);
			}
		}
		else
		{
			timer += Time.deltaTime;
		}
	}

	void RepresentEnergy() {
		// Adjust the scale of the bar according to the energy level
		Vector3 futureVal = new Vector3(energyLevel,yScale,zScale);

		theBar.localScale = Vector3.Lerp(theBar.localScale, futureVal, 0.2f);
		colourChoice();
	}

	void colourChoice() {
		if ((energyLevel - energyCost) > 0)
		{
			renderer.material = okColour;
		}
		else
		{
			renderer.material = badColour;
		}

	}
}
