using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionController : MonoBehaviour
{
    // we check collision with objects' tags
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
            PlayerPrefs.SetInt("Level", LevelManager.Instance.CurrentLevel+1);
            StateManager.Instance._state = State.EndGame;
            PlayerPrefs.SetInt("Coin", GameManager.Instance.TotalCoin + GameManager.Instance.Coin);
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.Instance.Coin++;
            Destroy(other.gameObject);
        }
    }
}
