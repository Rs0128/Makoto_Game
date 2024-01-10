using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField]GameObject[] spawnPoints;
    float spawnTime = 6.0f;//�{�����o�鎞�ԊԊu
    float currentTime = 0f;//���݂̎���

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime)//���݂̎��Ԃ��{�����o��Ԋu�𒴂�����
        {
            currentTime = 0f;
            StartCoroutine(CreateBomb());
        }
    }        

    IEnumerator CreateBomb()
    {
        int x = Random.Range(0,spawnPoints.Length);
        Instantiate(bombPrefab, spawnPoints[x].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
    }
}
