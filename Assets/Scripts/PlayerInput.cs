using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera cam;

    UnitSelection unitSelection;

    void Start()
    {
        unitSelection = this.gameObject.GetComponent<UnitSelection>();
        cam = Camera.main;
    }

    private bool _isClicked = false;
    float lastClickTime;
    public float catchTime = 0.25f;

    Ray ray;
    RaycastHit2D hitInfo;
    GameObject hit_object;

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
                        unitSelection._SelectUnitsForPlanet(hit_object);
                        _isClicked = true;
                    }
                    else if (hit_object.CompareTag("Unit"))
                    {

                        unitSelection._SelectUnitsOfOneClass(hit_object);
                        _isClicked = true;
                    }
                    else
                    {
                        unitSelection.DeselectUnits(Globals.SELECTED_UNITS[Globals.MYTEAM]);
                        _isClicked = false;
                    }
                }
                else
                {
                    if (hit_object.CompareTag("Unit"))
                    {
                        unitSelection._SelectSingleUnit(hit_object);
                        _isClicked = true;
                    }
                    else if (hit_object.CompareTag("Planet"))
                    {
                        if (_isClicked && unitSelection.old_planet != hit_object && unitSelection.CheckDistance(hit_object))
                        {
                            unitSelection._ChangePlanetForUnit(hit_object, Globals.SELECTED_UNITS[Globals.MYTEAM]);
                            _isClicked = false;
                        }
                        else
                        {
                            unitSelection.DeselectUnits(Globals.SELECTED_UNITS[Globals.MYTEAM]);
                            hit_object.GetComponent<UnitManager>().Select();
                        }
                    }
                    else
                    {
                        unitSelection.DeselectUnits(Globals.SELECTED_UNITS[Globals.MYTEAM]);
                        _isClicked = false;
                    }
                }
                lastClickTime = Time.time;
            }
            else
            {
                unitSelection.DeselectUnits(Globals.SELECTED_UNITS[Globals.MYTEAM]);
                _isClicked = false;
            }
        }
    }
}
