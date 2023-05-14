using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener("PlanetCaptured", EndGame);
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("level", 2);
    }
}
