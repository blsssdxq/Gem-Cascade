using UnityEngine;

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
    [SerializeField] private float _cameraOffset = 1f;

    //gem colors
    [SerializeField] private Color [] _gemColors;


    private void Awake()
    {
        _boardTiles = new GameObject[_boardColumns, _boardRows]; //column = x, row = y
        _boardGems = new GameObject[_boardColumns, _boardRows];
    }

    private void Start()
    {
        CreateBoard();
        _camera.orthographicSize = CalculateCameraSize();
    }

    private void CreateBoard()
    {
        for (int column = 0; column < _boardTiles.GetLength(0); column++)
        {
            for (int row = 0; row < _boardTiles.GetLength(1); row++)
            {
                // spawn tile
                Vector3 tileSpawnPos = GetTileWorldSpawnPos(new Vector2Int(column, row));

                GameObject boardTile = Instantiate(_tilePrefab, tileSpawnPos, Quaternion.identity, transform);
                boardTile.name = $"Tile ({column}, {row})";
                _boardTiles[column, row] = boardTile;

                //spawn gem
                GameObject gem = SpawnGem(new Vector2Int(column,row));

                _boardGems[column, row] = gem;
            }
        }

        Debug.Log($"Spawned {_boardGems.Length} gems and {_boardTiles.Length} tiles");
    }

    private GameObject SpawnGem(Vector2Int cell)
    {
        Vector3 position = GetTileWorldSpawnPos(cell); 
        GameObject gem = Instantiate(_gemPrefab, position, Quaternion.identity, transform);
        GemType gemType = GetRandomGemType();
        SpriteRenderer gemRenderer = gem.GetComponent<SpriteRenderer>();
        gemRenderer.color =  GetGemColor(gemType);
        gem.name = $"Gem ({cell.x}, {cell.y}) {gemType}";

        return gem;
    }

    private Color GetGemColor(GemType gemType)
    {
        return _gemColors[(int)gemType]; 
    }
    
    private GemType GetRandomGemType()
    {
        int randomGemColor = Random.Range(0, _gemColors.Length);
        
        GemType gemType = (GemType)randomGemColor;
        return gemType;
    }

    private Vector3 GetTileWorldSpawnPos(Vector2Int spawnCell)
    {
        Vector2 offset = GetBoardOffset();

        Vector3 tileWorldSpawnPos = new Vector3((spawnCell.x - offset.x), (spawnCell.y - offset.y), 0f);

        return tileWorldSpawnPos;
    }

    private float CalculateCameraSize()
    {
        float cameraSize;

        float xCameraSize;
        float yCameraSize;

        yCameraSize = _boardRows / 2f + _cameraOffset;
        xCameraSize = (_boardColumns / 2f + _cameraOffset) / _camera.aspect;

        cameraSize = Mathf.Max(xCameraSize, yCameraSize);

        return cameraSize;
    }

    private Vector2Int GetTileBoardPos(Vector3 worldPos)
    {
        Vector2 offset = GetBoardOffset();

        int column = Mathf.RoundToInt(worldPos.x + offset.x);
        int row = Mathf.RoundToInt(worldPos.y + offset.y);

        return new Vector2Int(column, row);
    }

    private Vector2 GetBoardOffset()
    {
        float boardOffsetX = (_boardColumns - 1) / 2f;
        float boardOffsetY = (_boardRows - 1) / 2f;

        return new Vector2(boardOffsetX, boardOffsetY);
    }

}
