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

    public void Graphics()
    {
        if (low.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }
        else if (medium.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
        }
        else if (high.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        }
        else if (high.isOn == false && medium.isOn == false && low.isOn == false)
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
            high.isOn = true;
        }
    }
}   