using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bomb")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    //経過時間
    private float time;

    //オブジェクトの生成間隔
    public float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        //ランダム生成する時間
        if(time > spawnInterval)
        {
            //rangeAとrangeBの範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            Instantiate(createPrefab, new Vector3(x,createPrefab.transform.position.y, z), createPrefab.transform.rotation);

            //新しい生成位置
            Vector3 spawnPosition = new Vector3(x,createPrefab.transform.position.y,z);
            
            //オブジェクトが重ならないように位置を調整
            Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1.0f);
            foreach (Collider collider in colliders)
            {
                //既にほかのオブジェクトが存在する場合、新しい位置を再計算
                x = Random.Range(rangeA.position.x, rangeB.position.x);
                z = Random.Range(rangeA.position.z, rangeB.position.z);
                spawnPosition = new Vector3(x,createPrefab.transform.position.y,z);

                //再度判定
                colliders = Physics.OverlapSphere(spawnPosition,1.0f);
            }

            //経過時間リセット
            time = 0f;
            Debug.Log("Object spawned at: " + spawnPosition);
        }

    }
}
