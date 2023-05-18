using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : UnitManager
{
    public GameObject selectionRange;
    public GameObject flag;

    private bool is_anotherTeam = false;
    private int count;

    public bool IsAnotherTeam { get => is_anotherTeam; }
    public int Count { get => count; }

    [SerializeField] private string start_team;
    [SerializeField] private bool had_spawner;

    public bool HadSpawner {

        get => had_spawner;

        set
        {
            had_spawner = value; 
            if (had_spawner)
            {
                this.gameObject.GetComponent<SpawnController>().enabled = true;
            }
            else
            {
                this.gameObject.GetComponent<SpawnController>().enabled = false;
            }
        } 
    }

    void Start()
    {
        if (had_spawner)
        {
            this.gameObject.GetComponent<SpawnController>().enabled = true;
            for (int i = 0; i < Globals.PLAYERS.Count; i++) 
            {
                if (start_team == Globals.PLAYERS[i].Team)
                {
                    this.gameObject.GetComponent<Unit>().ChangeTeam(Globals.PLAYERS[i]);
                    flag.SetActive(true);
                    this.gameObject.GetComponent<FillBar>().FillCircle.SetActive(false);
                    flag.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<Unit>().Team.Color;
                }
            } 
        }
        else
        {
            this.gameObject.GetComponent<SpawnController>().enabled = false;
        }

        if (Globals.MYTEAM != this.gameObject.GetComponent<Unit>().Team)
        {
            maskCircle.SetActive(false);
        }

        float range = this.gameObject.GetComponent<Planet>().MaxRange; 

        maskCircle.transform.localScale = new Vector3(range * 4 + 1, range * 4 + 1, 1);
        selectionRange.GetComponent<DrawScript>().radius = range;
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

        for (int i = 0; i < count - 1; i++)
        {
            GameObject unit = Globals.PLANETS[this.gameObject][i];
            GameObject next_unit = Globals.PLANETS[this.gameObject][i + 1];
            if (unit != null && next_unit != null)
            {
                if (unit.GetComponent<Unit>().Team != next_unit.GetComponent<Unit>().Team)
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
}
