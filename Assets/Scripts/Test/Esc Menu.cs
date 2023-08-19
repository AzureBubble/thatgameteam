using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject menu;
    private bool ismenu = true;
    public AudioSource bgm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SetActive(true);
                ismenu = false;
                Time.timeScale = 0;
                bgm.Pause();
            }
        } 
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(false);
            ismenu = true;
            Time.timeScale = 1;
            bgm.Play();
        }
        
    }

    public void ContinueGame()//继续游戏
    {
        menu.SetActive(false);
        ismenu = true;
        Time.timeScale = 1;
        bgm.Play();
    }

    public void RestartGame()//重新开始游戏
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ExitGame()//退出游戏
    {
        Application.Quit();
    }


}
