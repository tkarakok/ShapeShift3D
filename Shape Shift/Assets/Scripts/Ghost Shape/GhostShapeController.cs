using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShapeController : MonoSingleton<GhostShapeController>
{
    public Transform[] ghostPositions;
    public Transform player,referencePoint;
    private int _currentPosition = 0;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, ghostPositions[_currentPosition].position.z);
    }

    private void Update()
    {
        if (StateManager.Instance._state == State.InGame)
        {
            float distance = gameObject.transform.position.z - referencePoint.position.z;
            gameObject.transform.localScale = new Vector3(player.localScale.x, player.localScale.y, distance);
        }
        
    }

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
