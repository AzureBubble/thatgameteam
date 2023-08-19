using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject menu;
    //按下了ESC键
    private bool ismenu = true;
    private AudioSource am;
    


    void Start()
    {
        am = GameObject.Find("音乐盒子").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (ismenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SetActive(true);
                ismenu = false;
                Time.timeScale = 0;

                am.Pause();
                
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(false);
            ismenu = true;
            Time.timeScale = 1;
            am.Play();
        }
    }

    public void ContinueGame()//继续游戏
    {
        menu.SetActive(false);
        ismenu = true;
        Time.timeScale = 1;
        am.Play();
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