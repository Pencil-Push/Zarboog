using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Health_Death : MonoBehaviour
{
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }

    [Header ("Lives Parameter")]
    [SerializeField] private int maxLives;
    [SerializeField] private int currLives;

    private void Start()
    {
        currHealth = startingHealth;
        currLives = maxLives;
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        
        if (currHealth > 0)
        {
            //player hurt anim
        }
        else
        {
            //player death anim
        }
    }
}
