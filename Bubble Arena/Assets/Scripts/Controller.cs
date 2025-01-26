using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, int> controllerToPlayerMap = new Dictionary<int, int>();
    public List<GameObject> players = new List<GameObject>();
    private const int NbPLayer = 0;

    int nbPlayer = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(controllerToPlayerMap);
        for (int i = 0; i < 4; i++) // Boucle pour gérer les 2 manettes
        {
          
            // Vérifier si le bouton A (bouton 0 par défaut) est pressé sur la manette i
            if (Input.GetKeyDown($"joystick {i + 1} button 0"))
            {
                Debug.Log("tzkmsnfsdklnfklsen");
                HandleControllerInput(i);

            }

            if (nbPlayer >= 2 && Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                PlayerPrefs.SetInt("NbJoueurs", nbPlayer);
                SceneManager.LoadScene("main");
            }
        }
    }
    void HandleControllerInput(int controllerIndex)
    {
        // Si la manette a déjà sélectionné un joueur, on ignore
        if (controllerToPlayerMap.ContainsKey(controllerIndex))
        {
            Debug.Log($"Manette {controllerIndex + 1} a déjà sélectionné un joueur.");
            return;
        }

        // Trouver le premier joueur non assigné
        for (int i = 0; i < players.Count; i++)
        {
            if (!controllerToPlayerMap.ContainsValue(i)) // Si le joueur n'est pas déjà sélectionné
            {
                controllerToPlayerMap[controllerIndex] = i; // Associer la manette au joueur
                AssignPlayerColor(i, controllerIndex); // Modifier la couleur du joueur
                Debug.Log($"Manette {controllerIndex + 1} a sélectionné le joueur {i + 1}");
                nbPlayer++;
                return;
            }
        }

        Debug.Log($"Aucun joueur disponible pour la manette {controllerIndex + 1}.");
    }

    void AssignPlayerColor(int playerIndex, int controllerIndex)
    {
        // Générer une couleur aléatoire
        Color colorToAssign = new Color(0, 0, 0);
        players[playerIndex].GetComponent<Image>().color = colorToAssign;
        Debug.Log($"Couleur assignée au joueur {playerIndex + 1} par la manette {controllerIndex + 1} : {colorToAssign}");
    }
}