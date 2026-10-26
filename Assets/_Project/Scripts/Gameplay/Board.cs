using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _gemPrefab;


    // board
    [SerializeField] private int _boardColumns = 8;
    [SerializeField] private int _boardRows = 8;
    private GameObject[,] _boardTiles;
    private GameObject[,] _boardGems;

    [SerializeField] private Camera _camera;


    private void Awake()
    {
        _boardTiles = new GameObject[_boardColumns, _boardRows]; //column = x, row = y
        _boardGems = new GameObject[_boardColumns, _boardRows];
    }

    private void Start()
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
                boardTile.name = $"Tile ({column}, {row})";
                _boardTiles[column, row] = boardTile;

                //spawm gem
                GameObject gem = Instantiate(_gemPrefab, tileSpawnPos, Quaternion.identity, transform);
                gem.name = $"Gem ({column}, {row})";
                _boardGems[column, row] = gem;
            }
        }

        Debug.Log($"Spawned {_boardGems[5,2].name} at [5,2]");
        Debug.Log($"Spawned {_boardGems.Length} gems and {_boardTiles.Length} tiles");
    }

    private Vector3 GetTileWorldSpawnPos(Vector2Int spawnCell)
    {
        float tileOffsetX;
        float tileOffsetY;

        tileOffsetX = (_boardColumns - 1) /2f; //board offset x
        tileOffsetY = (_boardRows -1 ) /2f; //board offset y

        Vector3 tileWorldSpawnPos = new Vector3((spawnCell.x - tileOffsetX), (spawnCell.y - tileOffsetY), 0f);

        return tileWorldSpawnPos;   
    }

}
