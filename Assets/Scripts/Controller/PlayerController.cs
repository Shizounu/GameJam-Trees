using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HoldStateEnum{
    Nothing,
    Bowl,
    Water,
    TreeBomb,
    Seed,
    Sapling,
    Fertilizer
}

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 3;
    public float interactionReach = 1;
    
    [Header("Interactable State")]
    public HoldStateEnum holdState = HoldStateEnum.Nothing;

    
    
    [Header("References")]
    public Rigidbody rb;
    InputController input;
    public Transform visualTransform;
    private void Start() {
        input = InputController.Instance;
    }
    private void Update() {
        if(input.interactionFlag){
            interact();
            input.interactionFlag = false;
        }
        if(input.clearHandFlag){
            holdState = HoldStateEnum.Nothing;
            input.clearHandFlag = false;
        }
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(input.dir.x, 0, input.dir.y) * Time.fixedDeltaTime * speed;
        rb.velocity = (movement) + new Vector3(0,rb.velocity.y,0);
        visualTransform.LookAt(transform.position + new Vector3(input.dir.x, 0, input.dir.y));
        
    }
    
    void interact(){
        interactionPoint[] interactionPoints = FindObjectsOfType<interactionPoint>();
        interactionPoint closestInRange = null;
        float dist = float.PositiveInfinity;

        foreach (interactionPoint item in interactionPoints){
            float d = Vector3.Distance(transform.position+ Vector3.up, item.transform.position);
            if(d <= interactionReach){
                if(d < dist){
                    closestInRange = item;
                    dist = d;
                }
            }
        }

        if(closestInRange != null){
            closestInRange.interact();
        }

    }


    private void OnDrawGizmos() {
        interactionPoint[] interactionPoints = FindObjectsOfType<interactionPoint>();
        foreach (interactionPoint item in interactionPoints)
        {
            Gizmos.color = (Vector3.Distance(transform.position + Vector3.up, item.transform.position) < interactionReach) ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position+ Vector3.up, item.transform.position);
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, interactionReach);
    }
}
