using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Quality : MonoBehaviour
{
    public Toggle low;
    public Toggle medium;
    public Toggle high;
    int quality = 2;

    public void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        if (PlayerPrefs.GetInt("Quality") == 0)
        {
            low.interactable = false;
            medium.interactable = true;
            high.interactable = true;
        }
        else if (PlayerPrefs.GetInt("Quality") == 1)
        {
            medium.interactable = false;
            low.interactable = true;
            high.interactable = true;
        }
        else if (PlayerPrefs.GetInt("Quality") == 2)
        {
            high.interactable = false;
            low.interactable = true;
            medium.interactable = true;
        }
    }

    public void Graphics()
    {
        if (low.isOn == true)
        {
            low.interactable = false;
            medium.interactable = true;
            high.interactable = true;
            quality = 0;
            PlayerPrefs.SetInt("Quality", quality);
        }
        else if (medium.isOn == true)
        {
            medium.interactable = false;
            low.interactable = true;
            high.interactable = true;
            quality = 1;
            PlayerPrefs.SetInt("Quality", quality);
        }
        else if (high.isOn == true)
        {
            high.interactable = false;
            low.interactable = true;
            medium.interactable = true;
            quality = 2;
            PlayerPrefs.SetInt("Quality", quality);
        }
        else if (high.isOn == false && medium.isOn == false && low.isOn == false)
        {
            high.isOn = true;
            high.interactable = false;
            low.interactable = true;
            medium.interactable = true;
            quality = 2;
            PlayerPrefs.SetInt("Quality", quality);
        }
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }
}   