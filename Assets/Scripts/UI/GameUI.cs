using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private float point;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button backButton;
    void Start()
    {
        point = 0;
        replayButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        replayButton.onClick.AddListener(() =>
        {
            GameManager.Instance.StartGame();
        });
        backButton.onClick.AddListener(() =>
        {
            GameManager.Instance.BackToMainMenu();
        });
    }

    // Update is called once per frame
    void Update()
    {
        point += Time.deltaTime;
        pointText.text = (Mathf.Round(point * 100f) / 100f).ToString();
    }
}
