using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Counter : MonoBehaviour
{
    [SerializeField] private Health_Death playerLives;
    private Text lifeCount;

    // Start is called before the first frame update
    void Start()
    {
        lifeCount.text = ": " + playerLives.currLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lifeCount.text = ": " + playerLives.currLives.ToString();
    }
}
