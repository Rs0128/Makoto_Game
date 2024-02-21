using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    NavMeshAgent enemyNavMesh;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GameObject;

    void Start()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemyNavMesh.SetDestination(Player.transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            GameObject.SetActive(false);
        }
    }
}
        
        
