using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShapeController : MonoSingleton<GhostShapeController>
{
    // define transforms objects
    public Transform[] ghostPositions;
    public Transform player,referencePoint;
    private int _currentPosition = 0;

    // we equate the position of this object to the first obstacle  
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, ghostPositions[_currentPosition].position.z);
    }

    private void Update()
    {
        // calculating distance between player object to ghost object
        if (StateManager.Instance._state == State.InGame)
        {
            float distance = gameObject.transform.position.z - referencePoint.position.z;
            gameObject.transform.localScale = new Vector3(player.localScale.x, player.localScale.y, distance);
        }
        
    }

    // change location of ghost object
    public void ChangeGhostPosition()
    {
        _currentPosition++;
        if (_currentPosition < ghostPositions.Length)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ghostPositions[_currentPosition].position.z);
        }
        else
        {
            gameObject.SetActive(false);
        }
       
    }
}
