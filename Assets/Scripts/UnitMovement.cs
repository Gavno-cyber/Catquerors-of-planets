using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 1;

    public Vector3 direction;

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * (Time.deltaTime * speed), Space.Self);
        transform.Translate(direction * (Time.deltaTime * speed), Space.Self);
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
