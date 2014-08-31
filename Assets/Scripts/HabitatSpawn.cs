using UnityEngine;
using System.Collections;

public class HabitatSpawn : MonoBehaviour {

	public GameObject mushrooms;
	public int numberOfMushrooms = 45;
	public GameObject grass1;
	public int numberOfGrass1 = 45;

	public GameObject smallRock;
	public int numberOfSmallRocks = 10;
	public GameObject mediumRock;
	public int numberOfMediumRocks = 7;
	public GameObject largeRock;
	public int numberOfLargeRocks = 2;
	public GameObject tree;
	public int numberOfTrees = 7;
	public GameObject smallestCreature;
	public int numberOfSmallest = 8;
	public GameObject biggestCreature;
	public int numberOfBiggest = 2;
	public GameObject creatureLvl2;
	public int numberOfCreatureLvl2 = 4;
	public GameObject creatureLvl3;
	public int numberOfCreatureLvl3 = 6;
	public GameObject creatureLvl4;
	public int numberOfCreatureLvl4 = 3;

	// Use this for initialization
	void Start () {
		Init ();


	}

	public void Init()
	{
		SpawnRocks();
		SpawnTrees();
		SpawnFluff();
	}

//	public void SpawnCreatures() {
//		SpawnWithinPlane(smallestCreature, numberOfSmallest, GlobalBounds.groundHeight);
//		SpawnWithinPlane(biggestCreature, numberOfBiggest, 0.0f);
//		SpawnWithinPlane(creatureLvl2, numberOfCreatureLvl2, 0.0f);
//		SpawnWithinPlane(creatureLvl3, numberOfCreatureLvl3, 0.0f);
//		SpawnWithinPlane(creatureLvl4, numberOfCreatureLvl4, 0.0f);
//	}

	public void SpawnCreaturesLarge()
	{
		SpawnWithinPlane(creatureLvl2, numberOfCreatureLvl2, 0.0f);
		SpawnWithinPlane(creatureLvl3, numberOfCreatureLvl3, 0.0f);
	}

	public void SpawnCreaturesSmall()
	{
		SpawnWithinPlane(smallestCreature, numberOfSmallest, 0.0f);
	}

	public void SpawnCreaturesGiant()
	{
		
		SpawnWithinPlane(creatureLvl4, numberOfCreatureLvl4, 0.0f);
		SpawnWithinPlane(biggestCreature, numberOfBiggest, 0.0f);
	}

	void SpawnRocks() {
		SpawnWithinPlane(smallRock, numberOfSmallRocks, GlobalBounds.visualHeight);
		SpawnWithinPlane(mediumRock, numberOfMediumRocks, GlobalBounds.groundHeight - 1.5f);
		SpawnWithinPlane(largeRock, numberOfLargeRocks, GlobalBounds.groundHeight - 5);
	}

	void SpawnTrees() {
		SpawnWithinPlane(tree, numberOfTrees, GlobalBounds.groundHeight - 1f);
	}

	void SpawnFluff() {
		SpawnWithinPlane(mushrooms, numberOfMushrooms, GlobalBounds.visualHeight);
		SpawnWithinPlane(grass1, numberOfGrass1, GlobalBounds.visualHeight);

	}

	void SpawnWithinPlane(GameObject objectToSpawn, int numberOfObjects, float spawnHeight) {

		for (int i = 1; i <= numberOfObjects; i++)
		{
//			Debug.Log(GlobalBounds.RandomXBound());
			Vector3 position = new Vector3(GlobalBounds.RandomXBound(), spawnHeight, GlobalBounds.RandomZBound());
			//Debug.Log(position);

			float val = Random.Range(0, 360);

    	Instantiate(objectToSpawn, position, Quaternion.Euler(0,val,0));
		}

	}

}
