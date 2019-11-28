using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
