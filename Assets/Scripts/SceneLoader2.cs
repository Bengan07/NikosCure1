using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
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

    public void LoadLevel3()

    {
        SceneManager.LoadScene("World3");
    }

    public void LoadLevelB()
    { 
        SceneManager.LoadScene("LevelB");
    }

}
