using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isMoving = false; // �v���C���[���ړ������ǂ����̃t���O
    Vector3 targetPosition; // �ړ��̖ڕW�ʒu

    [Tooltip("�ړ��ɂ����鎞��")]
    [SerializeField] float moveTime; // �ړ��ɂ����鎞��
    [Tooltip("�ړ���")]
    [SerializeField] float movementWidth;

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
                StartCoroutine(MovePlayer(Vector3.forward * movementWidth));

            if (Input.GetKeyDown(KeyCode.A))
                StartCoroutine(MovePlayer(Vector3.left * movementWidth));

            if (Input.GetKeyDown(KeyCode.S))
                StartCoroutine(MovePlayer(Vector3.back * movementWidth));

            if (Input.GetKeyDown(KeyCode.D))
                StartCoroutine(MovePlayer(Vector3.right * movementWidth));
        }
    }

    IEnumerator MovePlayer(Vector3 direction)
    {
        float elapsedTime = 0f;
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = targetPosition;
        isMoving = false;
        
    }
}
