using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject selectionCircle;
    public GameObject maskCircle;

    protected PlayerData team;

    public void Select() { Select(false); }

    public virtual void Select(bool clearSelection)
    {
        if (Globals.SELECTED_UNITS[team].Contains(this))
        {
            Deselect();
        }
        if (clearSelection)
        {
            List<UnitManager> selectedUnits = new List<UnitManager>(Globals.SELECTED_UNITS[team]);
            foreach (UnitManager um in selectedUnits)
                um.Deselect();
        }

        Globals.SELECTED_UNITS[team].Add(this);
        ActivateCircle();
    }

    public virtual void Deselect()
    {
        if (!Globals.SELECTED_UNITS[team].Contains(this)) return;
        Globals.SELECTED_UNITS[team].Remove(this);
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