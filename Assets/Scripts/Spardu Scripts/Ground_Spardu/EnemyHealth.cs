using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    [SerializeField] private int numOfFlash;
    [SerializeField] private float flashDur;
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
           sAnim.SetTrigger("Hurt");
           StartCoroutine(damageFlash());

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            Destroy(gameObject);

            if(GetComponentInParent<Enemy_Patrol>() != null)
                    GetComponentInParent<Enemy_Patrol>().enabled = false;
                
                if(GetComponent<Enemy_Behavior>() != null)
                    GetComponent<Enemy_Behavior>().enabled = false;
        }
    }

    private IEnumerator damageFlash()
    {
        for(int i = 0; i < numOfFlash; i++)
        {
            sSprite.color = new(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDur);
            sSprite.color = Color.white;
            yield return new WaitForSeconds(flashDur);
        }
    }
}
