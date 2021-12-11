using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            GhostShapeController.Instance.ChangeGhostPosition();
        }
    }
}
