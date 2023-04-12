using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
    public bool _isCaptured = false;
    float timer;
    public float interval = 2;
    public int _health = 0;

    void Start()
    {
        _health = this.gameObject.GetComponent<Unit>().HP;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
