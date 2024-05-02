using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Health : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    [SerializeField] private int numOfFlash;
    [SerializeField] private float flashDur;
    [SerializeField] private AudioClip damageAClip;
    [SerializeField] private AudioClip deathAClip;
    private bool dead;

    [Header ("Enemy Components")]
    private Animator sHAnim;
    private SpriteRenderer sHSprite;

    private void Start()
    {
        sHAnim = GetComponent<Animator>();
        sHSprite = GetComponent<SpriteRenderer>();
        currHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        
        if (currHealth > 0)
        {
            AltAudioM.instance.PlaySFXClip(damageAClip, transform, 1f);
            StartCoroutine(damageFlash());
        }
        else
        {
            if(!dead)
            {
                if(GetComponent<Ship_Behavior>() != null)
                    GetComponent<Ship_Behavior>().enabled = false;

                AltAudioM.instance.PlaySFXClip(deathAClip, transform, 1f);
                StartCoroutine(shipDead());
            }
        }
    }

    private IEnumerator damageFlash()
    {
        for(int i = 0; i < numOfFlash; i++)
        {
            sHSprite.color = new(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDur);
            sHSprite.color = Color.white;
            yield return new WaitForSeconds(flashDur);
        }
    }

    private IEnumerator shipDead()
    {
        sHAnim.SetTrigger("Die");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject, 0.1f);
    }
}
