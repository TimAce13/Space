using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRotater : MonoBehaviour
{
    public float turret_rotation_speed = 3f;

    [SerializeField] private Scrollbar _rotater;
    void FixedUpdate()
    {
        if (_rotater.value == 0.5f)
        { 
            Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
            
            Vector3 direction = CustomPointer.pointerPosition - turretPosition;
        
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.fixedDeltaTime)));
        }
    }
}
