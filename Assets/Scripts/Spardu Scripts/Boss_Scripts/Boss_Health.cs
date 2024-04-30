using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Health : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Health Parameter")]
    [SerializeField] private float startingHealth;
    [SerializeField] private int numOfFlash;
    [SerializeField] private float flashDur;
    public float currHealth { get; private set; }
    [SerializeField] private AudioClip damageAClip;
    private bool dead;

    [Header ("Enemy Components")]
    private Animator bAnim;
    private SpriteRenderer bSprite;

    private void Start()
    {
        bAnim = GetComponent<Animator>();
        bSprite = GetComponent<SpriteRenderer>();
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
                StartCoroutine(Ending());
                
                //Destroy(gameObject);
                //SceneManager.LoadSceneAsync(5);
            }
        }
    }

    private IEnumerator damageFlash()
    {
        for(int i = 0; i < numOfFlash; i++)
        {
            bSprite.color = new(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(flashDur);
            bSprite.color = Color.white;
            yield return new WaitForSeconds(flashDur);
        }
    }

    
    private IEnumerator Ending()
    {
        bAnim.SetTrigger("Dead");
        yield return new WaitForSeconds(2.0f);
        //Destroy(gameObject, 0.5f);
        //yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(5);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
}
