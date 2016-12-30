using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	// Public Fields

	public bool IsGameRunning;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Custom method Accessed by Unity component
	public void OnClick()
	{
		print("Start Button Clicked");
		IsGameRunning = true;
	}
}