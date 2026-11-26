using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{

    public player_movement playerMovement;
    public Automatic_movement automaticMovement;
    public SpriteRenderer playerSprite;
    public int levelIndex;
    public float elapsedSeconds;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            ProgressStore.Instance.Tracker.OnEnemyDefeated();
            ProgressStore.Instance.Tracker.OnLevelCompleted(levelIndex, elapsedSeconds);
            playerSprite.enabled = false;
            playerMovement.enabled = false;
            automaticMovement.enabled = false;
        }

    }
}
