using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    private bool _isClicked = false;
    private GameObject old_planet;
    int count;
    private Camera cam;
    GameObject hit_object;

    List<UnitManager> selected_units;

    void Start()
    {
        selected_units = new List<UnitManager>();
        cam = Camera.main;
    }

    float lastClickTime;
    public float catchTime = 0.25f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.GetRayIntersection(ray);

            if (hitInfo.collider != null) 
            {
                hit_object = hitInfo.collider.gameObject;

                if (Time.time - lastClickTime < catchTime)
                {
                    if (hit_object.CompareTag("Planet"))
                    {
                        _SelectUnitsForPlanet();
                    }
                    else if (hit_object.CompareTag("Unit")) {

                        old_planet = hit_object.GetComponent<PlanetGravity>().planet;

                        for (int i = 0; i < Globals.PLANETS[old_planet].Count; i++)
                        {
                            GameObject unit = Globals.PLANETS[old_planet][i];
                            if (unit.GetComponent<Unit>().GetClass() == hit_object.GetComponent<Unit>().GetClass())
                                unit.GetComponent<UnitManager>().Select();
                        }
                        _isClicked = true;
                    }
                    else
                    {
                        DeselectUnits();
                        _isClicked = false;
                    }
                }
                else
                {
                    if (hit_object.CompareTag("Unit"))
                        _SelectSingleUnit();
                    else if (hit_object.CompareTag("Planet"))
                    {
                        if (_isClicked && old_planet != hit_object && Vector3.Distance(old_planet.transform.position, hit_object.transform.position) <= old_planet.GetComponent<Planet>().MaxRange)
                        {
                            _ChangePlanetForUnit();
                        }
                        else
                        {
                            DeselectUnits();
                            hit_object.GetComponent<UnitManager>().Select();
                        }
                    }
                    else{
                        DeselectUnits();
                        _isClicked = false;
                    }
                }
                lastClickTime = Time.time;
            }
            else
            {
                DeselectUnits();
                _isClicked = false;
            }
        }
    }

    private void _SelectUnitsForPlanet()
    {
        old_planet = hit_object;

        hit_object.GetComponent<UnitManager>().Deselect();

        int count = Globals.PLANETS[hit_object].Count;

        for (int i = 0; i < count; i++){ 

            GameObject unit = Globals.PLANETS[hit_object][i];
            
            unit.GetComponent<UnitManager>().Select();
        }
        _isClicked = true;
    }

    private void _SelectSingleUnit()
    {
        old_planet = hit_object.GetComponent<PlanetGravity>().planet;
        hit_object.GetComponent<UnitManager>().Select(true);
        _isClicked = true;
    }

    private void _ChangePlanetForUnit()
    {
        selected_units = new List<UnitManager>(Globals.SELECTED_UNITS);

        count = selected_units.Count;

        for (int i = 0; i < count; i++)
        {
            UnitManager selected_unit = selected_units[i];

            selected_unit.Deselect();

            if (Globals.PLANETS[hit_object].Count >= hit_object.GetComponent<Planet>().MaxSpawn)
                continue;
            
            GameObject unit = selected_unit.gameObject;
            unit.GetComponent<PlanetGravity>().planet = hit_object;
            Globals.PLANETS[old_planet].Remove(unit);
            Globals.PLANETS[hit_object].Add(unit);
        }
        _isClicked = false;
    }

    private void DeselectUnits()
    {
        selected_units = new List<UnitManager>(Globals.SELECTED_UNITS);

        count = selected_units.Count;

        for (int i = 0; i < count; i++){
            UnitManager selected_unit = selected_units[i];
            selected_unit.Deselect();
        }
    }
}