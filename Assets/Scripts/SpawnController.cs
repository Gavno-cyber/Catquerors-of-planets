using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objectToSpawn;

    CircleCollider2D circleCollider;

    public float interval = 5;
    private int max_count = 0;
    int current_count = 0;

    Vector3 _spawnPosition;

    List<GameObject> units_planet;

    GameObject _Planet;

    Unit this_stats;

    void Start()
    {
        _Planet = objectToSpawn.GetComponent<PlanetGravity>().planet;
        units_planet = Globals.PLANETS[this.gameObject];
        this_stats = this.GetComponent<Unit>();
        max_count = this.gameObject.GetComponent<Planet>().MaxSpawn;
        circleCollider = GetComponent<CircleCollider2D>();
        _spawnPosition = transform.position + new Vector3(circleCollider.radius, 0, 0);
    }

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            current_count = this.gameObject.GetComponent<PlanetManager>().Count;
            if (this.gameObject.GetComponent<CaptureController>()._canspawn && current_count < max_count)
            {
                _SpawnUnit();
            }
            timer -= interval;
        }
    }
    GameObject _objectToSpawn;

    void _SpawnUnit()
    {
        objectToSpawn.GetComponent<PlanetGravity>().planet = this.gameObject;
        _objectToSpawn = Instantiate(objectToSpawn, _spawnPosition, Quaternion.identity);
        _objectToSpawn.GetComponent<Unit>().team = this_stats.team;
        this.gameObject.GetComponent<PlanetManager>().AddUnit(_objectToSpawn);
        _objectToSpawn.GetComponent<UnitManager>().DisactivateCircle();
    }
}
