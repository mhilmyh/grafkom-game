using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    // End Game function
    public void EndGame()
    {
        if( gameEnded == false )
        {
            gameEnded = true;
            Scoreboard();
        }
    }

    void Scoreboard()
    {
        // Load Score scene
        SceneManager.LoadScene("End Menu");
    }
}
