using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[ RequireComponent (typeof (Renderer)) ]
public class ColourLevelAssignment : MonoBehaviour {

	public Material greenMat;
	public Material blueMat;
	public Material redMat;

  public int playerLevel = 2;
  GameObject[] creatures;
	GameObject[] goArray;
	List<GameObject> goList;

	// Use this for initialization
	void Start () {
		goList = new List<GameObject>();
		goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		Invoke("AssignNewTags", 30.0f);
		Invoke("AssignNewTags", 10.0f);
		Invoke("AssignNewTags", 15.0f);
		Invoke("AssignNewTags", 5.0f);
		Invoke("AssignNewTags", 20.0f);
	}

	void AssignLevels() {

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
		        	animal.tag = "Edible";
		        	AssignMaterials("Green",animal);
		            //print ("Why hello there good sir! Let me teach you about Trigonometry!");
		            break;
		        case "Lvl3Real":
		        case "Lvl2Real":
		        case "Lvl4Real":
		        case "Lvl5Real":
		        
		        default:
		        animal.tag = "Neutral";
		        AssignMaterials("Blue",animal);
		            break;
	        }
	      }

      	if (playerLevel == 2)
      	{
	      	switch (animal.name)
	        {
	        case "Lvl1Real":
	        	animal.tag = "Edible";
	        	AssignMaterials("Green",animal);
	            //print ("Why hello there good sir! Let me teach you about Trigonometry!");
	            break;
	        case "Lvl3Real":
	            animal.tag = "Aggressive";
	            AssignMaterials("Red",animal);
	            break;
	        case "Lvl4Real":
	        case "Lvl2Real":
	        case "Lvl5Real":
	        default:
	        animal.tag = "Neutral";
	        AssignMaterials("Blue",animal);
	            break;
	        }
	      }

        if (playerLevel == 3)
        {
	      	switch (animal.name)
	        {
		        case "Lvl1Real":
		        case "Lvl2Real":
		        	animal.tag = "Edible";
		        	AssignMaterials("Green",animal);
	            //print ("Why hello there good sir! Let me teach you about Trigonometry!");
	            break;

		        case "Lvl4Real":
	            animal.tag = "Aggressive";
	            AssignMaterials("Red",animal);
	            break;
		        

		        case "Lvl5Real":
		        case "Lvl3Real":
		        default:
		        animal.tag = "Neutral";
		        AssignMaterials("Blue",animal);
		            break;
	        }
	      }

        if (playerLevel == 4)
        {
	      	switch (animal.name)
	        {
		        case "Lvl1Real":
		        case "Lvl2Real":
	          case "Lvl3Real":
		        	animal.tag = "Edible";
		        	AssignMaterials("Green",animal);
		            //print ("Why hello there good sir! Let me teach you about Trigonometry!");
		          break;
						case "Lvl5Real":
	            animal.tag = "Aggressive";
	            AssignMaterials("Red",animal);
	            break;

		        case "Lvl4Real":
		        default:
			        animal.tag = "Neutral";
			        AssignMaterials("Blue",animal);
			            break;
	        }
				}


        if (playerLevel == 5)
        {
	      	switch (animal.name)
	        {
	        case "Lvl1Real":
	        case "Lvl2Real":
          case "Lvl3Real":
	        case "Lvl4Real":
	        	animal.tag = "Edible";
	        	AssignMaterials("Green",animal);
	            //print ("Why hello there good sir! Let me teach you about Trigonometry!");
	            break;

	        case "Lvl5Real":
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
