using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Globals.PLAYERS.Add(new PlayerData(new Color(0.95686274509f, 0.09803921568f, 0.42745098039f, 1f), "Player"));
        Globals.PLAYERS.Add(new PlayerData(new Color(0.95686274509f, 0.93333333333f, 0.54901960784f, 1f), "Enemy"));

        Globals.MYTEAM = Globals.PLAYERS[0];

        GameObject[] Planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in Planets)
        {
            Globals.PLANETS.Add(planet, new List<GameObject>());
        }

        foreach (PlayerData player in Globals.PLAYERS)
        {
            Globals.SELECTED_UNITS.Add(player, new List<UnitManager>());
        }
    }
}