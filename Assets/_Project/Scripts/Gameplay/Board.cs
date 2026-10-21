using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _gemPrefab;
    [SerializeField] private Vector2Int _spawnCell;

    // board
    [SerializeField] private int _boardColumns = 8;
    [SerializeField] private int _boardRows = 8;
    GameObject[,] _boardTiles;
    GameObject[,] _boardGems;

    void Awake()
    {
        _boardTiles = new GameObject[_boardColumns, _boardRows]; //column = x, row = y
        _boardGems = new GameObject[_boardColumns, _boardRows];
    }

    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int column = 0; column < _boardTiles.GetLength(0); column++)
        {
            for (int row = 0; row <_boardTiles.GetLength(1); row++)
            {
                // spawn tile
                Vector3 tileSpawnPos = GetTileWorldSpawnPos(new Vector2Int(column,row));

                GameObject boardTile = Instantiate(_tilePrefab, tileSpawnPos, Quaternion.identity, transform);
                boardTile.name = $"Tile {column}, {row}";
                _boardTiles[column, row] = boardTile;
                //Debug.Log($"Spawned {boardTile.name} at {column}, {row}");

                //spawm gem
                GameObject gem = Instantiate(_gemPrefab, tileSpawnPos, Quaternion.identity, transform);
                gem.name = $"Gem {column}, {row}";
                _boardGems[column, row] = gem;
                //Debug.Log($"Spawned {gem.name} at {column}, {row}");
            }
        }

        Debug.Log($"Spawned {_boardGems[5,2].name} at [5,2]");
    }

    private Vector3 GetTileWorldSpawnPos(Vector2Int spawnCell)
    {
        Vector3 tileWorldSpawnPos = new Vector3(spawnCell.x, spawnCell.y, 0f);

        return tileWorldSpawnPos;   
    }

}
