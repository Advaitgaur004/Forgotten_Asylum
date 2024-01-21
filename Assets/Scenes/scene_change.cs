using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour
{
    // Method to change the scene
    public void ChangeScene(string a)
    {
        // Load the next scene by its name
        SceneManager.LoadScene("a");
    }

    public void starte()
    {
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void instruction()
    {
        SceneManager.LoadScene(4);
    }


}