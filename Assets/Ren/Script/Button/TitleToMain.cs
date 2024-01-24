using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToMain : MonoBehaviour
{
    public void TitleButton()
    {
        SceneManager.LoadScene("Ren_Scene");//ここをメインのシーン名に変更してください
    }
}
