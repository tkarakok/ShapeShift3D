using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoSingleton<CubeController>
{
    // define player properties

    #region Properties Move System
    
    private float _speed = 3;
    #endregion

    #region Shape Shift Properties

    private float _duration = 5;
    #endregion

    public Animator animator;


    private void Update()
    {
        if (StateManager.Instance._state == State.InGame)
        {
            // move system for player
            #region Cube Movement
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _speed * Time.deltaTime);
            transform.position = newPosition;
            
            #endregion

            // shift system for player and ghost object
            #region Shape Shift 

            Vector3 _newScale;
            float _newDelta = 0;

            if (Input.GetMouseButton(0))
            {
                _newDelta = Input.GetAxis("Mouse Y");
                _newScale = new Vector3(Mathf.Clamp(transform.localScale.x - _newDelta, .2f, 1.6f), Mathf.Clamp(transform.localScale.y + _newDelta, .2f, 1.6f), transform.localScale.z);
                transform.localScale = Vector3.Lerp(transform.localScale, _newScale, _duration);
            }


            #endregion
        }
    }

  
}
