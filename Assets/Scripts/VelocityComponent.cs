using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityComponent : MonoBehaviour
{
    Vector3 velocity = new Vector3();

    public Vector3 Velocity { get => velocity; set => velocity = value; }
}
