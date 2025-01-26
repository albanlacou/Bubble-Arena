using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LoadScoreData : MonoBehaviour
{
    public int nbPlayer = 0;
    [SerializeField]
    private TMP_Text[] top;
    [SerializeField]
    private TMP_Text[] score;

    private void Start()
    {
        LoadData();
    }

    // Méthode pour charger les données
    public void LoadData()
    {
        nbPlayer = PlayerPrefs.GetInt("nbPlayer", 0);
        nbPlayer = 4;

        for (int i = 1; i <= nbPlayer; i++)
        {

            PlayerPrefs.SetInt("PlayerNumber" + i, i);
            PlayerPrefs.SetInt("PlayerScore" + i, i);

            int playerNumber = PlayerPrefs.GetInt("PlayerNumber" + i, -1);
            int playerScore = PlayerPrefs.GetInt("PlayerScore" + i, 0);

            top[i-1].text = "Player " + playerNumber;
            score[i-1].text = playerScore.ToString() ;
        }

    }
}
