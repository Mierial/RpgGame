using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMashAgent : MonoBehaviour
{
    [SerializeField]private List <Transform> _points;
    [SerializeField]private NavMeshAgent _agent;
    private int _currentWayPointIndex = 0;
    [SerializeField] private float _waitTime = 2;
    private float _waitTimer = 0;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= 0.5f) 
        {
            _waitTimer += Time.deltaTime;
            if(_waitTimer >= _waitTime)
            {
                MoveToNextPoint();
                _waitTimer = 0;
            }
        }

    }

    private void MoveToNextPoint()
    {
        if (_points.Count == 0) return;
        {
           if( _points.Count > _currentWayPointIndex) 
           { 
              _currentWayPointIndex = (_currentWayPointIndex +1)% _points.Count;
              _agent.SetDestination(_points[_currentWayPointIndex].position);
           }
        }
    }
}
