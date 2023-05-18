using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCapture : CaptureController
{
    public override bool IsCaptured()
    {
        if (this_unit.HP == this_unit.MaxHP)
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
