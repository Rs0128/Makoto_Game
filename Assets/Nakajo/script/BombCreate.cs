using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreate : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField]GameObject[] spawnPoints;
    [SerializeField] StageManager stageManager;
    [SerializeField]float firspawnTime = 3.0f;//前半の遅いボムの生成時間
    [SerializeField]float secspawnTime = 1.5f;//後半の早いボムの生成時間
    float firstTime = 0f;//前半のボムの生成管理用の時間
    float secondTime = 0f;//後半のボムの生成管理用の時間
    float totalTime= 0f;//爆弾生成するときの前半後半を管理する時間

    

    void Update()
    {   totalTime+=Time.deltaTime;
        if (totalTime < 15.0f) {
            firstTime += Time.deltaTime;
            if (firstTime > firspawnTime)
            {
                firstTime = 0f;
                CreateBomb2();
            }
        }
        else
        {   if(totalTime >15.0f)
               secondTime += Time.deltaTime;
               if (secondTime > secspawnTime)
               {
                   secondTime = 0f;
                   CreateBomb2();
               }
        }
    }

//    IEnumerator CreateBomb()
//    {
//        int x = Random.Range(0,spawnPoints.Length);
//        Instantiate(bombPrefab, spawnPoints[x].transform.position, Quaternion.identity);
//        yield return new WaitForSeconds(3f);
//  }

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
