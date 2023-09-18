using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int score = 0;
    public static Text text;

    private void OnEnable()
    {
        Transform childObj = transform.Find("Score");
        text = childObj.GetComponent<Text>();
        text.text = score.ToString();
    }

    public static void Increment()
    {
        score++;
        text.text = score.ToString();
    }

    public static void ResetScore()
    {
        score = 0;
        text.text = score.ToString();
    }
}
