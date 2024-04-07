using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.posiiton = respawnPoint.position;
        }
    }
    */
}
