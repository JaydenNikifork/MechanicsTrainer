using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button play = root.Q<Button>("Play");
        Button exit = root.Q<Button>("Exit");

        play.clicked += Play_clicked;
        exit.clicked += Exit_Clicked;
    }

    private void Play_clicked()
    {
        SceneManager.LoadScene("Game");
        ScoreKeeper.ResetScore();
    }

    private void Exit_Clicked()
    {
        Application.Quit();
    }
}
