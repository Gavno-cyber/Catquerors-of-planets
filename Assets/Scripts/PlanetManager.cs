using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : UnitManager
{
    public GameObject selectionRange;

    void Start()
    {
        selectionRange.GetComponent<DrawScript>().radius = this.gameObject.GetComponent<Planet>().MaxRange;
<<<<<<< Updated upstream
=======
        selectionCircle.GetComponent<DrawScript>().radius = (this.gameObject.GetComponent<CircleCollider2D>().radius * this.gameObject.transform.localScale.x) + 0.1f;
>>>>>>> Stashed changes
    }

    public override void ActivateCircle()
    {
        selectionRange.SetActive(true);
        selectionCircle.SetActive(true);
    }

    public override void DisactivateCircle()
    {
        selectionRange.SetActive(false);
        selectionCircle.SetActive(false);
    }
}
