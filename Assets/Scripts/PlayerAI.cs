using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] string targetTag;
    [HideInInspector]
    public GameObject BridgeTarget;

    Player player;
    Animator animator;

    float distanceToClosestTarget;
    float distanceToTarget;

    private GameObject target;
    private GameObject[] _allTargets;
    private NavMeshAgent NavMeshAgent;

    bool canMove = false;

    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Invoke("FindClosestEnemy", 0.5f);
    }

    private void Update()
    {
        if (player.brickLine == 0)
        {
            FindClosestEnemy();
        }
        if (player.brickLine >= 5)
        {
            target = BridgeTarget;
        }
        if (canMove)
        {
            animator.SetBool("running", true);
            NavMeshAgent.destination = target.transform.position;
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            canMove = false;
            other.gameObject.tag = "Untagged";
            FindClosestEnemy();
        }
    }

    void FindClosestEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        _allTargets = GameObject.FindGameObjectsWithTag(targetTag);
        for (int i = 0; i < _allTargets.Length; i++)
        {
            distanceToTarget = (_allTargets[i].transform.position - gameObject.transform.position).sqrMagnitude;
            if (distanceToTarget < distanceToClosestTarget)
            {
                distanceToClosestTarget = distanceToTarget;
                target = _allTargets[i];
            }
        }
        canMove = true;
    }
}
