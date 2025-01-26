using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonCredit : MonoBehaviour
{
    public void CreditButtonIsClick()
    {
        SceneManager.LoadScene("Credit");
    }
}
