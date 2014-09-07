using UnityEngine;
using System.Collections;

// Big thanks to UnityGems, which has been largely adapted to achieve this behaviour 
// http://unitygems.com/basic-ai-character/

[ RequireComponent (typeof (CharacterController)) ]
[ RequireComponent (typeof (Disposition)) ]
public class MobileCreature : MonoBehaviour {

	CharacterController _controller;
	Disposition _disposition;
	Transform _transform;

	public Animation creatureAnimator;

	float gravity = 20f;
	
	float minTime = 0.1f;
	float velocity;

	public float creatureHeight = 0.1f;
	
	float range;
	bool change; 

	float timeTillBored = 3.0f;
	bool gettingBored = false;

	public int level = 0;

	public float speed = 5f;
	public float changeTime = 5.0f;
	public float randomTimeRange = 2.0f;
	public float maxRotSpeed = 200.0f;

	Vector3 moveDirection;
	Vector3 target;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController>();
		_transform = GetComponent<Transform>();
		_disposition = GetComponent<Disposition>();	

		creatureHeight = _transform.position.y;
		range = 2f;
 		target = GetTarget();
	   	
		// Repeat this every changeTime 
		float timeTopRange = changeTime + randomTimeRange;
		float timeBottomRange = changeTime - randomTimeRange;
	  InvokeRepeating ("NewTarget",0.01f,changeTime + Random.Range(timeBottomRange, timeTopRange ) );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(change) {
    	target = GetTarget();
    }
		
    if (Vector3.Distance(_transform.position,target)>range) {
      	Move();
      	ChangeAnimation("walk");
      	//animation.CrossFade("walk");
      }
    else { 
    	ChangeAnimation("idle");
    	//animation.CrossFade ("idle");
    }
	}

	Vector3 GetTarget()
	{
  		return new Vector3(GlobalBounds.PathedX(),creatureHeight,GlobalBounds.PathedZ());
	}

	void NewTarget()
	{
		int choice = Random.Range (0, 3);
		switch (choice) {
		case 0: 
				change = true;
				break;
		case 1: 
				change = false;
				break;
		case 2:
				target = _transform.position;
				break;
		}
	}

	void Move() 
	{
		moveDirection = _transform.forward;
		moveDirection *= speed;
		moveDirection.y -= gravity;
		_controller.Move(moveDirection * Time.deltaTime);

		var newRotation = Quaternion.LookRotation(target - _transform.position).eulerAngles;
		var angles = _transform.rotation.eulerAngles;
		_transform.rotation = Quaternion.Euler(angles.x, Mathf.SmoothDampAngle(angles.y, newRotation.y, ref velocity, minTime, maxRotSpeed),
        angles.z);
	}

	void TargetPlayer( Vector3 player) {
		if ((_disposition != null) && (_disposition.stateOfCreature == 2)){
			Debug.Log("A " + this.name + " creature is angry with the player!");
			ChangeAnimation("attack");
			target = player;
			gettingBored = true;
			Invoke ("GetBored",timeTillBored);
		}
	}

	void GetBored() {
		gettingBored = false;
		target = GetTarget();
	}

	void ChangeAnimation(string animationName) {
		//Debug.Log(creatureAnimator.animation.Animations);
		//Debug.Log(animationName);
		creatureAnimator.CrossFade(animationName);
	}

	public void Die() {
		Debug.Log("Message received at creature");
		SendMessageUpwards("ExplodeEm");
		// Disable the collision box?

		// Create the particle effect
		//self.parent.Find("particleExplode").Play();


		// Destroy the parent object

	}
}
