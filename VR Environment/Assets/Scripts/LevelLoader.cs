using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelName; // The name of the level to load

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision occurred with the specified object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the new level
            SceneManager.LoadScene(levelName);
        }
    }
}
