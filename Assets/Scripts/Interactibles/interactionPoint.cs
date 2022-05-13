using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactionPoint : MonoBehaviour
{
    public abstract void interact();

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, .25f);
    }
}

