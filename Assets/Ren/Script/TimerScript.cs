using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] float totalTime = 60f; //タイマーの時間
    float currenttime;

    void Start()
    {
        currenttime = totalTime;
    }

    void Update()
    {
        if(currenttime > 0f)
        {
            currenttime -= Time.deltaTime;
            UpdateTimerUI();
            
        }
        else
        {
            Debug.Log("プレイヤーの勝利");
            //勝ったら勝利のメッセージ・シーン切り替え
            SceneManager.LoadScene("ResultScene");
        }

        
        
    }

    void UpdateTimerUI()
    {
        float fillAmount = currenttime / totalTime;
        timerImage.fillAmount = fillAmount;
    }
}
