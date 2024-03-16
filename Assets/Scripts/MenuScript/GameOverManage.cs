using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManage : MonoBehaviour
{
    public GameObject gameOverUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);

    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    } 
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
Application.Quit();
    }
}
