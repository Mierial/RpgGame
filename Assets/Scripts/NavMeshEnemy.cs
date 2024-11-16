using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    private float _timer;
    private bool _isWaiting; 
    private const float WaitTime = 3f; 
    [SerializeField] private Animator _animator;
    private int _currentWayPointIndex;
    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        _isWaiting = true;
        SetNextDestination();
    }

    private void Update()
    {

        if (_isWaiting)
        {
            _timer += Time.deltaTime;
            if (_timer >= WaitTime)
            {
                _isWaiting = false;
                _animator.SetBool("isPatrolling", true); 
                SetNextDestination();
            }
        }
        else if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            _animator.SetBool("isPatrolling", false);
            _timer = 0f;
            _isWaiting = true; 
        }
    }

    public void SetNextDestination()
    {
        _currentWayPointIndex = (_currentWayPointIndex + 1) % _points.Count;
        _agent.SetDestination(_points[_currentWayPointIndex].position);
    }
    public void StopPatrol()
    {
        _agent.SetDestination(transform.position);
        _animator.SetBool("isPatrolling", false);
    }

}
