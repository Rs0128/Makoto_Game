using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(SquareMoveZ());
        }
    }

    IEnumerator SquareMoveX()
    {
        yield return null;
    }
    IEnumerator SquareMoveZ()
    {
        Vector3 moveDirection = new Vector3(0, 0, 1);
        yield return null;
    }
}
