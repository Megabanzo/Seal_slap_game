using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load when space is pressed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}