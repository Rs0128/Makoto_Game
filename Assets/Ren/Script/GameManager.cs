using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Stage;
    

    public void ZeroTimer()
    {
        Timer.SetActive(true);
        Bomb.SetActive(true);
        Stage.SetActive(true);
    }

}
