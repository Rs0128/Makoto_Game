using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{

    [SerializeField] GameObject BombPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //スペースボタンが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createBomb();
        }
    }

    void createBomb()
    {
        float x = 5f;
        float y = 5f;
        Vector3 position = new Vector3(x, 0.5f, y);
        Instantiate(BombPrefab, position, Quaternion.identity);
    }
}
