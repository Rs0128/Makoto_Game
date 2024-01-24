using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToMain : MonoBehaviour
{
    public void TitleButton()
    {
        SceneManager.LoadScene("MainGame");//ここをメインのシーン名に変更してください
    }
}
