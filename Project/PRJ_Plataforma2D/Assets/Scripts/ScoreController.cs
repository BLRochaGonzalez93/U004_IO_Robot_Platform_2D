using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    static public int score;
    public TextMeshProUGUI scoreText;

    static public int lifes, tries;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    static public void SetScore(int points)
    {
        score += points;
        if (score < 0)
        {
            score = 0;
        }
    }

    static public void ResetScore()
    {
        score = 0;
    }

    static public void SetLifes(int li, int tr)
    {
        lifes = li;
        tries = tr;

        if (lifes <= 0)
        {
            lifes = 0;
        }

        if (tries <= 0)
        {
            tries = 0;
        }
    }

    static public float GetScore()
    {
        return score;
    }
}
