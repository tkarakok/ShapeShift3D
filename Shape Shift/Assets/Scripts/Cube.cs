using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoSingleton<Cube>
{
    #region Properties

    private float _speed = 5;
    private float _limtiX = 1.5f;
    private bool _vertical = false;
    #endregion

    private void Update()
    {
        #region Cube Movement
        float newX = 0;
        float delta = 0;

        if (Input.GetMouseButton(0))
        {
            delta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + _speed * delta * Time.deltaTime * 5;
        newX = Mathf.Clamp(newX, -_limtiX, _limtiX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _speed * Time.deltaTime);
        transform.position = newPosition;
        #endregion

        #region Shape Shift 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_vertical)
            {
                _vertical = true;
                transform.position = new Vector3(transform.position.x, 1.8f, transform.position.z);
                transform.localScale = new Vector3(.5f, 3, .5f);
            }
            else
            {
                _vertical = false;
                transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
                transform.localScale = new Vector3(3, .5f, .5f);
            }
        }
        #endregion
    }




}
