using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _length;

    private Ball _ball;
    private Kernel _kernel;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _kernel = FindObjectOfType<Kernel>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position; 
        }
    }
    private void TrackBall()
    {
        Vector3 kernelPosition = _kernel.transform.position;
        kernelPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (kernelPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _length;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
