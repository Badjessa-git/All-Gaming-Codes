using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

   private int startingLives;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerManager player;

    public string mainMenu;


    public float waitAfterGameOver;
	// Use this for initialization
	void Start () {

        theText = GetComponent<Text>();

        startingLives = PlayerPrefs.GetInt("playerLives", 2);


    }
	
	// Update is called once per frame
	void Update () {
    
        if (startingLives< 0)
        {
            player.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);

        }

        theText.text = "X " + startingLives;

        if (gameOverScreen.activeSelf == true)
        {
            waitAfterGameOver -= Time.deltaTime;
        }
        if(waitAfterGameOver < 0)
        {
            LoadScene(mainMenu);
        }
		
	}

    public void Givelife()
    {
        startingLives++;
        PlayerPrefs.SetInt("playerLives", startingLives);
    }
    public void Takelife()
    {
        startingLives--;
        PlayerPrefs.SetInt("playerLives", startingLives);


    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
}


