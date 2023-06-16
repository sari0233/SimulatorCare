using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    public string sceneToLoad;
    public string compareTag;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(compareTag))
        {
            // Load the "Hub" scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
