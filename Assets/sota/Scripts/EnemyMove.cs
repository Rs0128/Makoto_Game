using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private StageManager stageManager;

    private float currentTime = 0f;
    private float moveDuration = 1f; // 移動する間隔
    private float moveTime = 0.5f; // 移動に使う時間

    private void Awake()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > moveDuration)
        {
            var movePosition = stageManager.EnemyToPlayer(); // StageManagerから移動先を受け取る
            StartCoroutine(Move(movePosition)); // 移動
            currentTime = 0;
        }
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        float ct = 0f;
        Vector3 startPos = this.transform.position;
        while (ct < moveTime) 
        {
            ct += Time.deltaTime;
            float step = ct / moveTime;
            this.transform.position = Vector3.Lerp(startPos, targetPos, step);
            yield return null;
        }
        this.transform.position = targetPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {

    }
}