using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ExampleShipControl : MonoBehaviour {

	public float acceleration_amount = 1f;
	public float rotation_speed = 1f;
	public GameObject turret;
	
	[SerializeField] private Joystick _joystickShipMover;

	[SerializeField] private Scrollbar _scrollbar;
	
	[SerializeField] private bool _buttonBreaks;
	
	public void onPress ()
	{
		_buttonBreaks = true;
	}
 
	public void onRelease ()
	{
		_buttonBreaks = false;
	}

	void Update () {

		if (_joystickShipMover.Vertical > 0) 
		{
			GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration_amount * Time.deltaTime);
		}
		if (_joystickShipMover.Vertical < 0 ) 
		{
			GetComponent<Rigidbody2D>().AddForce((-transform.up) * acceleration_amount * Time.deltaTime);
		}
		if (_joystickShipMover.Horizontal < 0) 
		{
			GetComponent<Rigidbody2D>().AddForce((-transform.right) * acceleration_amount * 0.6f  * Time.deltaTime);
		}
		if (_joystickShipMover.Horizontal > 0) 
		{
			GetComponent<Rigidbody2D>().AddForce((transform.right) * acceleration_amount * 0.6f  * Time.deltaTime);
		}
		
		if (_scrollbar.value < 0.5f) 
		{
			GetComponent<Rigidbody2D>().AddTorque(rotation_speed  * Time.deltaTime);
		}
		else if (_scrollbar.value > 0.5f) 
		{
			GetComponent<Rigidbody2D>().AddTorque(-rotation_speed  * Time.deltaTime);
		}
		else
		{
			GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * 0.2f * Time.deltaTime);
		}
		
		if (_buttonBreaks) 
		{
			GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * 0.015f * Time.deltaTime);
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * 0.015f * Time.deltaTime);
		}
	}
	
}
