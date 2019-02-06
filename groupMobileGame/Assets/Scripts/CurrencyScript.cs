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
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrencyGrowthDelay += Time.deltaTime;
        if(CurrencyGrowthDelay >= 1)
        {
            Currency += 1;
            CurrencyGrowthDelay = 0;
        }
        GetComponent<Text>().text = "Currency: " + Currency;
    }
}
