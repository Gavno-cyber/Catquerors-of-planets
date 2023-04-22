using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float interval = 5;
    float timer;

    void Update()
    {
        if (this.gameObject.GetComponent<PlanetGravity>().isLanded)
        {

            timer += Time.deltaTime;
            if (timer >= interval)
            {
                int count = Globals.PLANETS[this.gameObject.GetComponent<PlanetGravity>().planet].Count;

                for (int i = 0; i < count; i++)
                {
                    GameObject unit = Globals.PLANETS[this.gameObject.GetComponent<PlanetGravity>().planet][i];
                    Unit unit_stats = unit.GetComponent<Unit>();

                    if (unit_stats.team != this.gameObject.GetComponent<Unit>().team && unit.GetComponent<PlanetGravity>().isLanded)
                    {
                        unit_stats._TakeDamage(this.gameObject.GetComponent<Cat>().Damage);

                        if (unit_stats.HP <= 0)
                        {
                            Globals.PLANETS[unit.GetComponent<PlanetGravity>().planet].Remove(unit);
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
