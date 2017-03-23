using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCTRL : MonoBehaviour {
    public int playerLives;
    public void LoadScene(string sceneName)
    {
        PlayerPrefs.SetInt("playerLives", playerLives);
        PlayerPrefs.SetInt("score", 0);

        SceneManager.LoadScene(sceneName);
    }
}
