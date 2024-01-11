using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public float timeElapsed =0;
    [SerializeField]GameObject SmokePrefab;

    // Start is called before the first frame update
    void Start()
    {
    //    SmokePrefab = GameObject.Find("Smoke");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 3.0f)
        {
            Instantiate(SmokePrefab,transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
