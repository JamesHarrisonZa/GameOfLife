using UnityEngine;

public class StartButton : MonoBehaviour {

	// Public Fields

	public bool IsGameRunning;

	// Private Fields

	GeneratedMap _generatedMap;

	// Use this for initialization
	void Start () {

		_generatedMap = GameObject.Find("Map").GetComponent<GeneratedMap>();
		IsGameRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Custom method Accessed by Unity component
	public void OnClick()
	{
		if (IsGameRunning)
			return;

		_generatedMap.StartGameOfLife();
		IsGameRunning = true;
	}
}