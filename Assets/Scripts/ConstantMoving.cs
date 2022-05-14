using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoving : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 dir;
    public float moveSpeed;
    public float scrollDistance;
    [SerializeField] float track;
    private void Start() {
        transform.position = startPos;
    }

    private void Update() {
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        track += moveSpeed * Time.deltaTime;
        if(track >= scrollDistance){
            transform.position = startPos;
            track = 0;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(startPos, 1);

        Gizmos.DrawLine(startPos, startPos + dir.normalized * scrollDistance);

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, .25f);
    }
}
