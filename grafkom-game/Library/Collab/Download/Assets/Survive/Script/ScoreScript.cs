using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();
    }

    public void AddScore()
    {
        scoreValue += 1;
    }
}
