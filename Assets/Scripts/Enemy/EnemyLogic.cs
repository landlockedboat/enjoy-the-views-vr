
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour {

    [SerializeField]
    string tagToFollow = "Player";

    Transform target;

    private NavMeshAgent agent;
    [SerializeField]
    Animator animator;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag(tagToFollow).transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        GameMaster.Instance.RegisterOnGameOverCallback(GameOver);
    }

    void GameOver()
    {
        agent.speed = 0;
        animator.Stop();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == tagToFollow)
        {
            GameMaster.Instance.GameOver();
        }
    }
}
