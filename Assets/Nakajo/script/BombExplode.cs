using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField] public float timeElapsed =0;
    [SerializeField] GameObject SmokePrefab;

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
        if(timeElapsed >= 3.0f)
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
