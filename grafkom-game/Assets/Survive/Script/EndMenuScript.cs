using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour
{
    public void RestartGame() 
    {
        // Destroy Score
        Destroy(GameObject.FindWithTag("Score"));

        SceneManager.LoadScene("Main Scene");
    }

    public void ExitGame() 
    {
        // Only run in compiled game
        Application.Quit();
    }
}
