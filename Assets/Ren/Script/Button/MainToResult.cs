using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToResult : MonoBehaviour
{
    public void TitleButton()
    {
        SceneManager.LoadScene("Result");//ここをシーン名に変更してください
    }
}
