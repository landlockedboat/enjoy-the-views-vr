
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour {

    [SerializeField]
    string tagToFollow = "Player";

    Transform target;

    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(tagToFollow).transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }
}
