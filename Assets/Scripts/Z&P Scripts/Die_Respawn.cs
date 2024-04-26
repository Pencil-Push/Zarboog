using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint;
    private Health_Death playerHealth;
    private Health_Death playerDeath;
    [SerializeField] private AudioClip deathAClip;

    private void Start()
    {
        playerHealth = GetComponent<Health_Death>();
        playerDeath = GetComponent<Health_Death>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            playerDeath.PlayerDeath();
            playerHealth.Respawn();
            AltAudioM.instance.PlaySFXClip(deathAClip, transform, 0.7f);
            transform.position = respawnPoint;
        }
    }

}
