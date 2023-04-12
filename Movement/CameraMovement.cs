using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _distance = 25;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, _target.position.z - _distance);
    }
}
