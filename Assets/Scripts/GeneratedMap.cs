using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GeneratedMap : MonoBehaviour
{
	// Properties available to Unity IDE

	public Transform TilePrefab;
	public Vector2 MapSize; //Note we are assuming x,y will be int values
	[Range(0, 1)]
	public float OutLinePercent;

	// Private fields

	const string HolderName = "Generated Map";
	const float UpdateInterval = 0.2f; //Seconds //ToDo: potential UI Slider for speed
	private Tile[,] _tiles;

	// Event Methods

	//Called Once at the start
	void Start()
	{
		_tiles = new Tile[(int)MapSize.x, (int)MapSize.y];
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
				var tilePosition = new Vector3(-MapSize.x / 2 + 0.5f + x, -MapSize.y / 2 + 0.5f + y, 0);

				var newTilePrefab = Instantiate(TilePrefab, tilePosition, Quaternion.identity) as Transform;
				newTilePrefab.localScale = Vector3.one * (1 - OutLinePercent);
				newTilePrefab.parent = mapHolder;

				var tile = newTilePrefab.gameObject.GetComponent<Tile>();
				_tiles[x, y] = tile;
			}
		}
	}

	void UpdateGameOfLife()
	{
		
		for (var x = 0; x < MapSize.x; x++)
		{
			for (var y = 0; y < MapSize.y; y++)
			{
				var currentTile = _tiles[x, y];

				var neighbours = GetCurrentTileNeighbours(x, y);
				var activeNeighbourCount = neighbours.Count(p => p.IsActive);

				//Any live cell with fewer than two live neighbours dies (referred to as underpopulation or exposure[1]).
				if (currentTile.IsActive && activeNeighbourCount < 2)
					currentTile.ChangeState();

				//Any live cell with more than three live neighbours dies (referred to as overpopulation or overcrowding).
				if(currentTile.IsActive && activeNeighbourCount > 3)
					currentTile.ChangeState();

				//Any dead cell with exactly three live neighbours will come to life.
				if(!currentTile.IsActive && activeNeighbourCount == 3)
					currentTile.ChangeState();

				//Any live cell with two or three live neighbours lives, unchanged, to the next generation.
			}
		}
	}

	IList<Tile> GetCurrentTileNeighbours(int x, int y)
	{
		var tileNeighbours = new List<Tile>();

		if (y + 1 < MapSize.y)
		{
			if (x - 1 >= 0)
			{
				//Top Left
				tileNeighbours.Add(_tiles[x - 1, y + 1]);
			}

			//Top Centre
			tileNeighbours.Add(_tiles[x, y + 1]);

			if (x + 1 < MapSize.x)
			{
				//Top Right
				tileNeighbours.Add(_tiles[x + 1, y + 1]);
			}
		}

		if (x - 1 >= 0)
		{
			//Centre Left
			tileNeighbours.Add(_tiles[x - 1, y]);
		}

		if (x + 1 < MapSize.x)
		{
			//Centre Right
			tileNeighbours.Add(_tiles[x + 1, y]);
		}

		if (y - 1 >= 0)
		{
			if (x - 1 >= 0)
			{
				//Bottom Left
				tileNeighbours.Add(_tiles[x - 1, y - 1]);
			}

			//Bottom Centre
			tileNeighbours.Add(_tiles[x, y - 1]);

			//Bottom Right
			if (x + 1 < MapSize.x)
			{
				tileNeighbours.Add(_tiles[x + 1, y - 1]);
			}
		}

		return tileNeighbours;
	}
}