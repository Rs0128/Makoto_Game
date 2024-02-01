using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] float totalTime = 60f; //�^�C�}�[�̎���
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
            Debug.Log("�v���C���[�̏���");
            //�������珟���̃��b�Z�[�W�E�V�[���؂�ւ�
            SceneManager.LoadScene("ResultScene");
        }

        
        
    }

    void UpdateTimerUI()
    {
        float fillAmount = currenttime / totalTime;
        timerImage.fillAmount = fillAmount;
    }
}
