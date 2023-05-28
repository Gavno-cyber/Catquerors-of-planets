using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public GameObject old_planet;

    public bool CheckDistance(GameObject planet)
    {
        return Vector3.Distance(old_planet.transform.position, planet.transform.position) <= old_planet.GetComponent<Planet>().MaxRange;
    }

    public void _SelectUnitsForPlanet(GameObject planet)
    {
        old_planet = planet;

        planet.GetComponent<UnitManager>().Deselect();

        int count = planet.GetComponent<PlanetManager>().Count;

        for (int i = 0; i < count; i++){

            GameObject unit = Globals.PLANETS[planet][i];
            
            if (unit != null)
            {
                unit.GetComponent<UnitManager>().Select();
            }
            
        }
    }

    public void _SelectUnitsOfOneClass(GameObject _unit)
    {
        old_planet = _unit.GetComponent<PlanetGravity>().planet;

        int count = old_planet.GetComponent<PlanetManager>().Count;

        for (int i = 0; i < count; i++)
        {
            GameObject unit = Globals.PLANETS[old_planet][i];
            if (unit.GetComponent<Unit>().GetClass() == _unit.GetComponent<Unit>().GetClass())
                unit.GetComponent<UnitManager>().Select();
        }
    }

    public void _ChangePlanetForUnit(GameObject _planet, List<UnitManager> _selected_units)
    {
        List<UnitManager> selected_units = new List<UnitManager>(_selected_units);
        GameObject planet = _planet;

        int count = selected_units.Count;

        for (int i = 0; i < count; i++)
        {
            UnitManager selected_unit = selected_units[i];

            selected_unit.Deselect();

            if (planet.GetComponent<PlanetManager>().Count >= planet.GetComponent<Planet>().MaxSpawn)
                continue;

            selected_unit.gameObject.GetComponent<PlanetGravity>().planet = planet;

            old_planet.GetComponent<PlanetManager>().RemoveUnit(selected_unit.gameObject);
            planet.GetComponent<PlanetManager>().AddUnit(selected_unit.gameObject);
        }
    }

    public void DeselectUnits(List<UnitManager> _selected_units)
    {
        List<UnitManager> selected_units = new List<UnitManager>(_selected_units);
        int count = selected_units.Count;

        for (int i = 0; i < count; i++)
        {
            UnitManager selected_unit = selected_units[i];
            selected_unit.Deselect();
        }
    }

    public void _SelectSingleUnit(GameObject unit)
    {
        old_planet = unit.GetComponent<PlanetGravity>().planet;
        unit.GetComponent<UnitManager>().Select(true);
    }
}