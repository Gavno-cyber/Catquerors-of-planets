using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject start_planet;

    UnitSelection unitSelection;

    List<GameObject> planets;

    Dictionary<GameObject, int> planets_priority = new Dictionary<GameObject, int>();

    PlayerData team;

    List<GameObject> planets_with_units;

    void Start()
    {
        planets = new List<GameObject>(Globals.PLANETS.Keys);
        planets_with_units = new List<GameObject>();
        planets_with_units.Add(start_planet);

        foreach (GameObject planet in planets) 
        {
            planets_priority.Add(planet, 0);
        } 

        unitSelection = this.gameObject.GetComponent<UnitSelection>();

        team = start_planet.GetComponent<Unit>().Team;
        SortValue();
    }

    float timer;
    public float interval = 2;

    // Update is called once per frame
    void Update()
    { 
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            if (planets_with_units != null)
            {
                for (int i = 0; i < planets_with_units.Count; i++)
                {
                    if (planets_with_units[i].GetComponent<PlanetManager>().Count > 0 && planets_with_units[i].GetComponent<Unit>().Team == team)
                    {
                        unitSelection._SelectUnitsForPlanet(planets_with_units[i]);
                        FindPlanet(planets_with_units[i]);
                        return;
                        //  if (CheckForUnits(planets_with_units[i]))
                        //{
                            //planets_with_units.Remove(planets_with_units[i]);
                        //}
                    }
                }

                timer -= interval;
            }
        }
    }

    bool CheckForUnits(GameObject planet)
    {
        if (planet.GetComponent<PlanetManager>().Count > 0)
            return true;
        else
            return false; 
    }

    private void FindPlanet(GameObject _start_planet)
    {
        GameObject planet_to_change = null;
        int max_priority = 0;

        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i] != _start_planet && unitSelection.CheckDistance(planets[i]))
            {
                if (planets_priority[planets[i]] > max_priority)
                {
                    max_priority = planets_priority[planets[i]];
                    planet_to_change = planets[i];
                }
            }
        }
        if (planet_to_change != null)
        {
            unitSelection._ChangePlanetForUnit(planet_to_change, Globals.SELECTED_UNITS[team]);
            planets_with_units.Add(planet_to_change);
        }
    }

    void SortValue()
    {
        int max_priority = planets.Count - 1;

        for (int i = 0; i < max_priority; i++)
        {
            int count = 1;

            for (int j = 0; j < max_priority; j++)
            {
                //if (i != j && planets[i].GetComponent<Planet>().MaxSpawn > planets[j].GetComponent<Planet>().MaxSpawn)
                //{
                //    count++;
                //}
                if (i != j && planets[i].GetComponent<Planet>().HP < planets[j].GetComponent<Planet>().HP)
                {
                    count++;
                }
                if (i != j && planets[j].GetComponent<Planet>().GetClass() == "Defend" || planets[j].GetComponent<Planet>().GetClass() == "Attack")
                {
                    count++;
                }
            }
            planets_priority[planets[i]] = count;
        }
    }
}