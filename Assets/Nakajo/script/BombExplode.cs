using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField]float timeElapsed = 0;//経過時間の基準

    [Tooltip("これは爆風のPrehubです")]
    [SerializeField] GameObject SmokePrefab;
    [SerializeField]float TimeBomb = 0.0f;//ボムの生成管理時間

    List<GameObject> predictions = new List<GameObject>();
    [SerializeField]GameObject BombPrediction;
   // [SerializeField]BombCreate BombCopy;
    private List<Vector3> smokePositions = new List<Vector3>();

    public List<Vector3> SmokePositions { private get => smokePositions; set => smokePositions = value; }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < smokePositions.Count; i++)
        {
            predictions.Add(Instantiate(BombPrediction, smokePositions[i], Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= TimeBomb)
        {
            foreach (GameObject g in predictions)
            {
                Destroy(g);
            }
            for (int i = 0; i < smokePositions.Count; i++)
            {
                Instantiate(SmokePrefab, smokePositions[i], Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
