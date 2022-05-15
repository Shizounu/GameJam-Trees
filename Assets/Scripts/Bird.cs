using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public GameObject poopPrefab;
    public Transform spawnPoint;

    [SerializeField] float totalFleeTime;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 fleeToPosition;
    [SerializeField] float time;


    public float waitBeforeReturn = 25f;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Instantiate(poopPrefab, spawnPoint.position,spawnPoint.rotation);
            StartCoroutine(flee());
        }
    }

    IEnumerator flee(){
        time = 0;
        while(time < 1){
            float timeStep = 1 / totalFleeTime * Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, fleeToPosition, time);
            time += timeStep;
            yield return new WaitForSeconds(timeStep);
        }

        StartCoroutine(returnToPosition());
    }

    IEnumerator returnToPosition(){
        yield return new WaitForSeconds(waitBeforeReturn);
        this.transform.position = startPos;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPos, .25f);

        Gizmos.DrawLine(startPos,fleeToPosition);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(fleeToPosition, .25f);
    }
}
