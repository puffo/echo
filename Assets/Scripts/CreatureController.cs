using UnityEngine;
using System.Collections;

public class CreatureController : MonoBehaviour {

	public GameObject realCreature;
	public AudioSource test;

	public void UpdateVisuals()
	{
//		Debug.Log ("Visuals updated, Cap'n.");

		//visualCreature.transform.position = new Vector3(realCreature.transform.position.x, visualCreature.transform.position.y, realCreature.transform.position.z);
		//visualCreature.transform.rotation = realCreature.transform.rotation;
	//	visualCreature.transform.localScale = realCreature.transform.localScale;
	}

	public void PlayPing()
	{
		test.Play();
	}

	public void ExplodeEm()
	{
		//(visualCreature.gameObject.find("particleExplode").GetComponent<ParticleSystem>()).Play();
		DestroyMyself();
	}

	void DestroyMyself() {
		Destroy(this, 0.0f);
	}

//	void OnTriggerEnter(Collider c)
//	{
//		Debug.Log ("Creature trigger: " + c.gameObject.name);
//	}
}