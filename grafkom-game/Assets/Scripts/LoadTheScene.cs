using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheScene : MonoBehaviour
{
    public void GotoGrassScene()
    {
        SceneManager.LoadScene("GrassScene");
    }

    public void GotoSavanaScene()
    {
        SceneManager.LoadScene("SavanaScene");
    }
}