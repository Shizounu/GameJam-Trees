using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; protected set;}
    public PlayerController player {get; protected set;}
    private void Awake() {
        if(Instance != null){
            Destroy(this);
            return;
        }
        Instance = this;

        player = FindObjectOfType<PlayerController>();
    }
}
