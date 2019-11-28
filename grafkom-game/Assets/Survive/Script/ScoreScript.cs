using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int scoreValue;

    void Awake() 
    {
        // This object will not destroy if scene change
        DontDestroyOnLoad(this);
    }
}
