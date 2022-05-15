using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : interactionPoint
{
    [Header("Object Flags")]
    public bool hasWater;
    public bool hasFertilizer;
    public bool hasSapling;

    [Header("references")]
    public GameObject treeBombPrefab;
    public Transform spawnPoint;
    public override void interact()
    {
        if(GameController.Instance.player.holdState == HoldStateEnum.Water){
            hasWater  = true;
            GameController.Instance.player.holdState = HoldStateEnum.Nothing;
        }
        if(GameController.Instance.player.holdState == HoldStateEnum.Sapling){
            hasSapling  = true;
            GameController.Instance.player.holdState = HoldStateEnum.Nothing;
        }
        if(GameController.Instance.player.holdState == HoldStateEnum.Fertilizer){
            hasFertilizer  = true;
            GameController.Instance.player.holdState = HoldStateEnum.Nothing;
        }
    }

    private void Update() {
        if(hasWater & hasFertilizer & hasSapling){
            Instantiate(treeBombPrefab,spawnPoint.position, spawnPoint.rotation);
            hasWater= false;
            hasFertilizer= false;
            hasSapling = false;
        }
    }
}
