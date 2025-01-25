using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonJouer : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("main");
    }
    
}
