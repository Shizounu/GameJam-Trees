using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    public Transform pivot;

    [Header("Values")]
    public Vector2 rotationMultiplier;
    public Vector2 yawLimit; //Y Axis
    public Vector2 pitchLimit; //X AXis
    [SerializeField] private Vector2 internalPosition;
    public void move(Vector2 dir){
        if(dir.x * Time.deltaTime * rotationMultiplier.x + internalPosition.x < pitchLimit.x | 
            dir.x * Time.deltaTime * rotationMultiplier.x + internalPosition.x > pitchLimit.y){
                //Debug.Log($"{dir.x}, {dir.x * Time.deltaTime * rotationMultiplier.x}");
                dir.x = 0;
            }
        if(dir.y * Time.deltaTime * rotationMultiplier.y + internalPosition.y < yawLimit.x | 
            dir.y * Time.deltaTime * rotationMultiplier.y + internalPosition.y > yawLimit.y){
                //Debug.Log($"{dir.x}, {dir.y * Time.deltaTime * rotationMultiplier.y}");
                dir.y = 0;

            }

        pivot.Rotate(Vector3.up, dir.x * Time.deltaTime * rotationMultiplier.x);
        pivot.Rotate(pivot.right, dir.y * Time.deltaTime * rotationMultiplier.y);

        internalPosition.x += dir.x * Time.deltaTime * rotationMultiplier.x;
        internalPosition.y += dir.y * Time.deltaTime * rotationMultiplier.y;
    }

    private void LateUpdate() {
        move(InputController.Instance.mouseMovement);
        transform.LookAt(pivot, Vector3.up);
    }

}
