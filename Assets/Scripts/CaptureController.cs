using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
<<<<<<< Updated upstream
    public bool _isCaptured = false;
    float timer;
    public float interval = 2;
    public int _health = 0;

    void Start()
    {
        _health = this.gameObject.GetComponent<Unit>().HP;
=======
    public bool _canspawn = false;
    float timer;
    public float interval = 2;

    string current_team = "";

    void Start()
    {
        current_team = this.gameObject.GetComponent<Unit>().team;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (!_isCaptured && Globals.PLANETS[this.gameObject].Count > 0)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                int count = Globals.PLANETS[this.gameObject].Count;

                for (int i = 0; i < count; i++)
                {
                    GameObject unit = Globals.PLANETS[this.gameObject][i];

                    if (unit.GetComponent<PlanetGravity>().isLanded)
                    {
                        this.gameObject.GetComponent<Unit>()._TakeDamage(unit.GetComponent<Cat>().Damage);
                        _health = this.gameObject.GetComponent<Unit>().HP;
                    }
                }
            }
            if (_health <= 0){
                _isCaptured = true;
            }
        }
=======
        if (Globals.PLANETS[this.gameObject].Count > 0)
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

            if (this.gameObject.GetComponent<Unit>().HP == 0)
            {
                this.gameObject.GetComponent<Unit>().team = "";
                current_team = "";
            }
        }
        _canspawn = CanSpawn();
    }


    public void ChangeTeam()
    {
        this.gameObject.GetComponent<Unit>().team = Globals.PLANETS[this.gameObject][0].GetComponent<Unit>().team;
        current_team = this.gameObject.GetComponent<Unit>().team;
        this.gameObject.GetComponent<Unit>().RestoreHP(2);
    }

    public bool CanSpawn()
    {
        if (this.gameObject.GetComponent<Unit>().HP == this.gameObject.GetComponent<Unit>().MaxHP && !_canspawn && current_team != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateCapturing()
    {
        int count = Globals.PLANETS[this.gameObject].Count;

        for (int i = 0; i < count; i++)
        {
            GameObject unit = Globals.PLANETS[this.gameObject][i];

            if (current_team != Globals.PLANETS[this.gameObject][0].GetComponent<Unit>().team)
            {
                if (unit.GetComponent<PlanetGravity>().isLanded)
                {
                    this.gameObject.GetComponent<Unit>()._TakeDamage(unit.GetComponent<Cat>().Damage);
                }
            }
            else
            {
                this.gameObject.GetComponent<Unit>().RestoreHP(1);
            }

        }
    }

    public bool AnotherTeamLeft()
    {
        bool is_anotherTeam = false;

        int count = Globals.PLANETS[this.gameObject].Count;

        if (count <= 1){
            return is_anotherTeam;
        }

        GameObject start_unit = Globals.PLANETS[this.gameObject][0];

        for (int i = 0; i < count; i++)
        {
            GameObject unit = Globals.PLANETS[this.gameObject][i];

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
>>>>>>> Stashed changes
    }
}
