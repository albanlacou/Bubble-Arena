using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savedata : MonoBehaviour
{
    public int nbPlayer = 0;

    // M?thode pour sauvegarder les donn?es
    

    // M?thode pour charger les donn?es
    public void LoadData()
    {

        nbPlayer = PlayerPrefs.GetInt("nbPlayer", 0);

        for (int i = 1; i <= nbPlayer; i++)
        {
            int playerNumber = PlayerPrefs.GetInt("PlayerNumber" + i, -1);
            string playerScore = PlayerPrefs.GetString("PlayerScore" + i, "0");

            Debug.Log($"Joueur {playerNumber} : Score = {playerScore}");
        }
    }
}
