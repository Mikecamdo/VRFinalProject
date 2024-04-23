using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UI namespace

public class beginGame : MonoBehaviour
{
    public Button BeginGame; // Rename the member variable to avoid conflict

    // Start is called before the first frame update
    void Start()
    {
        BeginGame.onClick.AddListener(StartGame);
    }

    // Method to start the game
    void StartGame()
    {
        Debug.Log("Game started!");
        // Add your code to start the game here
    }
}
