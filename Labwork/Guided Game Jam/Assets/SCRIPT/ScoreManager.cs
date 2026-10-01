using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public long score = 0;
    public TextMeshProUGUI scoreText;

    public void EnemyDeath()
    {
        score += 10;
    }

    public void BossDeath()
    {
        score += 500;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
