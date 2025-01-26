using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public static bool gameIsPause = false;

    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        // Activate / Print the pause menu // 
        pauseMenu.SetActive(true);
        Time.timeScale = 0;//there is nothing who can move when the pause mode is activate //
        gameIsPause = true;
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
    }

    public void LoadMainMenu()
    {
        //DontDestroyOnLoadScene.instance.RemoveFromeDontDestroyOnLoad();
        SceneManager.LoadScene("NomProchaineScene"); //permet de mener vers la prochaine scene 
    }


}
