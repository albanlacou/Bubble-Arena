using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Vector3 spawnPosition;
    private GameObject destroyPlayer;
    private short pointPlayer1;
    private short pointPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        pointPlayer1 = 0;
        pointPlayer2 = 0;
}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            destroyPlayer = other.gameObject;
            Destroy(other.gameObject);
        }

        if (destroyPlayer.CompareTag("Player1"))
        {
            Instantiate(Player1, new Vector3(2.22f, 2.07f, 0), Quaternion.identity);
            pointPlayer2++;
            Debug.Log("Le player 1 a " + pointPlayer1 + " points.");
        }
        if (destroyPlayer.CompareTag("Player2"))
        {
            Instantiate(Player2, new Vector3(-2.17f, -1.38f, 0), Quaternion.identity);
            pointPlayer1++;
            Debug.Log("Le player 2 a " + pointPlayer2 + " points.");
        }

    }
}
