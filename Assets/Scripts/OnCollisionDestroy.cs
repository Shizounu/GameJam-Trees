using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
