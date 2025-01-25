using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierreFeuilleCiseaux : MonoBehaviour
{
    public enum Type
    {
        Pierre,
        Feuille,
        Ciseau
    }
    Type playerType = Type.Pierre;
    private float cooldownTime = 1f; // Durée du cooldown en secondes
    private float nextSwitchTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSwitchTime) // Vérifie si le cooldown est terminé
        {
            if (Input.GetKeyDown("e"))
            {
                playerType = Type.Pierre;
                Debug.Log(playerType);
                Debug.Log(nextSwitchTime);
                Debug.Log(Time.time);

                nextSwitchTime = Time.time + cooldownTime; // Définit le prochain temps de changement autorisé
            }
            else if (Input.GetKeyDown("r"))
            {
                playerType = Type.Feuille;
                Debug.Log(playerType);
                Debug.Log(nextSwitchTime);
                Debug.Log(Time.time);

                nextSwitchTime = Time.time + cooldownTime;
            }
            else if (Input.GetKeyDown("t"))
            {
                playerType = Type.Ciseau;
                Debug.Log(playerType);
                Debug.Log(nextSwitchTime);
                Debug.Log(Time.time);

                nextSwitchTime = Time.time + cooldownTime;
            }
        }
    }
}
