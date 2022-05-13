using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : interactionPoint
{
    public bool requirmentOverride = false;
    public HoldStateEnum required;
    public HoldStateEnum moveTo;
    public bool destroyeAfterPickup;
    public override void interact()
    {
        if(requirmentOverride || GameController.Instance.player.holdState == required){
            Debug.Log("Collected the pickup");
            GameController.Instance.player.holdState = moveTo;
            if(destroyeAfterPickup)
                Destroy(gameObject);
        }
    }
}
