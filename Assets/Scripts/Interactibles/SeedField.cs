using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedField : interactionPoint
{
    [Header("Stats")]
    [SerializeField] private bool _hasSeed;
    public bool hasSeed{
        get {return _hasSeed;}
        set{
            _hasSeed = value;
            if(_hasSeed)
                seedVisual.SetActive(true);
            else 
                seedVisual.SetActive(false);
        }
    }
    public float totalTime = 10;

    [Header("Debug Values/references")]
    public float growTime; //in seconds
    public GameObject saplingPrefab;
    public Transform spawnPosition;
    public GameObject seedVisual;
    public Animator seedAnimator;

    public override void interact(){
        if(GameController.Instance.player.holdState == HoldStateEnum.Seed){
            hasSeed = true;
            startVisualAnim();
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


    private void startVisualAnim(){
        seedAnimator.SetFloat("AnimSpeed", 1 / totalTime);
        seedAnimator.Play("Leaf Growing");
    }   
}
