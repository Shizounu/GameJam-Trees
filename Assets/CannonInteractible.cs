using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInteractible : interactionPoint
{
    public ParticleSystem boom;
    public override void interact()
    {
        if(GameController.Instance.player.holdState == HoldStateEnum.TreeBomb){
            boom.Play();
            GameController.Instance.player.holdState = HoldStateEnum.Nothing;
        }

    }
}
