using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonReglages : MonoBehaviour
{
    public void Reglages() 
    {
        SceneManager.LoadScene("Parametres");
    }
}
