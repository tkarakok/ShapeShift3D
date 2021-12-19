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

        else if (other.CompareTag("GhostObstacle"))
        {
            UIManager.Instance.PerfectTextAnimation();
            GameObject ghostObstacle = other.transform.GetChild(0).gameObject;
            ghostObstacle.SetActive(true);
            ghostObstacle.transform.position += Vector3.up * 3 * Time.deltaTime;
            StartCoroutine(Anim(ghostObstacle));
            StartCoroutine(DestroyGhostObstacle(ghostObstacle));
        }

        else if (other.CompareTag("Obstacle"))
        {
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Random.Range(-5, 5), Random.Range(30, 50), Random.Range(-5, 5) * 40);
            rigidbody.useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 100);
            StartCoroutine(ChangeLayer(other.gameObject));
        }

        else if (other.CompareTag("Finish"))
        {
            GameObject childObject = gameObject.transform.GetChild(0).gameObject;
            childObject.transform.parent = null;
            childObject.transform.localScale = new Vector3(1, .8f,.2f);
            childObject.GetComponent<Animator>().SetBool("IsFinish", true);
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

    IEnumerator DestroyGhostObstacle(GameObject gameObject)
    {
        yield return new WaitForSeconds(.35f);
        gameObject.SetActive(false);
       
    }
    IEnumerator ClosePerfectText(GameObject gameObject)
    {
        yield return new WaitForSeconds(.4f);
        gameObject.SetActive(false);
    }

    IEnumerator Anim(GameObject gameObject)
    {
        while (gameObject.activeInHierarchy)
        {
            if (gameObject.transform.localScale.x > gameObject.transform.localScale.x)
            {
                gameObject.transform.localScale += new Vector3(.015f, .015f, .015f);

            }
            else
            {
                gameObject.transform.localScale += new Vector3(.015f, .015f, .015f);
            }
            gameObject.transform.position += Vector3.up * Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
    }

    
}
