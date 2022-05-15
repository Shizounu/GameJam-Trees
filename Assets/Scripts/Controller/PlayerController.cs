using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HoldStateEnum{
    Nothing,
    Bowl,
    Water,
    Seed,
    Sapling,
    Fertilizer,
    TreeBomb
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
    public Animator animator;
    [Header("Model References")]
    public GameObject bucketModel;
    public GameObject waterModel;
    public GameObject seedModel;
    public GameObject saplingModel;
    public GameObject fertilizerModel;
    public GameObject SeedBombModel;


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

        heldItemDisplay(holdState);
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(input.dir.x, 0, input.dir.y) * Time.fixedDeltaTime * speed;
        if(movement.magnitude > 0){
            animator.SetBool("isRunning", true);
        } else animator.SetBool("isRunning", false);
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
            animator.SetBool("makesAction", true);
        }

    }

    void heldItemDisplay(HoldStateEnum hold){
        switch (hold)
        {   
            case HoldStateEnum.Nothing :
                bucketModel.SetActive(false);
                waterModel.SetActive(false);
                seedModel.SetActive(false);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.Bowl :
                bucketModel.SetActive(true);
                waterModel.SetActive(false);
                seedModel.SetActive(false);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.Water :
                bucketModel.SetActive(false);
                waterModel.SetActive(true);
                seedModel.SetActive(false);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.Seed :
                bucketModel.SetActive(false);
                waterModel.SetActive(false);
                seedModel.SetActive(true);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.Sapling :
                bucketModel.SetActive(false);
                waterModel.SetActive(false);
                seedModel.SetActive(false);
                saplingModel.SetActive(true);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.Fertilizer : 
                bucketModel.SetActive(false);
                waterModel.SetActive(false);
                seedModel.SetActive(false);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(true);
                SeedBombModel.SetActive(false);
                break;
            case HoldStateEnum.TreeBomb :
                bucketModel.SetActive(false);
                waterModel.SetActive(false);
                seedModel.SetActive(false);
                saplingModel.SetActive(false);
                fertilizerModel.SetActive(false);
                SeedBombModel.SetActive(true);
                break;
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
