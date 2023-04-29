using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float interval = 5;
    float timer;

    int count;
    GameObject unit;
    Unit unit_stats;
    Cat this_stats;

    PlanetGravity planet_gravity;
    PlanetManager planet_manager;

    List<GameObject> units;

    bool is_busy = false;

    void Start()
    {
        this_stats = this.gameObject.GetComponent<Cat>();

        planet_gravity = this.gameObject.GetComponent<PlanetGravity>();

        planet_manager = planet_gravity.planet.GetComponent<PlanetManager>();

        units = Globals.PLANETS[planet_gravity.planet];
    }
    
    PlanetGravity unit_gravity;

    GameObject unit_to_damage;

    float min_dist;
    float dist;

    void Update()
    {
        if (planet_gravity.isLanded)
        {
            if (planet_gravity.planet.GetComponent<PlanetManager>().IsAnotherTeam)
            {
                if (is_busy)
                {
                    if (unit_to_damage != null)
                    {
                        if (IsWithinRange(unit_to_damage))
                        {
                            timer += Time.deltaTime;
                            if (timer >= interval)
                            {
                                AttackEnemy();
                                timer -= interval;
                            }
                        }
                        else
                        {
                            ReachToEnemy();
                        }
                    }
                }
                else
                {
                    FindEnemy();
                }
            }
        }
    }

    public void FindEnemy()
    {
        min_dist = 100;
        unit_to_damage = null;

        count = planet_gravity.planet.GetComponent<PlanetManager>().Count;
        units = Globals.PLANETS[planet_gravity.planet];

        for (int i = 0; i < count - 1; i++)
        {
            unit = units[i];

            if (unit == null)
            {
                continue;
            }
            unit_gravity = unit.GetComponent<PlanetGravity>();
            unit_stats = unit.GetComponent<Unit>();

            if (unit_stats.team != this_stats.team && unit_gravity.isLanded)
            {
                dist = Vector3.Distance(this.gameObject.transform.position, unit.transform.position);

                if (dist < min_dist)
                {
                    unit_to_damage = unit;
                    min_dist = dist;
                }
            }
        }
        if (unit_to_damage)
            is_busy = true;
    }

    public void ReachToEnemy()
    {
        float sign = Mathf.Sign(this.gameObject.transform.localPosition.x - unit_to_damage.transform.localPosition.x);

        if (sign == 1)
        {
            this.gameObject.GetComponent<UnitMovement>().SetDirection(Vector3.right);
        }
        else if (sign == -1)
        {
            this.gameObject.GetComponent<UnitMovement>().SetDirection(Vector3.left);
        }

        this.gameObject.GetComponent<UnitMovement>().Speed = 2;
    }
        
    public bool IsWithinRange(GameObject unit)
    {
        this.gameObject.GetComponent<UnitMovement>().Speed = 0;
        this.gameObject.GetComponent<UnitMovement>().SetDirection(Vector3.zero);
        return Vector3.Distance(this.gameObject.transform.position, unit.transform.position) < 1.15f;
    }

    public void AttackEnemy()
    {
        if (unit_to_damage)
            ApplyDamage(unit_to_damage);
    }

    public void ApplyDamage(GameObject unit)
    {
        if (unit_stats.HP <= 0)
        {
            unit_to_damage = null;
            planet_manager.RemoveUnit(unit);
            unit.GetComponent<UnitManager>().Deselect();
            Destroy(unit);
            is_busy = false;
        }
        unit_stats._TakeDamage(this_stats.Damage);
    }
}
