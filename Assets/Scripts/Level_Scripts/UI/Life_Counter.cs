using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Counter : MonoBehaviour
{
    [SerializeField] private Health_Death playerLives;
    [SerializeField] private Text lifeCount;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = GetComponent<Health_Death>();
        lifeCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeCount.text = "x " + playerLives.currLives;


    }
}
