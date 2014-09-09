using UnityEngine;
using System.Collections;

// This will control the actual size of the player
// as well as the movement and response characteristics


[ RequireComponent (typeof (CharacterController)) ]
//[ RequireComponent (typeof (Camera)) ]
public class GrowthController : MonoBehaviour {

	public ColourLevelAssignment _colourLevelAssignment;
	CharacterController _controller;
	GameObject _hitbox;

	public GameObject growthIndicator;
	public Camera playerCamera;

	public float maxHeight = 50.0f;
	public float heightInterval = 20.0f;
	public float minSize = 2.0f;
	public float FOVDifference = 7.0f;

	public float FOVMin = 40.0f;
	public float FOVMax = 80.0f;

	bool gameOver = false;
	bool canChangeSize = true;
//	Camera _camera;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController>();
		_hitbox = transform.Find("HitBox").gameObject;
		playerCamera.fieldOfView = FOVMax;
		//_camera = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckScreenLock();
	}

	// -------------------- INCOMPLETED
	public void HurtPlayer()
	{
		Debug.Log("Ouch!");
		// Push player back
		// Play an audio cue
		if (_controller.height >= minSize)
		{
			// Shrink player
			Shrink();
		}
		else
		{
			gameOver = true;
			// End the game
		}
		// Reduce level
	}

	// SIZING METHODS
	public void Grow() {

		if (canChangeSize)
		{
			IndicateGrowth();
			
			Vector3 currentPosition = _controller.transform.position;
			
			if (currentPosition.y < maxHeight)
				{
					
					currentPosition.y += heightInterval;
					_controller.transform.position = currentPosition;
					_controller.height += heightInterval;

					_hitbox.transform.localScale += new Vector3(heightInterval/4, heightInterval/2, heightInterval/4);

					_colourLevelAssignment.LevelUp();
				}


			SizeTimeout();
		}
	}

	public void Shrink() {
		if (canChangeSize)
		{
			IndicateShrink();
			Vector3 currentPosition = _controller.transform.position;

			if (currentPosition.y - heightInterval + minSize > 0) {
				_controller.transform.position = currentPosition;
				_controller.height -= heightInterval ;

				_hitbox.transform.localScale -= new Vector3(heightInterval/4, heightInterval/2, heightInterval/4);

				_colourLevelAssignment.LevelDown();

				SizeTimeout();
			}
		}
	}

	void CheckScreenLock() {
		 if (Input.GetKey(KeyCode.Escape) || gameOver)
     	Screen.lockCursor = false;
     else
     	Screen.lockCursor = true;
	}

	void OnGUI () {
		if (gameOver)
		{
			GUI.Box(new Rect(10,10,200,200), "You are the dominant creature of this world...");

			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
				gameOver = false;
				Application.LoadLevel(0);
			}
		}

		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Growth");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		//if(GUI.Button(new Rect(20,40,80,20), "Bigger")) {
		//	Grow();
		//}

		// Make the second button.
		//if(GUI.Button(new Rect(20,70,80,20), "Smaller")) {
		//	Shrink();
		//}
	}

	void SizeTimeout() {
		canChangeSize = false;
		Invoke("ResetTimeout",2);
	}

	void ResetTimeout() {
		canChangeSize = true;
	}

	void IndicateGrowth() {
		Debug.Log("Trying to Grow...");
		growthIndicator.particleSystem.Play();
		AdjustFOVDown();
	}

	void IndicateShrink() {
		Debug.Log("Trying to Shrink...");
		AdjustFOVUp();
	}

	void AdjustFOVUp() {
		Debug.Log(playerCamera.fieldOfView + " CAMERA and "+FOVMax + " MAX");
		if (playerCamera.fieldOfView < FOVMax) {
			playerCamera.fieldOfView += FOVDifference;
		}
		else {
			Debug.Log("Max FOV Reached, cannot increase FOV");
			gameOver = true;
		}
	}

	void AdjustFOVDown() {
		if (playerCamera.fieldOfView > FOVMin) {
			playerCamera.fieldOfView -= FOVDifference;
		}
		else {
			Debug.Log("Min FOV Reached. Did not decrease FOV");
		}
	}

}
