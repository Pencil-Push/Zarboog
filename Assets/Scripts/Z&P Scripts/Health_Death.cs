using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Death : MonoBehaviour
{
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private bool dead;
    private bool gameEnd;
    private Die_Respawn zRespawn;

    [Header ("iFrames")]
    [SerializeField] private float invulDur;
    [SerializeField] private int flashCount;
    private SpriteRenderer zSprite;

    [Header ("Lives Parameter")]
    [SerializeField] private float maxLives;
    public float currLives { get; private set; }
    public Text lifeText;
    
    [Header ("Player Components")]
    private Animator zAnim;

    [Header ("Audio Clips")]
    [SerializeField] private AudioClip damageAClip;
    [SerializeField] private AudioClip deathAClip;

    private void Start()
    {
        zAnim = GetComponent<Animator>();
        zSprite = GetComponent<SpriteRenderer>();
        zRespawn = GetComponent<Die_Respawn>();
        currHealth = startingHealth;
        currLives = maxLives;
        lifeText.text = "x " + currLives.ToString();
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }
    }
    
    public void TakeDamage(float _damage)
    {
        currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        
        if (currHealth > 0)
        {
            zAnim.SetTrigger("Hurt");
            AltAudioM.instance.PlaySFXClip(damageAClip, transform, 1f);
            StartCoroutine(Invul());
        }
        else
        {
            if(!dead)
            {
                zAnim.SetTrigger("Die");

                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                dead = true;

                PlayerDeath();
                AltAudioM.instance.PlaySFXClip(deathAClip, transform, 0.5f);
            }
        }
    }

    public void AddHealth(float _value)
    {
        currHealth = Mathf.Clamp(currHealth + _value, 0, startingHealth);
    }


    public void PlayerDeath()
    {
        currLives -= 1;
        Respawn();
        lifeText.text = "x " + currLives.ToString();
        if (currLives <= 0)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void AddLife()
    {
        currLives++;
        lifeText.text = "x " + currLives.ToString();
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        StartCoroutine(Death());
        StartCoroutine(Invul());

        // Activates 
        if(GetComponent<PlayerMovement>() != null)
            GetComponent<PlayerMovement>().enabled = true;
    }

    private IEnumerator Death()
    {
       zAnim.SetTrigger("Die");
       yield return new WaitForSeconds(1);
       zAnim.ResetTrigger("Die");
       zAnim.Play("Z_Idle");
    }

    private IEnumerator Invul()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for(int i = 0; i < flashCount; i++)
        {
            zSprite.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(invulDur / (flashCount * 2));
            zSprite.color = Color.white;
            yield return new WaitForSeconds(invulDur / (flashCount * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
