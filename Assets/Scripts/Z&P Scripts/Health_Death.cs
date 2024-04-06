using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Death : MonoBehaviour
{
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }

    private void Start()
    {
        currHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        
        if (currHealth > 0)
        {

        }
        else
        {

        }
    }
}
