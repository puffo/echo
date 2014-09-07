using UnityEngine;
using System.Collections;

// This script is a global thing that needs to be attached to the entire play area that will be used
// NB MAKE SURE IT IS the 1st SCRIPT THAT IS RUNNING!
public class GlobalBounds : MonoBehaviour {

  public static Vector3 landscapeBounds;
  public static float groundHeight = 0.2f;
  public static float visualHeight = 0.2f;
  public static float buffer = 50f;

	// Use this for initialization
	void Start () {
		landscapeBounds = renderer.bounds.size;
		landscapeBounds = new Vector3(landscapeBounds.x - buffer, landscapeBounds.y, landscapeBounds.z - buffer);
		Debug.Log(landscapeBounds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static float RandomXBound() {
		return Random.Range(-landscapeBounds.x/2,landscapeBounds.x/2);
	}

	public static float RandomZBound() {
		return Random.Range(-landscapeBounds.z/2,landscapeBounds.z/2);
	}

	public static float PathedX() {
		return Random.Range(-landscapeBounds.x/2,landscapeBounds.x/2);
	}

	public static float PathedZ() {
		return Random.Range(-landscapeBounds.z/2,landscapeBounds.z/2);	
	}



}
