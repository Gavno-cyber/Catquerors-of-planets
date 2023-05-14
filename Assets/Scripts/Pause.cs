using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pause : MonoBehaviour
{
    public GameObject panel;

    /*GameObject[] planets;
    GameObject[] cats;*/

    public void pause()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        /*planets = GameObject.FindGameObjectsWithTag("Planet");
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].SetActive(false);
        }
        cats = GameObject.FindGameObjectsWithTag("Unit");
        for (int i = 0; i < cats.Length; i++)
        {
            cats[i].SetActive(false);
        }*/
    }

    public void continueGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        /*planets = GameObject.FindGameObjectsWithTag("Planet");
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].activeSelf)
            {
                planets[i].SetActive(true);
            }
        }
        cats = GameObject.FindGameObjectsWithTag("Unit");
        for (int i = 0; i < cats.Length; i++)
        {
            cats[i].SetActive(true);
        }*/
    }
}
