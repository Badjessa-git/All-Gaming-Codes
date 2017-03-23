using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;
    public string help;
    public bool isPause;
   
    
    public GameObject pauseMenuCanvas;

    void Start()
    {
        isPause = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void Resume()
    {
        isPause = false;
    }
    public void Quit()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void Help()
    {
        SceneManager.LoadScene(help);
    }
    public void Pause()
    {
        isPause = !isPause;
    }
}

