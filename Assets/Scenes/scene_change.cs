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
}