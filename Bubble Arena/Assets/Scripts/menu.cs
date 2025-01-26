using UnityEngine;

public class menu : MonoBehaviour
{
    public static bool gameIsPAused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPAused)
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPAused = true;
    }
    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPAused=false;
    }
}
