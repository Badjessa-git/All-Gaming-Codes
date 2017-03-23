using UnityEngine;
using UnityEngine.SceneManagement;
public class CongratsMessage : MonoBehaviour {

    public GameObject player;

    private bool done;
    
    public float waitAfterGameOver;

    public string levelToLoad;

    // Use this for initialization
    void Start () {
        done = false; 
	}
	
	// Update is called once per frame
	void Update () {
        if (done == true)
        {
      
            player.gameObject.SetActive(false);
            waitAfterGameOver -= Time.deltaTime;
            }
            if (waitAfterGameOver < 0)
            {
                LoadScene(levelToLoad);

            }
        }

        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            done = true;
            
        }
  
       

    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
