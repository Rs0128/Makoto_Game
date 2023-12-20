using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{

    public GameObject Bomb;
    private GameObject BombPrefab;
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
            CreateBomb();
        }
    }

    //ボム生成
    void CreateBomb()
    {
        GameObject Bomb = Instantiate(BombPrefab, transform.position, Quaternion.identity);
        Bomb.name = "Bomb";
    }

}
