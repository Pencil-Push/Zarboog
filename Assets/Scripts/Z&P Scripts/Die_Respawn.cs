using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint;
    private Health_Death playerHealth;
    private Health_Death playerDeath;

    private void Start()
    {
        playerHealth = GetComponent<Health_Death>();
        playerDeath = GetComponent<Health_Death>();
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        playerHealth.Respawn();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            playerDeath.PlayerDeath();
            playerHealth.Respawn();
        }
    }

}
