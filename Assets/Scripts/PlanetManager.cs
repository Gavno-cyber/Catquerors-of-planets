using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : UnitManager
{
    public GameObject selectionRange;

    private bool is_anotherTeam = false;
    private int count;

    public bool IsAnotherTeam { get => is_anotherTeam; }
    public int Count { get => count; }

    void Start()
    {
        selectionRange.GetComponent<DrawScript>().radius = this.gameObject.GetComponent<Planet>().MaxRange;
        selectionCircle.GetComponent<DrawScript>().radius = (this.gameObject.GetComponent<CircleCollider2D>().radius * this.gameObject.transform.localScale.x) + 0.1f;
    }

    public override void ActivateCircle()
    {
        selectionRange.SetActive(true);
        selectionCircle.SetActive(true);
    }

    public override void DisactivateCircle()
    {
        selectionRange.SetActive(false);
        selectionCircle.SetActive(false);
    }

    public void AddUnit(GameObject unit)
    {
        Globals.PLANETS[this.gameObject].Add(unit);
        CountUnits();
        _IsAnotherTeam();
    }

    public void RemoveUnit(GameObject unit)
    {
        Globals.PLANETS[this.gameObject].Remove(unit);
        CountUnits();
        _IsAnotherTeam();
    }

    GameObject start_unit;

    public void _IsAnotherTeam()
    {
        if (count < 2){
            return;
        }

        start_unit = Globals.PLANETS[this.gameObject][0];

        for (int i = 0; i < count; i++)
        {
            GameObject unit = Globals.PLANETS[this.gameObject][i];
            if (unit != null && start_unit != null)
            {
                if (unit.GetComponent<Unit>().team != start_unit.GetComponent<Unit>().team)
                {
                    is_anotherTeam = true;
                    return;
                }
            }
        }

        is_anotherTeam = false;
    }

    public void CountUnits()
    {
        count = Globals.PLANETS[this.gameObject].Count;
    }

    public string ChangeTeam()
    {
        Unit team_to_change = Globals.PLANETS[this.gameObject][0].GetComponent<Unit>();
        this.gameObject.GetComponent<Unit>().team = team_to_change.team;
        return this.gameObject.GetComponent<Unit>().team;
    }
}
