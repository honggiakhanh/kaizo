using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton; 
    [SerializeField] private Button tutorialButton; 
    [SerializeField] private GameObject tutorialCanvas; 
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            GameManager.Instance.StartGame();
        });
        tutorialButton.onClick.AddListener(() =>
        {
            ToggleTutorial();
        });
        tutorialCanvas.gameObject.SetActive(false);
    }

    void ToggleTutorial()
    {
        tutorialCanvas.gameObject.SetActive(!tutorialCanvas.gameObject.activeSelf);
    }
}
