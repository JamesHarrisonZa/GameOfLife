using UnityEngine;

public class Tile : MonoBehaviour
{
	// Public fields

	public bool IsActive;

	// Private fields

	Renderer _renderer;
	StartButton _startButton;

	// Event Methods

	//Called Once at the start
	void Start()
	{
		_renderer = GetComponent<Renderer>();
		_renderer.material.color = Color.black;
		_startButton = GameObject
			.Find("StartButton") //as its named in Unity
			.GetComponent<StartButton>(); //Script version
		IsActive = false;
	}

	//Called every frame update.
	void Update()
	{

	}

	void OnMouseDown()
	{
		if (!IsGameRunning())
			ChangeState();
	}

	void OnMouseEnter()
	{
		if (Input.GetMouseButton(0) && !IsGameRunning())
			ChangeState();
	}

	// Custom Public Methods

	public void ChangeState()
	{
		IsActive = !IsActive; //Inverting state for now.
		ChangeColour();
	}

	// Private Methods

	bool IsGameRunning()
	{
		return _startButton.IsGameRunning;
	}
	
	void ChangeColour()
	{
		_renderer.material.color = IsActive ? Color.green : Color.black;
	}
}
