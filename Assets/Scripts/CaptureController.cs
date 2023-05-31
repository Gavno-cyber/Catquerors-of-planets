using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
    public bool _captured = false;
    float timer;
    public float interval = 2;
    protected PlayerData current_team;
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

        if (this_unit.HP == 0)
        {
            this_unit.Team = null;
        }
        else
        {
            current_team = this_unit.Team;
        }
    }

    void Update()
    {
        count = this.gameObject.GetComponent<PlanetManager>().Count;

        if (count > 0)
        {

            if (!_IsAnotherTeam())
            {
                if (_captured && this_unit.Team == null)
                {
                    ChangeTeam();
                }
                else
                {
                    if (Globals.PLANETS[this.gameObject][0])
                    {
                        if (Globals.PLANETS[this.gameObject][0].GetComponent<Unit>().Team != this_unit.Team)
                        {
                            UpdateCapturing();
                        }
                    }
                    //timer += Time.deltaTime;
                    //if (timer >= interval)
                    //{
                    //    UpdateCapturing();
                    //    timer -= interval;
                    //}
                }
            }
        }
        _captured = IsCaptured();
    }

    public virtual bool IsCaptured()
    {
        if (this_unit.HP == this_unit.MaxHP)
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
        bool damage = false;

        unit = Globals.PLANETS[this.gameObject][0];

        if (this_unit.HP == 0)
        {
            this_unit.SetColor(unit.GetComponent<Unit>().Team.Color);
            this_unit.ChangeHP(0.001f);
            current_team = unit.GetComponent<Unit>().Team;
        }

        if (current_team != unit.GetComponent<Unit>().Team)
        {
            damage = true;
        }
        else
        {
            damage = false;
        }

        this.gameObject.GetComponent<PlanetManager>().flag.SetActive(false);
        this.gameObject.GetComponent<FillBar>().FillCircle.SetActive(true);

        for (int i = 0; i < count; i++)
        {
            unit = units_of_planet[i];

            if (unit == null)
            {
                continue;
            }

            if (unit.GetComponent<PlanetGravity>().isLanded)
            {
                if (damage)
                {
                    this_unit.ChangeHP(unit.GetComponent<Cat>().Damage * -0.001f);
                }
                else
                {
                    this_unit.ChangeHP(0.001f);
                }
            }
        }
    }

    public void ChangeTeam()
    {
        this_unit.ChangeTeam(Globals.PLANETS[this.gameObject][Globals.PLANETS[this.gameObject].Count - 1].GetComponent<Unit>().Team);
        current_team = this_unit.Team;

        this.gameObject.GetComponent<FillBar>().FillCircle.SetActive(false);

        this.gameObject.GetComponent<PlanetManager>().flag.SetActive(true);

        this.gameObject.GetComponent<PlanetManager>().flag.GetComponent<SpriteRenderer>().color = this_unit.Team.Color;

        if (Globals.MYTEAM == this_unit.Team)
        {
            this.gameObject.GetComponent<PlanetManager>().maskCircle.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<PlanetManager>().maskCircle.SetActive(false);
        }
    }

    bool _IsAnotherTeam()
    {
        if (Globals.PLANETS.ContainsKey(this.gameObject) && Globals.PLANETS[this.gameObject] != null && Globals.PLANETS[this.gameObject].Count >= 2)
        {
            for (int i = 0; i < Globals.PLANETS[this.gameObject].Count - 1; i++)
            {
                GameObject unit = Globals.PLANETS[this.gameObject][i];
                GameObject next_unit = Globals.PLANETS[this.gameObject][i + 1];

                if (unit != null && next_unit != null && unit.scene == this.gameObject.scene && unit.GetComponent<Unit>() != null && next_unit.GetComponent<Unit>() != null)
                {
                    if (unit.GetComponent<Unit>().Team != next_unit.GetComponent<Unit>().Team)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}