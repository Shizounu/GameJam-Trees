using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionPoint : MonoBehaviour
{
    public void interact(){
        Debug.Log("Ouch");
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, .25f);
    }
}
