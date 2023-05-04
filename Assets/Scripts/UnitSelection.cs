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
    Ray ray;
    RaycastHit2D hitInfo;

    int count_units_for_planet;
    List<GameObject> old_planet_units;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            ray = cam.ScreenPointToRay(Input.mousePosition);
            hitInfo = Physics2D.GetRayIntersection(ray);

            if (hitInfo.collider != null) 
            {
                hit_object = hitInfo.collider.gameObject;

                if (Time.time - lastClickTime < catchTime)
                {
                    if (hit_object.CompareTag("Planet"))
                    {
                        _SelectUnitsForPlanet();
                        _isClicked = true;
                    }
                    else if (hit_object.CompareTag("Unit")) {

                        _SelectUnitsOfOneClass();
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

    GameObject unit;
    UnitManager selected_unit;


    private void _SelectUnitsForPlanet()
    {
        old_planet = hit_object;

        hit_object.GetComponent<UnitManager>().Deselect();

        int count = hit_object.GetComponent<PlanetManager>().Count;

        for (int i = 0; i < count; i++){ 

            unit = Globals.PLANETS[hit_object][i];
            
            if (unit != null)
            {
                unit.GetComponent<UnitManager>().Select();
            }
            
        }
    }

    private void _SelectUnitsOfOneClass()
    {
        old_planet = hit_object.GetComponent<PlanetGravity>().planet;

        int count = old_planet.GetComponent<PlanetManager>().Count;

        for (int i = 0; i < count; i++)
        {
            unit = Globals.PLANETS[old_planet][i];
            if (unit.GetComponent<Unit>().GetClass() == hit_object.GetComponent<Unit>().GetClass())
                unit.GetComponent<UnitManager>().Select();
        }
    }

    private void _ChangePlanetForUnit()
    {
        selected_units = new List<UnitManager>(Globals.SELECTED_UNITS);

        count = selected_units.Count;

        for (int i = 0; i < count; i++)
        {
            selected_unit = selected_units[i];

            selected_unit.Deselect();

            if (hit_object.GetComponent<PlanetManager>().Count >= hit_object.GetComponent<Planet>().MaxSpawn)
                continue;

            unit = selected_unit.gameObject;
            unit.GetComponent<PlanetGravity>().planet = hit_object;

            old_planet.GetComponent<PlanetManager>().RemoveUnit(unit);
            hit_object.GetComponent<PlanetManager>().AddUnit(unit);
        }
        _isClicked = false;
    }

    private void DeselectUnits()
    {
        selected_units = new List<UnitManager>(Globals.SELECTED_UNITS);

        count = selected_units.Count;

        for (int i = 0; i < count; i++)
        {
            selected_unit = selected_units[i];
            selected_unit.Deselect();
        }
    }

    private void _SelectSingleUnit()
    {
        old_planet = hit_object.GetComponent<PlanetGravity>().planet;
        hit_object.GetComponent<UnitManager>().Select(true);
        _isClicked = true;
    }
}