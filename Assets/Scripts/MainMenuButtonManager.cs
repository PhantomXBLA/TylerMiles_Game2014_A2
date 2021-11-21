using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        playButton.GetComponent<Button>().onClick.AddListener(OnPlayButtonPressed);
        instructionsButton.GetComponent<Button>().onClick.AddListener(OnInstructionsButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene(2);
    }
}