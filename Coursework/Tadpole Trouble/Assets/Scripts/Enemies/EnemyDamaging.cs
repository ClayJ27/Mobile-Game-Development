using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{

    public player_movement playerMovement;
    public Automatic_movement automaticMovement;
    public SpriteRenderer playerSprite;

    void OnTriggerEnter2D(Collider2D other) // Checks if an enemy has spawned on top of another enemy
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            playerSprite.enabled = false;
            playerMovement.enabled = false;
            automaticMovement.enabled = false;
        }

    }
}
