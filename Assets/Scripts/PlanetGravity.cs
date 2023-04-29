using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public GameObject planet;
    Rigidbody2D rb;
    public float gravityForce;
    public float gravityDistance;

    float lookAngle;
    float dist;
    Vector3 velocity;

    private bool _landed = false;

    // Start is called before the first frame update
    void Start()
    {
        //velocity = this.gameObject.GetComponent<VelocityComponent>().Velocity;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_landed)
        {
            dist = Vector3.Distance(gameObject.transform.position, planet.transform.position);

            velocity = planet.transform.position - transform.position;

            rb.AddForce(velocity.normalized * (1.0f - dist / gravityDistance) * gravityForce);

            lookAngle = 90 + Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == planet)
            _landed = true;
        else
            _landed = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        _landed = false;
    }

    public bool isLanded { get => _landed; }
}
