using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] Planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in Planets)
        {
            Globals.PLANETS.Add(planet, new List<GameObject>());
        }
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
}