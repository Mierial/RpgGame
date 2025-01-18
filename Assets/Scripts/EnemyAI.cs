using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;
    [SerializeField] private float _lookRadius;

    public Animator _animator;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = PlayerManager.instance.player.transform;

    }

    void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if(distance <= _lookRadius)
        {
            _animator.SetBool("isPatrolling", true);
            _agent.SetDestination(_target.position);
            if(distance-0.5 <= _agent.stoppingDistance)
            {
                _animator.SetBool("isFight", true);
                _animator.SetBool("isPatrolling", false);
                LookTarget();
            }
            else
            {
                _animator.SetBool("isFight", false);
            }
        }
        else
        {
            _animator.SetBool("isPatrolling", false);
        }
    }

    void LookTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5f);
    }
    public void AttackboxOn() {
        Debug.Log("þ");
    }

}
