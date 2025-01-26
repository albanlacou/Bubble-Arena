using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{
    public void SettingButtonIsClick()
    {
        SceneManager.LoadScene("Setting");
    }
}
