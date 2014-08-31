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
	Vector3 verticalOffset;

	void Start() {
		verticalOffset = new Vector3(0.0f,10.0f,0.0f);
	}

	/// Gizmo for creature disposition visually
	void OnDrawGizmos() {
		string myTag = gameObject.tag;

		switch (myTag)
		{
			case "Edible":
				Gizmos.color = Color.green;
				break;

			case "Aggressive":
				Gizmos.color = Color.red;
				break;

			case "Neutral":
				Gizmos.color = Color.blue;
				break;

			default:
				Gizmos.color = Color.grey;
				break;
		}
			
		
		Gizmos.DrawCube(transform.position + verticalOffset, Vector3.one);
	}
}
