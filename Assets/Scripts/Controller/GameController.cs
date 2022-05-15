using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    public static GameController Instance {get; protected set;}
    public PlayerController player {get; protected set;}

    public Transform dewDropSpawn;
    public float dewDropTimer;
    public GameObject dewDropPrefab;

    public UnityEvent onGameOver;

    private void Awake() {
        if(Instance != null){
            Destroy(this);
            return;
        }
        Instance = this;

        player = FindObjectOfType<PlayerController>();
    }

    public float remainingTime = 25f;


    private void Start() {
        dewDropTimer = Random.Range(5,15);
    }

    private void Update() {
        remainingTime -= Time.deltaTime;
        dewDropTimer -= Time.deltaTime;

        if(dewDropTimer <= 0){
            dewDropTimer = Random.Range(5,15);
            Instantiate(dewDropPrefab, dewDropSpawn.position, dewDropSpawn.rotation);
        }
        if(remainingTime <= 0)
            onGameOver.Invoke();

    }
}
