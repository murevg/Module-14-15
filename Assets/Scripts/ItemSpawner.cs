using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;

    [SerializeField] private float _cooldown;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _cooldown)
        {
            List<SpawnPoint> emptyPoints = GetEmptyPoints();

            if(emptyPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

            Item item = Instantiate(_itemPrefabs[Random.Range(0,_itemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);

            spawnPoint.Occupy(item);

            _time = 0;
        }
    }

    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
            if (point.isEmpty)
                emptyPoints.Add(point);

        return emptyPoints;
    }
}
