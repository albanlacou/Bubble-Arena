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

    // M?thode pour charger les donn?es
    public void LoadData()
    {
        nbPlayer = PlayerPrefs.GetInt("nbPlayer", 0);

        for (int i = 1; i <= nbPlayer; i++)
        {

            int playerNumber = PlayerPrefs.GetInt("PlayerNumber" + i, -1);
            string playerScore = PlayerPrefs.GetString("PlayerScore" + i, "");
            Debug.Log("PlayerScore" + i+" : " + playerScore);

            top[i-1].text = "Player " + playerNumber;
            score[i-1].text = playerScore.ToString() ;
        }

    }
}
