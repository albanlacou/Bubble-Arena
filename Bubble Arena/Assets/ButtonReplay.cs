using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReplay : MonoBehaviour
{
    public void PlayButtonIsClick()
    {
        SceneManager.LoadScene("Play");
    }
}
