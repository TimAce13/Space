using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBase : MonoBehaviour
{
    [SerializeField] private GameObject _enterBaseMenu;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _enterBaseMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _enterBaseMenu.SetActive(false);
        }
    }
}
