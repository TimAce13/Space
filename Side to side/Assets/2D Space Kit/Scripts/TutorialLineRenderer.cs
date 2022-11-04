using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLineRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private GameObject _firstObjPos;
    [SerializeField] private GameObject _thirdObjPos;

    private Vector3 firstPoint;
    private Vector3 secondPoint;
    private Vector3 thirdPoint;
    
    void Start()
    {
        firstPoint = new Vector3(_firstObjPos.transform.position.x, _firstObjPos.transform.position.y, -10);
        secondPoint = new Vector3(_firstObjPos.transform.position.x, _thirdObjPos.transform.position.y, -10);
        thirdPoint = new Vector3(_thirdObjPos.transform.position.x, _thirdObjPos.transform.position.y, -10);
        
        _lineRenderer.positionCount = 3;
        
        _lineRenderer.SetPosition(0, firstPoint);
        _lineRenderer.SetPosition(1, secondPoint);
        _lineRenderer.SetPosition(2, thirdPoint);
    }
}
