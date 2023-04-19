using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public GameObject prefabBall;
    public Transform ballSpawn;
    public GameObject currentBall;

    private void onTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        Instantiate(prefabBall, ballSpawn.position, ballSpawn.rotation);
    }
}
