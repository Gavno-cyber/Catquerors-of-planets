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

    void Start()
    {
        this_stats = this.gameObject.GetComponent<Cat>();
        planet_gravity = this.gameObject.GetComponent<PlanetGravity>();
    }
    
    PlanetGravity unit_gravity;

    void Update()
    {
        if (planet_gravity.isLanded)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                count = Globals.PLANETS[planet_gravity.planet].Count;

                for (int i = 0; i < count; i++)
                {
                    unit = Globals.PLANETS[planet_gravity.planet][i];
                    unit_gravity = unit.GetComponent<PlanetGravity>();
                    unit_stats = unit.GetComponent<Unit>();

                    if (unit_stats.team != this_stats.team && unit_gravity.isLanded)
                    {
                        unit_stats._TakeDamage(this_stats.Damage);

                        if (unit_stats.HP <= 0)
                        {
                            Globals.PLANETS[unit_gravity.planet].Remove(unit);
                            unit.GetComponent<UnitManager>().Deselect();
                            Destroy(unit);
                        }
                        break;
                    }        
                }
                timer -= interval;
            }  
        }
    }
}
