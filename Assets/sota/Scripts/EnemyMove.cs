using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private StageManager stageManager;

    private float currentTime = 0f;
    private float moveDuration = 1f; // �ړ�����Ԋu
    private float moveTime = 0.5f; // �ړ��Ɏg������

    private void Awake()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > moveDuration)
        {
            var movePosition = stageManager.EnemyToPlayer(); // StageManager����ړ�����󂯎��
            StartCoroutine(Move(movePosition)); // �ړ�
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