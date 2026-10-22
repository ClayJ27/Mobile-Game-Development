using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public long score = 0;
    public TextMeshProUGUI scoreText;

    public void EnemyDeath()
    {
        Debug.Log("Score increase");
        score += 10;
    }

    public void BossDeath()
    {
        Debug.Log("Score increase");
        score += 500;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Score start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score change");
        scoreText.text = "Score: " + score;
    }
}
