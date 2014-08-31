using UnityEngine;
using System.Collections;


/// Attract enemies in layer 8.
/// Assumes it is attached to the player.
/// NOTE: If you want the creatures to be in the detection of Attract Creatures, they must be in layer 8!
public class AttractCreatures : MonoBehaviour {

	public float attractMethodFireTime = 1.0F;
	public float attractionRange = 20.0f;	// This should change with your level

	Collider[] creaturesInProximity;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("MakeANoise", 5.0f, attractMethodFireTime);
	
	}

	void OnDrawGizmos()
	{
		// Draw a sphere to indicate the noise range
		Gizmos.DrawWireSphere(this.transform.position, attractionRange);
	}


	void MakeANoise() {
		//Debug.Log("Fire the attractor!");
		// 8 is the creature layer
		creaturesInProximity = Physics.OverlapSphere(this.transform.position, attractionRange, 1 << 8);

		//if (creaturesInProximity.Length > 0)
		//	Debug.Log("Found " + creaturesInProximity.Length + " creatures");

		int i = 0;
		while (i < creaturesInProximity.Length) {
			// If the creature is aggresive
			//if (creaturesInProximity[i].gameObject.GetComponent<Disposition>() != null) {
				//if ((creaturesInProximity[i].gameObject.GetComponent<Disposition>() as Disposition).stateOfCreature == 2) {
						//Debug.Log("Creature detected!");
	        	creaturesInProximity[i].SendMessage("TargetPlayer", transform.position);
	        	i++;
	      	}
	      //}
	    //}
	}
}
