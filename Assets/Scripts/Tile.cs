using UnityEngine;

public class Tile : MonoBehaviour
{
	// Private fields

	Renderer _renderer;

	// Event Methods

	void Start()
	{
		_renderer = GetComponent<Renderer>();
		_renderer.material.color = Color.black;
	}

	void Update()
	{
		
	}

	void OnMouseDown()
	{
		ChangeColour();
	}

	void OnMouseEnter()
	{
		if (Input.GetMouseButton(0))
		{
			ChangeColour();
		}
	}

	// Private Methods

	void ChangeColour()
	{
		_renderer.material.color = _renderer.material.color == Color.black ? Color.green : Color.black;
	}
}
