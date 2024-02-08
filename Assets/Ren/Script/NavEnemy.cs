using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    NavMeshAgent enemyNavMesh;
    [SerializeField] GameObject Player;

    void Start()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemyNavMesh.SetDestination(Player.transform.position);
    }
}
