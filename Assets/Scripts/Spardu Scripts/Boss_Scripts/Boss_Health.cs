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
          // sAnim.SetTrigger("Hurt");
            StartCoroutine(damageFlash());
        }
        else
        {
            if(!dead)
            {
                //StartCoroutine(Ending());
                // sAnim.SetTrigger("Die");
                Destroy(gameObject);
                SceneManager.LoadSceneAsync(5);
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

    /*
    private IEnumerator Ending()
    {
        Debug.Log("Starting" + Time.time);
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadSceneAsync(5);
        Debug.Log("Done" + Time.time);
    }
    */
}
