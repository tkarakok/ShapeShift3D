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
        else if (other.CompareTag("Obstacle"))
        {
            StateManager.Instance._state = State.GameOver;
        }
        else if (other.CompareTag("Finish"))
        {
            StateManager.Instance._state = State.EndGame;
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.Instance.Coin++;
        }
    }
}
