using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject CountDown;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Stage;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemys;
    

    public void ZeroTimer()
    {
        CountDown.SetActive(true);
        Timer.SetActive(true);
        Bomb.SetActive(true);
        Stage.SetActive(true);
        Player.SetActive(true);
        Enemys.SetActive(true);
        

    }

}
