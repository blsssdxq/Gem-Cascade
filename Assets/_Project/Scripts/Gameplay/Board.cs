using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _gemPrefab;
    [SerializeField] private Vector2Int _spawnCell;

    void Start()
    {
        Vector3 cellWorldSpawnPos = new Vector3(_spawnCell.x, _spawnCell.y, 0f);
        
        // spawn tile
        GameObject boardTile = Instantiate(_tilePrefab, cellWorldSpawnPos, Quaternion.identity, transform);
        boardTile.name = $"Tile {_spawnCell}";
        Debug.Log($"Spawned {boardTile.name} at {_spawnCell}");

        // spawn gem
        GameObject gem = Instantiate(_gemPrefab, cellWorldSpawnPos, Quaternion.identity, transform);
        gem.name = $"Gem {_spawnCell}";
        Debug.Log($"Spawned {gem.name} at {_spawnCell}");
    }

}
