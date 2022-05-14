using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedField : interactionPoint
{
    [Header("Stats")]
    public bool hasSeed;
    public float totalTime = 10;

    [Header("Debug Values")]
    public float growTime; //in seconds
    public GameObject saplingPrefab;
    public Transform spawnPosition;




    public override void interact(){
        if(GameController.Instance.player.holdState == HoldStateEnum.Seed){
            hasSeed = true;
        }
    }

    private void Start() {
        growTime = totalTime;
    }

    private void FixedUpdate() {
        if (hasSeed)
        {
            growTime -= Time.fixedDeltaTime;
            if (growTime <= 0)
            {
                growTime = totalTime;
                hasSeed = false;
                Instantiate(saplingPrefab, spawnPosition.position,spawnPosition.rotation);
            }
        }
    }
    
}
