using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private float _startDelay = 2;
    private float _repeatRate = 2;

    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //1 Instantiate(_obstaclePrefab, _spawnPos,  _obstaclePrefab.transform.rotation);
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (_playerControllerScript._gameOver == false)
        {
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }
    }
}
