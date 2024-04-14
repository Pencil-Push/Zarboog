using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private bool dead;

    [Header ("Enemy Components")]
    private Animator sAnim;
    private SpriteRenderer sSprite;

    private void Start()
    {
        sAnim = GetComponent<Animator>();
        sSprite = GetComponent<SpriteRenderer>();
        currHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        
        if (currHealth > 0)
        {
          // sAnim.SetTrigger("Hurt");

        }
        else
        {
            if(!dead)
            {
                // sAnim.SetTrigger("Die");
                Destroy(gameObject);

                if(GetComponentInParent<Enemy_Patrol>() != null)
                    GetComponentInParent<Enemy_Patrol>().enabled = false;
                
                if(GetComponent<Enemy_Behavior>() != null)
                    GetComponent<Enemy_Behavior>().enabled = false;
            }
        }
    }
}
