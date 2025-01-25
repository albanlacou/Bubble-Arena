using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreP1;
    public TMP_Text scoreP2;
   [SerializeField] public Arena Arena;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreP1.text = "Score Player 1 : " + Arena.pointPlayer1.ToString();
        scoreP2.text = "Score Player 2 : " + Arena.pointPlayer2.ToString();

    }
}
 