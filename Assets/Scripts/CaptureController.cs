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

    protected PlanetManager planet_manager;

    void Start()
    {
        planet_manager = this.gameObject.GetComponent<PlanetManager>();
        this_unit = this.gameObject.GetComponent<Unit>();
        units_of_planet = Globals.PLANETS[this.gameObject];
        current_team = this.gameObject.GetComponent<Unit>().team;
    }

    // Update is called once per frame
    void Update()
    {
        count = this.gameObject.GetComponent<PlanetManager>().Count;

        if (count > 0)
        {
            if (!this.gameObject.GetComponent<PlanetManager>().IsAnotherTeam)
            {
                if (current_team == "")
                {
                    current_team = this.gameObject.GetComponent<PlanetManager>().ChangeTeam();
                    this_unit.RestoreHP(2);
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
    GameObject start_unit;

    public void UpdateCapturing()
    {
        for (int i = 0; i < count; i++)
        {
            start_unit = units_of_planet[0];
            
            unit = units_of_planet[i];

            if (unit == null || start_unit == null)
            {
                continue;
            }
            if (current_team != start_unit.GetComponent<Unit>().team)
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
}
