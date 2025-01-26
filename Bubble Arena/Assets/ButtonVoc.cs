using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVoc : MonoBehaviour
{
    public void SettingButtonIsClick()
    {
        SceneManager.LoadScene("VolumPause");
    }
}