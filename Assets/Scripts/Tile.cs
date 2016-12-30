using UnityEngine;

public class Tile : MonoBehaviour
{
	// Public fields

	public bool IsActive;

	// Private fields

	Renderer _renderer;

	// Event Methods

	//Called Once at the start
	void Start()
	{
		_renderer = GetComponent<Renderer>();
		_renderer.material.color = Color.black;
		IsActive = false;
	}

	//Called every few milliseconds
	void Update()
	{

	}

	void OnMouseDown()
	{
		if(!IsGameRunning())
			ChangeState();
	}

	void OnMouseEnter()
	{
		if (Input.GetMouseButton(0) && !IsGameRunning())
			ChangeState();
	}

	// Private Methods

	bool IsGameRunning()
	{
		var startButton = GameObject
			.Find("StartButton") //as its named in Unity
			.GetComponent<StartButton>(); //Script version

		return startButton.IsGameRunning;
	}

	void ChangeState()
	{
		IsActive = !IsActive; //Inverting state for now.
		ChangeColour();
	}

	void ChangeColour()
	{
		_renderer.material.color = IsActive ? Color.green : Color.black;
	}
}
