using UnityEngine;
public class GeneratedMap : MonoBehaviour
{
	// Properties available to Unity IDE

	public Transform TilePrefab;
	public Vector2 MapSize;
	[Range(0,1)]
	public float OutLinePercent;

	// Private fields

	const string HolderName = "Generated Map";
	const float UpdateInterval = 1.0f; //Seconds //ToDo: Public Slider for speed

	// Event Methods

	//Called Once at the start
	void Start()
	{
		GenerateMap();
	}

	//Called every frame update.
	void Update()
	{

	}

	// Custom Public Methods

	public void StartGameOfLife()
	{
		InvokeRepeating("UpdateGameOfLife", UpdateInterval, UpdateInterval);
	}

	// Private Methods

	void GenerateMap()
	{
		if (transform.FindChild(HolderName))
			DestroyImmediate(transform.FindChild(HolderName).gameObject);

		//Nests the generated tiles under the Map in Unity Hierarchy
		var mapHolder = new GameObject(HolderName).transform;
		mapHolder.parent = transform;

		for (var x = 0; x < MapSize.x; x++)
		{
			for (var y = 0; y < MapSize.y; y++)
			{
				var tilePosition = new Vector3(-MapSize.x/2 + 0.5f + x, -MapSize.y / 2 + 0.5f + y, 0);
				var newTile = Instantiate(TilePrefab, tilePosition, Quaternion.identity) as Transform;
				newTile.localScale = Vector3.one*(1 - OutLinePercent);
				newTile.parent = mapHolder;
			}
		}
	}

	public void UpdateGameOfLife()
	{
		print("Update Tile Collection");
	}
}