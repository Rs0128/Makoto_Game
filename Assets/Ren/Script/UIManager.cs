using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] Image countDownImage;
    [SerializeField] Text countDownText;
    [SerializeField] GameManager SetTimer;
    int threeCount;
    float countDownElapsedTime;
    float countDownDuration = 3.0f;

    void Start()
    {
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        threeCount = 0;
        countDownElapsedTime = 0;

        //テキスト更新
        countDownText.text = System.String.Format("{0}", Mathf.FloorToInt(countDownDuration));

        countDownImage.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(true);

        while (true)
        {
            countDownElapsedTime += Time.deltaTime;

            countDownImage.fillAmount = countDownElapsedTime % 1.0f; //円形コライダーの更新

            if(threeCount < Mathf.FloorToInt(countDownElapsedTime))
            {
                threeCount ++; //一秒刻みカウント

                //テキストの更新
                countDownText.text = System.String.Format("{0}", Mathf.FloorToInt(countDownDuration - threeCount));
            }

            //カウントダウン終了
            if(countDownDuration <= countDownElapsedTime)
            {
                countDownImage.gameObject.SetActive(false);
                countDownText.gameObject.SetActive(false);

                SetTimer.ZeroTimer();
                yield break;
            }
            yield return null;
        }
    }
}
