using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _detectionAngle;
    [SerializeField] private NavMeshAgent _agent;
    private NavMeshEnemy _nmEnemy;
    void Start()
    {
        _nmEnemy = GetComponent<NavMeshEnemy>();
        _agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if(PlayerInSight())
        {
            _nmEnemy.StopPatrol();
            FollowPlayer();
        }
        else if(_agent.remainingDistance < _agent.stoppingDistance)
        {
            _nmEnemy.SetNextDestination();
        }
    }

    private bool PlayerInSight()
    {
        Vector3 directionToPlayer = (_playerPosition.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, _playerPosition.position);
        if(distanceToPlayer < _detectionRadius)
        {
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if(angleToPlayer < _detectionAngle/2) 
            { 
                //if(!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer))
                //{
                return true;
                //}
            }
        }
        return false;
    }

    private void FollowPlayer()
    {
        _agent.SetDestination(_playerPosition.position);
    }

}
