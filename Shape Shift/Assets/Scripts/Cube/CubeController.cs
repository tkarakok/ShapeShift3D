using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoSingleton<CubeController>
{
    #region Properties Move System

    private float _speed = 5;
    #endregion

    #region Shape Shift Properties
    
    private float _duration = 5;
    #endregion

    private void Update()
    {
        #region Cube Movement

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _speed * Time.deltaTime);
        transform.position = newPosition;

        #endregion

        #region Shape Shift 

        Vector3 _newScale;
        float _newDelta = 0;

        if (Input.GetMouseButton(0))
        {
            _newDelta = Input.GetAxis("Mouse Y");
            _newScale = new Vector3(Mathf.Clamp(transform.localScale.x - _newDelta, .5f,3), Mathf.Clamp(transform.localScale.y + _newDelta,.5f,3), transform.localScale.z);
            transform.localScale = Vector3.Lerp(transform.localScale, _newScale, _duration);
        }

        
        #endregion
    }

}