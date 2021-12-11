using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShapeController : MonoSingleton<GhostShapeController>
{
    public Transform[] ghostPositions;
    private int _currentPosition = 0;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, ghostPositions[_currentPosition].position.z);
    }

    public void ChangeGhostShapeScale(Vector3 scale)
    {
        transform.localScale = scale;
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
