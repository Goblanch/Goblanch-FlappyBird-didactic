using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject startGameTab;
    public GameObject gameOverTab;
    public Text scoreText;
    public Text gameOverScoreText;

    private void Start() {
        Time.timeScale = 0f;
    }

    public void HideStartGameTab() {
        startGameTab.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ShowGameOverTab(int coinsCollected) {
        scoreText.gameObject.SetActive(false);
        gameOverTab.SetActive(true);
        gameOverScoreText.text = coinsCollected.ToString();
        Time.timeScale = 0f;
    }

    public void HideGameOverTab() {
        gameOverTab.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void UpdateScoreText(int score) {
        scoreText.text = score.ToString();
    }
}
