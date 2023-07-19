using System;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySettings rootObject;
    [SerializeField] private SplineContainer path;

    private float _pathDist;
    private float _pathTime;
    private float _pos;

    private void Start()
    {
        
        _pathDist = path.Spline.GetLength();
        _pathTime = _pathDist / rootObject.MovementSpeed;
    }

    private void FixedUpdate()
    {
        _pos += Time.fixedDeltaTime.Lerp(0, _pathTime, 0, _pathDist);
        if (_pos >= 1.0f) _pos -= 1.0f;
        rootObject.transform.position = path.Spline.EvaluatePosition(_pos);
    }
}
