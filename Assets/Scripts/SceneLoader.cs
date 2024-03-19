using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void TryAgainButton()
    {
        SceneManager.LoadScene("Starter World");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }


    public GameObject PauseCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show the "Pause Menu" canvas
            PauseCanvas.SetActive(true);
        }
        else
        {
            // Hide the "Pause Menu" canvas
            PauseCanvas.SetActive(false);
        }
    }

    // Add the following line to declare the Canvas object
    
}
