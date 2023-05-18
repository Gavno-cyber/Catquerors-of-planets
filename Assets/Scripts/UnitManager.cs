using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject selectionCircle;
    public GameObject maskCircle;

    public void Select() { Select(false); }

    public virtual void Select(bool clearSelection)
    {
        if (Globals.SELECTED_UNITS.Contains(this))
        {
            Deselect();
        }
        if (clearSelection)
        {
            List<UnitManager> selectedUnits = new List<UnitManager>(Globals.SELECTED_UNITS);
            foreach (UnitManager um in selectedUnits)
                um.Deselect();
        }

        Globals.SELECTED_UNITS.Add(this);
        ActivateCircle();
    }

    public void Deselect()
    {
        if (!Globals.SELECTED_UNITS.Contains(this)) return;
        Globals.SELECTED_UNITS.Remove(this);
        DisactivateCircle();
    }

    public virtual void ActivateCircle()
    {
        selectionCircle.SetActive(true);
    }

    public virtual void DisactivateCircle()
    {
        selectionCircle.SetActive(false);
    }
}