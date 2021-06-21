using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public static int currentLevelIndex = 1;

    private int maxLevels;

    public Text levelCompleteText;
    public GameObject[] particles;

    private void OnEnable() {
        maxLevels = SceneManager.sceneCountInBuildSettings;

        instance = this;

        levelCompleteText.text = "LEVEL COMPLETE";
        levelCompleteText.gameObject.SetActive(false);

        SetParticlesActive(false);
    }

    public static void _EndLevel() {
        instance.StartCoroutine("StartNextLevel");
    }

    private IEnumerator StartNextLevel() {
        Time.timeScale = 0.5f;
        levelCompleteText.gameObject.SetActive(true);
        SetParticlesActive(true);

        if (currentLevelIndex == maxLevels - 1)
            levelCompleteText.text = "FINISHED!";
        else
            levelCompleteText.text = "LEVEL COMPLETE";

        yield return new WaitForSeconds(2.5f);
        currentLevelIndex++;

        StartLevel(currentLevelIndex);
    }

    private void StartLevel(int currentLevelIndex) {
        Time.timeScale = 1.0f;
        
        if (currentLevelIndex == maxLevels) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(currentLevelIndex);
        }
    }

    private void SetParticlesActive(bool activate) {
        for (int i = 0; i < particles.Length; i++) {
            particles[i].SetActive(activate);
        }
    }

    public void StartButton() {
        SceneManager.LoadScene(1);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
