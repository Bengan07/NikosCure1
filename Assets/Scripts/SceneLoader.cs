using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scene
    {

    }
    public static void Load()
    {
        SceneManager.LoadScene("Starter World");
    }

    
}
