using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMover : MonoBehaviour
{
    [SerializeField] private int _minAngle;
    [SerializeField] private int _maxAngle;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, UnityEngine.Random.Range(_minAngle, _maxAngle) * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject); 
        }
        
        if (col.gameObject.tag == "Killer")
        {
            Destroy(gameObject);
        }
    }
}
