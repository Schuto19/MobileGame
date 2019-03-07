using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    public int Currency;
    float CurrencyGrowthDelay;

    // Start is called before the first frame update
    void Start()
    {
        Currency = 35;
    }

    // Update is called once per frame
    void Update()
    {
        CurrencyGrowthDelay += Time.deltaTime;
        if(CurrencyGrowthDelay >= .5f && GameObject.Find("DifficultyEmpty").GetComponent<DifficultyScript>().DifficultyLevel == 0)
        {
            Currency += 1;
            CurrencyGrowthDelay = 0;
        }
        else if(CurrencyGrowthDelay >= 1f && GameObject.Find("DifficultyEmpty").GetComponent<DifficultyScript>().DifficultyLevel == 1)
        {
            Currency += 1;
            CurrencyGrowthDelay = 0;
        }
        else if(CurrencyGrowthDelay >= 1.5f && GameObject.Find("DifficultyEmpty").GetComponent<DifficultyScript>().DifficultyLevel == 2)
        {
            Currency += 1;
            CurrencyGrowthDelay = 0;
        }
        GetComponent<Text>().text = "Souls: " + Currency;
    }
}
