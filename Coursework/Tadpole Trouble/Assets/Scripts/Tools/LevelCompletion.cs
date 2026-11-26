using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{

    [SerializeField] private string credits_screen = "CreditsScreen";
    public int levelIndex;
    public float elapsedSeconds;


    void OnTriggerEnter2D(Collider2D other) // Checks if an enemy has spawned on top of another enemy
    {
        if (other.CompareTag("Goal"))
        {
            Handheld.Vibrate();
            ProgressStore.Instance.Tracker.OnLevelCompleted(levelIndex, elapsedSeconds);

        }

    }
}
