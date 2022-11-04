using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private GameObject _camera;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        _camera.transform.position = new Vector3(_player.transform.position.x, _camera.transform.position.y, _camera.transform.position.z);
        _camera.transform.position = new Vector3(Mathf.Clamp(_camera.transform.position.x, 0, 238), _camera.transform.position.y, _camera.transform.position.z); 
    }
}
