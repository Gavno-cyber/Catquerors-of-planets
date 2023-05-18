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
        current_team = this_unit.Team;
    }

    void Update()
    {
        count = this.gameObject.GetComponent<PlanetManager>().Count;

        if (count > 0)
        {
            if (Globals.PLANETS[this.gameObject][0].GetComponent<PlanetGravity>().isLanded)
            {
                if (!this.gameObject.GetComponent<PlanetManager>().IsAnotherTeam)
                {
                    if (_captured && this_unit.Team == null)
                    {
                        this_unit.ChangeTeam(Globals.PLANETS[this.gameObject][0].GetComponent<Unit>().Team);
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
                    else if (!_captured)
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
                    this_unit.Team = null;
                    current_team = null;
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
    GameObject start_unit;

    public void UpdateCapturing()
    {
        for (int i = 0; i < count; i++)
        {
            unit = units_of_planet[i];

            if (unit == null)
            {
                continue;
            }
            this.gameObject.GetComponent<FillBar>().FillCircle.SetActive(true);
            if (current_team != unit.GetComponent<Unit>().Team && current_team != null)
            {
                if (unit.GetComponent<PlanetGravity>().isLanded)
                {
                    this_unit.ChangeHP(unit.GetComponent<Cat>().Damage * -1);
                }
            }
            else
            {
                
                this_unit.SetColor(unit.GetComponent<Unit>().Team.Color);
                this_unit.ChangeHP(1);
            }
        }
    }
}
