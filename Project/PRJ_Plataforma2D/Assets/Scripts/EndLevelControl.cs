using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLevelControl : MonoBehaviour
{
    // Referencia al texto donde se mostrará el score
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public float finalScore;

    // Referencias a las imágenes de las estrellas
    public Image star0;
    public Image star1;
    public Image star2;
    public Image star3;

    // Valor mínimo para obtener 3 estrellas
    public int threeStarsScore = 45;

    // Valor mínimo para obtener 2 estrellas
    public int twoStarsScore = 30;

    // Valor mínimo para obtener 1 estrella
    public int oneStarScore = 15;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetFloat("Score");
        scoreText.text = "Score: " + finalScore;

        string text = PlayerPrefs.GetString("Time");
        int index = text.IndexOf(',');
        string subString = text.Substring(0, index);

        timeText.text = "Time: " + subString + " secs";



        if (finalScore >= threeStarsScore)
        {
            star0.gameObject.SetActive(true);
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }
        else if (finalScore >= twoStarsScore)
        {
            star0.gameObject.SetActive(true);
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(false);
        }
        else if (finalScore >= oneStarScore)
        {
            star0.gameObject.SetActive(true);
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
        else
        {
            star0.gameObject.SetActive(true);
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
    }
}
