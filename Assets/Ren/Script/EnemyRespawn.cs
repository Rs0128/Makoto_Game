using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{

    [SerializeField] Transform[] RespawnAnchor;
    [SerializeField] LayerMask PLayer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Respawn(GameObject Senemy)
    {
        StartCoroutine(RespawnEnemy(Senemy));
    }

    IEnumerator RespawnEnemy(GameObject Senemy)
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0;i< RespawnAnchor.Length; i++)
        {
            if(Physics.CheckBox(RespawnAnchor[i].position,new Vector3(0.5f, 1f, 0.5f), Quaternion.Euler(0, 0, 0), PLayer))
            {
                continue;
            }
            else
            {
                Senemy.transform.position = RespawnAnchor[i].position;
            }
        }
        
        Senemy.SetActive(true);

    }
}

