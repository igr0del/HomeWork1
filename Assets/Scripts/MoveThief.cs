using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThief : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _wayPoints;
    private int _currentWayPoint;

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _wayPoints[_currentWayPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentWayPoint++;
            if (_currentWayPoint >= _wayPoints.Length)
            {
                _currentWayPoint = 0;
            }
        }
    }
}
