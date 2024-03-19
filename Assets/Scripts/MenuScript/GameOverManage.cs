using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManage : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
      gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(HeartManager.health<=0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
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
        
        HeartManager.health = 3;
        SceneManager.LoadScene("MainScene");
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
