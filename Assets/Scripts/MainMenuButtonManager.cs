using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Full Name:        Tyler Miles
Student ID:       101251005
File:             MainMenuButtonManager.cs
Description:      This gets a reference to, and controls all buttons on the main menu
Date last modified: Dec 12, 2021
*/

public class MainMenuButtonManager : MonoBehaviour
{
    GameObject playButton;
    GameObject instructionsButton;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allButtons = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allButtons)
        {
            if(go.name == "PlayButton")
            {
                playButton = go;
            }
            else if (go.name == "InstructionsButton")
            {
                instructionsButton = go;
            }

        }

        if(playButton != null)
        {
            playButton.GetComponent<Button>().onClick.AddListener(OnPlayButtonPressed);

        }

        if(instructionsButton != null)
        {
            instructionsButton.GetComponent<Button>().onClick.AddListener(OnInstructionsButtonPressed);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene(2);
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameOverButtonPressed()
    {
        SceneManager.LoadScene(3);
    }
}
