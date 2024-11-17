using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavMashAgent : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private NavMeshAgent _agent;
    private int _currentWayPointIndex = 0;
    [SerializeField] float _waitTime = 2f;
    private float _waitTimer = 0f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_points.Count > 0)
        {
            _agent.SetDestination(transform.position);
        }
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= 0.1f)
        {
            MoveToNextPoint();
        }
    }

    public virtual void MoveToNextPoint()
    {
        if (_points.Count > 0)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _points.Count;
            _agent.SetDestination(_points[_currentWayPointIndex].position);
        }
    }
}
