using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCapture : CaptureController
{
    public override bool CanSpawn()
    {
        if (this_unit.HP == this_unit.MaxHP && current_team != "")
        {
            EventManager.TriggerEvent("PlanetCaptured");
            return true;
        }
        else
        {
            return false;
        }
    }
}
