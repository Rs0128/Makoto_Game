using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToMain : MonoBehaviour
{
    public void TitleButton()
    {
        SceneManager.LoadScene("MainGame");//���������C���̃V�[�����ɕύX���Ă�������
    }
}
