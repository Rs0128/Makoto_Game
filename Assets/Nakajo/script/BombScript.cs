using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField]GameObject[] spawnPoints;
    float spawnTime = 6.0f;//ボムが出る時間間隔
    float currentTime = 0f;//現在の時間

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime)//現在の時間がボムが出る間隔を超えたら
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
