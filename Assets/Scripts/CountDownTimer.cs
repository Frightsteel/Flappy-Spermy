using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI countDownTimerText;

    private float countDownTimer = 3.5f;
    private int countDownInt;

    private void Update()
    {
        countDownTimer -= Time.deltaTime;

        if (Mathf.CeilToInt(countDownTimer) != countDownInt)
        {
            countDownInt = Mathf.CeilToInt(countDownTimer);

            if (countDownInt == 0)
            {
                SetCountDownTimerText("TAP!");
                
                StartCoroutine(ClearInfoTextAfterTimeoutRoutine(0.5f));
            }
        }
    }

    IEnumerator ClearInfoTextAfterTimeoutRoutine(float timeToClear)
    {
        yield return new WaitForSeconds(timeToClear);

        Destroy(countDownTimerText.gameObject);
    }

    public void SetCountDownTimerText(string text)
    {
        countDownTimerText.text = text;
    }
}
