    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
    public bool _canspawn = false;
    float timer;
    public float interval = 2;
    protected string current_team = "";
    int count;

    protected Unit this_unit;
    protected List<GameObject> units_of_planet;

    protected Unit team_to_change;

    void Start()
    {
        this_unit = this.gameObject.GetComponent<Unit>();
        units_of_planet = Globals.PLANETS[this.gameObject];
        current_team = this.gameObject.GetComponent<Unit>().team;
    }

    // Update is called once per frame
    void Update()
    {
        count = units_of_planet.Count;
        if (count > 0)
        {
            if (!AnotherTeamLeft())
            {
                if (current_team == "")
                {
                    ChangeTeam();
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= interval)
                    {
                        UpdateCapturing();
                        timer -= interval;
                    }
                }
            }

            if (this_unit.HP == 0)
            {
                this_unit.team = "";
                current_team = "";
            }
        }
        _canspawn = CanSpawn();
    }

    public void ChangeTeam()
    {
        team_to_change = units_of_planet[0].GetComponent<Unit>();
        this_unit.team = team_to_change.team;
        current_team = this_unit.team;
        this_unit.RestoreHP(2);
    }

    public virtual bool CanSpawn()
    {
        if (this_unit.HP == this_unit.MaxHP && current_team != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    GameObject unit;

    public void UpdateCapturing()
    {
        for (int i = 0; i < count; i++)
        {
            unit = units_of_planet[i];

            if (current_team != units_of_planet[0].GetComponent<Unit>().team)
            {
                if (unit.GetComponent<PlanetGravity>().isLanded)
                {
                    this_unit._TakeDamage(unit.GetComponent<Cat>().Damage);
                }
            }
            else
            {
                this_unit.RestoreHP(1);
            }

        }
    }

    bool is_anotherTeam;
    GameObject start_unit;

    public bool AnotherTeamLeft()
    {
        is_anotherTeam = false;

        if (count < 2){
            return is_anotherTeam;
        }

        start_unit = units_of_planet[0];

        for (int i = 0; i < count; i++)
        {
            unit = units_of_planet[i];

            if (unit != null)
            {
                if (unit.GetComponent<Unit>().team != start_unit.GetComponent<Unit>().team)
                {
                    is_anotherTeam = true;
                    break;
                }
            }
        }
        return is_anotherTeam;
    }
}
