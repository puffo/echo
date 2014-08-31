using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

	//GrowthController _growthController;

	// Use this for initialization
	void Start () {
		//_growthController = this.parent.transform.GetComponent<GrowthController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log("Something entered my space.");
		if (other.tag == "Aggressive")
		{
			SendMessageUpwards("HurtPlayer");
		}
		else 
			if (other.tag == "Edible")
			{
				Debug.Log("Eating lil guy.");
				this.SendMessageUpwards("Grow");
				other.SendMessage("Die");

				//_growthController.Grow();
			}
	}
}
