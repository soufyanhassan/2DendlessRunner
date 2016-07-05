using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highScoreText;
    public float scoreCount;

    [SerializeField]
    private float highScoreCount;

    [SerializeField]
    private float pointsPerSecond;
    public bool scoreIncrease;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        
        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
	}

    public void AddScore(int pointsAdd)
    {
        scoreCount += pointsAdd;
    }
}
