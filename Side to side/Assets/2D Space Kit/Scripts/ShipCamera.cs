using System;
using UnityEngine;
using System.Collections;

public class ShipCamera : MonoBehaviour {

	private Transform target_object;
	public float follow_tightness;
	Vector3 wanted_position;

	private void Start()
	{
		target_object = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate () {
		
		wanted_position = target_object.position;
		wanted_position.z = transform.position.z;
		transform.position = Vector3.Lerp(transform.position, wanted_position, Time.deltaTime * follow_tightness);
		
	}
}
