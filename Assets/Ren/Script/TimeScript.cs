using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
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
        }
        
    }

    void UpdateTimerUI()
    {
        float fillAmount = currenttime / totalTime;
        timerImage.fillAmount = fillAmount;
    }
}
