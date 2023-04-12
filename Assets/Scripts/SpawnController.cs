using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToSpawn;

    CircleCollider2D circleCollider;

    public float interval = 5;
    private int max_count = 0;
    int current_count = 0;

    Vector3 _spawnPosition;

    GameObject my_gameobject;

    GameObject _Planet; 

    void Start()
    {
        _Planet = objectToSpawn.GetComponent<PlanetGravity>().planet;
        my_gameobject = this.gameObject;
        max_count = my_gameobject.GetComponent<Planet>().MaxSpawn;
        circleCollider = GetComponent<CircleCollider2D>();
        _spawnPosition = transform.position + new Vector3(circleCollider.radius, 0, 0);
    }

    float timer;

    void Update()
    {
        current_count = Globals.PLANETS[my_gameobject].Count;
        if (my_gameobject.GetComponent<CaptureController>()._isCaptured && current_count < max_count)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                _Spawn_Planet();
                timer -= interval;
            }
        } 
    }

    void _Spawn_Planet()
    {
        objectToSpawn.GetComponent<PlanetGravity>().planet = my_gameobject;
        objectToSpawn = Instantiate(objectToSpawn, _spawnPosition, Quaternion.identity);
        Globals.PLANETS[my_gameobject].Add(objectToSpawn);
        objectToSpawn.GetComponent<UnitManager>().DisactivateCircle();
    }
}
