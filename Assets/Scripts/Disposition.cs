using UnityEngine;
using System.Collections;

	/// <summary>
	/// This will store the creature's neutrality in terms of three integer values.
	/// 0 = edible
	/// 1 = neutral
	/// 2 = aggresive
	/// </summary>


/// This should also adjust the material that is applied to the creature in relation to the player.
public class Disposition : MonoBehaviour {

	public int stateOfCreature = 1;
	bool change = true;

	// Use this for initialization
	void Start () {
		// Set some stuff here
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
