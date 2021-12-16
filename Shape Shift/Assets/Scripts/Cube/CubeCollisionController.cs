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
            // StateManager.Instance._state = State.GameOver;
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Random.Range(-5, 5), Random.Range(30, 50), Random.Range(-5, 5) * 40);
            rigidbody.useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 40);
            StartCoroutine(ChangeLayer(other.gameObject));
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

    IEnumerator ChangeLayer(GameObject gameObject)
    {
        yield return new WaitForSeconds(.1f);
        gameObject.layer = 3;
    }


}
