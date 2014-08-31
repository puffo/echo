using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public HabitatSpawn habitat;
	public float Delay = 3.0f;
	public GameObject Title, Tut01, Tut02, Tut03, Tut04, Tut05, Tut06;
	public PingController Ping1, Ping2;

	public int currentScreen = 0;

	float timer;

	// Use this for initialization
	void Start () {
		Title.SetActive (true);
		timer = Delay;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentScreen > 10)
			return;

		if (Input.GetMouseButtonDown (0) && currentScreen == 0)
			currentScreen = 1;

		if (currentScreen > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				currentScreen++;
				timer = Delay;
			}
		}

		switch (currentScreen) {
		case 1: 
			Title.SetActive(false);
			Tut01.SetActive(true);
			break;
		case 2:
			Tut01.SetActive(false);
			Tut02.SetActive(true);
			habitat.SpawnCreaturesLarge();
			Ping1.StartPing();
			Ping2.StartPing();
			currentScreen++;
			break;
		case 3:
			// Do nothing.
			break;
		case 4:
			Tut02.SetActive(false);
			Tut03.SetActive(true);
			habitat.SpawnCreaturesSmall();
			Ping1.StartPing();
			Ping2.StartPing();
			currentScreen++;
			break;
		case 5:
			// Do nothing.
			break;
		case 6:
			Tut04.SetActive(true);
			Tut03.SetActive(false);
			habitat.SpawnCreaturesGiant();
			Ping1.StartPing();
			Ping2.StartPing();
			currentScreen++;
			break;
		case 7:
			// Do nothing.
			break;
		case 8:
			Tut04.SetActive(false);
			Tut05.SetActive(true);
			break;
		case 9:
			Tut05.SetActive(false);
			Tut06.SetActive(true);
			break;
		case 10:
			Tut06.SetActive(false);
			break;
		}
	}
}
