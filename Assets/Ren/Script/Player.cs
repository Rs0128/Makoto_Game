using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool isMoving = false; // プレイヤーが移動中かどうかのフラグ
    Vector3 targetPosition; // 移動の目標位置

    bool canMove = true;
    [Tooltip("移動にかかる時間")]
    [SerializeField] float moveTime; // 移動にかかる時間
    [Tooltip("移動幅")]
    [SerializeField] float movementWidth;
    Animator animator;

    [SerializeField] NavEnemy[] Nenemy;
    [SerializeField] GameObject Bomb;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerControl();
    }

    
    void PlayerControl()
    {
        if (!Physics.Raycast(transform.position, Vector3.forward, 1.1f))
        {
            if (!isMoving && canMove && Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine(MovePlayer(Vector3.forward * movementWidth));
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                animator.SetBool("is_Running", true);
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.left, 1.1f))
        {
            if (!isMoving && canMove && Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(MovePlayer(Vector3.left * movementWidth));
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                animator.SetBool("is_Running", true);
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.back, 1.1f))
        {
            if (!isMoving && canMove && Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(MovePlayer(Vector3.back * movementWidth));
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                animator.SetBool("is_Running", true);
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.right, 1.1f))
        {
            if (!isMoving && canMove && Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(MovePlayer(Vector3.right * movementWidth));
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                animator.SetBool("is_Running", true);
            }
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
        animator.SetBool("is_Running", false);

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bomb") || other.CompareTag("Enemy"))
            {
                StartCoroutine("PlayerDeath");
            
            }
    }

    IEnumerator PlayerDeath()
    {
        Debug.Log("死亡");
        animator.SetBool("is_Death", true);
        Nenemy[0].gameObject.SetActive(false);
        Nenemy[1].gameObject.SetActive(false);
        Nenemy[2].gameObject.SetActive(false);
        Bomb.SetActive(false);
        canMove = false;
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Result(gameover)");

    }
    
}
