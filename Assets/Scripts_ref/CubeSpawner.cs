using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    [SerializeField] private float _mixX;
    [SerializeField] private float _maxX;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(Random.Range(_mixX, _maxX), 0, 0);

            Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
