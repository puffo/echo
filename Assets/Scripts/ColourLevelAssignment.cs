using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[ RequireComponent (typeof (Renderer)) ]
public class ColourLevelAssignment : MonoBehaviour {

	public Material greenMat;
	public Material blueMat;
	public Material redMat;

  public int playerLevel = 1;
  GameObject[] creatures;
	GameObject[] goArray;
	List<GameObject> goList;

	// Use this for initialization
	void Start () {
		goList = new List<GameObject>();
		goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		Invoke("AssignNewTags", 1.0f);
		Invoke("AssignNewTags", 31.0f);
		Invoke("AssignNewTags", 11.0f);
		Invoke("AssignNewTags", 16.0f);
		Invoke("AssignNewTags", 6.0f);
		Invoke("AssignNewTags", 21.0f);
	}

	void AssignLevels() {

	}

	void MakeEdible(GameObject animal) {
		animal.tag = "Edible";
  	AssignMaterials("Green",animal);
	}

	void MakeNeutral(GameObject animal) {
		animal.tag = "Neutral";
  	AssignMaterials("Blue",animal);
	}

	void MakeAggresive(GameObject animal) {
		animal.tag = "Aggressive";
		AssignMaterials("Red",animal);
	}

	public void SavePlayerLevel(int level) {

	}

	public void AssignNewTags() {

		RefreshCreatures();
		Debug.Log("assigning tags to " + creatures.Length + " creatures");

		foreach (GameObject animal in creatures) 
      { 
      	//Debug.Log(animal.name);
				if (playerLevel == 1)
				{
	      	
	      	switch (animal.name)
	        {
		        case "Lvl1Real":
		        	MakeEdible(animal);
	            break;
		        default:
			        MakeNeutral(animal);
	            break;
	        }
	      }

      	if (playerLevel == 2)
      	{
	      	switch (animal.name)
	        {
	          case "Lvl2Real":
	          	MakeEdible(animal);
	          	break;
		        case "Lvl3Real":
	            MakeAggresive(animal);
	            break;
		        default:
			        MakeNeutral(animal);
	            break;
	        }
	      }

        if (playerLevel == 3)
        {
	      	switch (animal.name)
	        {
		        case "Lvl3Real":
		        	MakeEdible(animal);
	            break;

		        case "Lvl4Real":
		        	MakeAggresive(animal);
	            break;
		        
		        default:
			        MakeNeutral(animal);
	            break;
	        }
	      }

        if (playerLevel == 4)
        {
	      	switch (animal.name)
	        {
	          case "Lvl4Real":
	          	MakeEdible(animal);
		          break;

						case "Lvl5Real":
							MakeAggresive(animal);
	            break;

		        default:
		        	MakeNeutral(animal);
	            break;
	        }
				}


        if (playerLevel == 5)
        {
	      	switch (animal.name)
	        {
	        	case "Lvl5Real":
		        	animal.tag = "Edible";
		        	AssignMaterials("Green",animal);
	            break;

		        default:
			        animal.tag = "Neutral";
			        AssignMaterials("Blue",animal);
	            break;
	        }
	      }

        if (playerLevel == 6)
        {
	      	switch (animal.name)
	        {
		        default:
	            animal.tag = "Edible";
		        	AssignMaterials("Green",animal);
	            break;
	        }
	      }
		}
	}

	public void LevelUp() {
		if ( playerLevel < 7)
		{
			playerLevel++;
			AssignNewTags();
		}
	}

	public void LevelDown() {
		if ( playerLevel > 0 )
		{
			playerLevel--;
			AssignNewTags();
		}
	}

	/// Adjust the Material of a single GameObject
	/// Uses either "Green" or "Red" to assign the materials
	void AssignMaterials(string colour, GameObject animal) {
		Renderer[] animalRenderer = animal.GetComponentsInChildren<Renderer>() as Renderer[];
		
		switch (colour)
			{
				case "Green":
					foreach(Renderer i in animalRenderer)
						{
							i.sharedMaterial = greenMat;
							//Debug.Log(i);
							//Debug.Log("Green");
						}					
					break;
				
				case "Red":
					foreach(Renderer i in animalRenderer)
						{
							i.sharedMaterial = redMat;
						}
					break;
				
				default:
					foreach(Renderer i in animalRenderer)
						{
							i.sharedMaterial = blueMat;
						}
					break;
			}
	}

	/// Function to refresh the creatures in memory in the 8th layer
	void RefreshCreatures() {
		goList.Clear();
		goArray =  FindObjectsOfType(typeof(GameObject)) as GameObject[];
		creatures = FindGameObjectsWithLayer(8);
	}

	/// Function to return objects in a layer
	GameObject[] FindGameObjectsWithLayer (int layer) {
		for (int i = 0; i < goArray.Length; i++) {
		   if (goArray[i].layer == layer) {
		     goList.Add(goArray[i]);
		   }
		}

		if (goList.Count == 0) {
		   return null;
		}

		return goList.ToArray();
	}
}
