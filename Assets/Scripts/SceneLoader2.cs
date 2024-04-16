using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("World 2");
    }
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("StarterWorld");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
