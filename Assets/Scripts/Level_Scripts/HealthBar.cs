using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health_Death playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currhealthBar;


    // Start is called before the first frame update
    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currHealth / 20;
    }

    // Update is called once per frame
    void Update()
    {
        currhealthBar.fillAmount = playerHealth.currHealth / 20;
    }
}
