using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreate : MonoBehaviour
{

    [SerializeField] GameObject bombPrefab;
    [SerializeField]GameObject[] spawnPoints;
    [SerializeField] StageManager stageManager;
    [SerializeField]float firspawnTime = 3.0f;//ëOîºÇÃíxÇ¢É{ÉÄÇÃê∂ê¨éûä‘
    [SerializeField]float secspawnTime = 1.5f;//å„îºÇÃëÅÇ¢É{ÉÄÇÃê∂ê¨éûä‘
    float firstTime = 0f;
    float secondTime = 0f;
    float totalTime=0f;

    

    void Update()
    {   totalTime+=Time.deltaTime;
        if (totalTime < 90.0f) {
            firstTime += Time.deltaTime;
            if (firstTime > firspawnTime)
            {
                firstTime = 0f;
                CreateBomb2();
            }
        }
        else
        {   if(totalTime > 90f)
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
