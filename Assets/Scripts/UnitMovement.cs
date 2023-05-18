using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Rigidbody2D rb;

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
        //transform.Translate(direction * (Time.deltaTime * speed), Space.Self);
        rb.AddRelativeForce(direction * (0.2f * speed));
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Jump(float height)
    {
        rb.AddRelativeForce(Vector3.up * height);
    }
}
