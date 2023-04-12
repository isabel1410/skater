using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private Input _input;

    private bool _grounded;
    private float _wheelSize;

    private float _speed = 150;
    Vector3 m_EulerAngleVelocity;

    [SerializeField] private LayerMask _ground;

    [SerializeField] private Rigidbody2D[] _wheels;
    private Rigidbody2D _skateBoard;

    public UnityEvent OnFlip;

    private bool _canFlip = true;
    private float _startingAngle;
    private float _currentAngle;

    private float _angle;



    private Vector2 _previousRight;

    private void Start()
    {
        _input = GetComponent<Input>();
        _wheelSize = GetComponentInChildren<CircleCollider2D>().radius;
        this.gameObject.GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0, 0);
        _skateBoard = GetComponent<Rigidbody2D>();
        m_EulerAngleVelocity = new Vector3(0, 0, -200f);
    }

    private void FixedUpdate()
    {
        _grounded = IsGrounded();
        if (_input.Accelerate && _grounded)
        {
            Accelerate();
            GetLatestAngle();
            _previousRight = transform.right;
            _angle = 0;
        }
        else if (_input.Accelerate && !_grounded)
        {
            Flip();
        }
        CalculateFlip();
    }
    private void Accelerate()
    {
        _wheels[0].AddForce(_speed * Time.fixedDeltaTime * transform.right);
        _wheels[1].AddForce(_speed * Time.fixedDeltaTime * transform.right);
        _skateBoard.AddForce(_speed * Time.fixedDeltaTime * transform.right);
    }

    private float GetLatestAngle()
    {
        return _startingAngle = Mathf.Abs(_skateBoard.transform.eulerAngles.z);
    }

    private void Flip()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        _skateBoard.MoveRotation(_skateBoard.transform.rotation * deltaRotation);
    }

    private void CalculateFlip()
    {
        Vector2 currentRight = transform.right;
        _angle += Vector2.SignedAngle(_previousRight, currentRight);

        // store the current right vector for the next frame to compare
        _previousRight = currentRight;

        // did the angle reach +/- 360 ?
        if (Mathf.Abs(_angle) >= 360f)
        {
            OnFlip?.Invoke();
            _angle -= 360f * Mathf.Sign(_angle);
        }
    }

    private bool IsGrounded()
    {
        return _grounded = Physics2D.OverlapCircle(_wheels[0].transform.position, _wheelSize, _ground) || Physics2D.OverlapCircle(_wheels[1].transform.position, _wheelSize, _ground);
    }
}
