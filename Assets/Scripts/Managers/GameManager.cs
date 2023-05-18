using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Globals.PLAYERS.Add(new PlayerData(new Color(0.3f, 0.4f, 0.6f, 1f), "Player"));
        Globals.PLAYERS.Add(new PlayerData(new Color(0.6f, 0.3f, 0.4f, 1f), "Enemy"));

        Globals.MYTEAM = Globals.PLAYERS[0];

        GameObject[] Planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in Planets)
        {
            Globals.PLANETS.Add(planet, new List<GameObject>());
        }
    }
}