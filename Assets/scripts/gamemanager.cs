using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);


    }

    public void gameOver()
    {

        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {

        SceneManager.LoadScene("Troy");
    }
  


}
