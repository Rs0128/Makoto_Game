using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultToTitle : MonoBehaviour
{
    public void TitleButton()
    {
        SceneManager.LoadScene("Title");//ここをシーン名に変更してください
    }
}
