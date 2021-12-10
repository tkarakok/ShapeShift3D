using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float SmoothTime = 0.3f;
    [SerializeField] private Transform _target;
    private Vector3 _offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        _offset = gameObject.transform.position - _target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.LookAt(_target);
    }
}
