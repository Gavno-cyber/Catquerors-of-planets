using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text counter;
    public string upName;
    public int price;
    public int access;
    public GameObject block;

    void Start()
    {
        AccessUpdate();
    }

    void AccessUpdate()
    {
        int result = PlayerPrefs.GetInt("Stars");
        counter.text = result.ToString();
        access = PlayerPrefs.GetInt(upName + "Access");

        if (access == 1)
        {
            block.SetActive(true);
        }
        else
        {
            block.SetActive(false);
        }
    }

    public void OnButtonDown()
    {
        int stars = PlayerPrefs.GetInt("Stars");
        if (access == 0)
        {
            if (stars >= price)
            {
                PlayerPrefs.SetInt(upName + "Access", 1);
                PlayerPrefs.SetInt("Stars", stars - price);
                counter.text = PlayerPrefs.GetInt("Stars").ToString();
                AccessUpdate();
            }
        }
    }

    public void Otkat()
    {
        int stars = PlayerPrefs.GetInt("Stars");
        if (access == 1)
        {
            PlayerPrefs.SetInt(upName + "Access", 0);
            PlayerPrefs.SetInt("Stars", stars + price);
            counter.text = PlayerPrefs.GetInt("Stars").ToString();
            AccessUpdate();
        }
    }
}