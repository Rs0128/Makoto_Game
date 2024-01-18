using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreate : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField]GameObject[] spawnPoints;
    [SerializeField] StageManager stageManager;
    float spawnTime = 6.0f;//�{�����o�鎞�ԊԊu
    float currentTime = 0f;//���݂̎���

    

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime)//���݂̎��Ԃ��{�����o��Ԋu�𒴂�����
        {
            currentTime = 0f;
            CreateBomb2();
        }
    }        

    IEnumerator CreateBomb()
    {
        int x = Random.Range(0,spawnPoints.Length);
        Instantiate(bombPrefab, spawnPoints[x].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
    }

    void CreateBomb2()
    {
        Debug.Log("<color=red>CreateBomb</color>" );
        Vector3 pos = stageManager.RandomBombPosition();
        var bomb = Instantiate(bombPrefab, pos, Quaternion.identity);
        BombExplode bombExplode = bomb.GetComponent<BombExplode>();
        bombExplode.SmokePositions = ExplodeRange(pos);
    }
    
    private List<Vector3> ExplodeRange(Vector3 pos)
    {
        int pattern = Random.Range(0, 3);
        //patern = 0;
        Debug.Log("<color=green>" + (StageManager.ExplodePattern)pattern + "</color>");
        return stageManager.ExplodePosition(pattern, pos);
    }
}
