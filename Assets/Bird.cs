using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public GameObject poopPrefab;
    public Transform spawnPoint;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Instantiate(poopPrefab, spawnPoint.position,spawnPoint.rotation);
        }
    }
}
