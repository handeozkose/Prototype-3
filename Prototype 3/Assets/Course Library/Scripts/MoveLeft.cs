using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 15;
    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * _speed);

        if (_playerControllerScript._gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
    }
}
