using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : interactionPoint
{
    [Header("Object Flags")]
    public bool hasWater;
    public bool hasFertilizer;
    public bool hasSeed;

    [Header("references")]
    public GameObject treeBombPrefab;
    public Transform spawnPoint;
    public override void interact()
    {
        if(GameController.Instance.player.holdState == HoldStateEnum.Water){
            hasWater  = true;
        }
    }

    private void Update() {
        if(hasWater & hasFertilizer & hasSeed){
            Instantiate(treeBombPrefab,spawnPoint.position, spawnPoint.rotation);
            hasWater= false;
            hasFertilizer= false;
            hasSeed = false;
        }
    }
}
