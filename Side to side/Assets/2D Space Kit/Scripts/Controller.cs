using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    public void SetRotater()
    {
        _scrollbar.value = 0.5f;
    }
}
