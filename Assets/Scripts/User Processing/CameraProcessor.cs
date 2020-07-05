#pragma warning disable 0649
using UnityEngine;

public class CameraProcessor : MonoBehaviour
{
    [SerializeField] private Transform      _trackedObject;
    [SerializeField] private Vector3        _trackedObjectBias;
    [SerializeField] private Transform      _camera;
    [SerializeField] private AnimationCurve _cameraDistanceCurve;
    [SerializeField] private float          _cameraDistanceAttitude     = 1;
    [SerializeField] private float          _cameraAttitudeSensetivity  = 0.07f;
    [SerializeField] private float          _cameraHeight               = 15;
    [SerializeField] private float          _cameraPositionCircleRadius = 20;
    [SerializeField] private float          _cameraStartingCircleAngle  = Mathf.PI / 6;
    [SerializeField] private float          _cameraCircleAngleStep      = Mathf.PI / 300;

    private float _cameraCurrentCircleAngle;

    private Vector3 CalculatePosition()
    {
        return new Vector3 (
            _cameraPositionCircleRadius * Mathf.Sin(_cameraCurrentCircleAngle),
            _cameraHeight,
            _cameraPositionCircleRadius * Mathf.Cos(_cameraCurrentCircleAngle)
        );
    }
    
    private Vector3 CalculateCurve()
    {
        Vector3 CalculatedPosition = CalculatePosition();
        return new Vector3 (
            CalculatedPosition.x * _cameraDistanceAttitude,
            CalculatedPosition.y * _cameraDistanceCurve.Evaluate(_cameraDistanceAttitude),
            CalculatedPosition.z * _cameraDistanceAttitude
        ) + _trackedObjectBias;
    }

    private void Start()
    {
        if (_camera == null)
        {
            Debug.LogError("You need to setup Camera!");
        }
        if(_trackedObject == null)
        {
            Debug.LogError("You need to setup Tracked Object!");
        }

        _cameraCurrentCircleAngle = _cameraStartingCircleAngle;
    }
    
    private void Update()
    {
        // Camera Rotation
        if (Input.GetKey(KeybindManager.GetKeyByName(KeybindManager.KeyName.camera_left)))
        {
            _cameraCurrentCircleAngle += _cameraCircleAngleStep;
        }
        if (Input.GetKey(KeybindManager.GetKeyByName(KeybindManager.KeyName.camera_right)))
        {
            _cameraCurrentCircleAngle -= _cameraCircleAngleStep;
        }

        // Camera Distance
        _cameraDistanceAttitude -= Input.mouseScrollDelta.y * _cameraAttitudeSensetivity;
        if (_cameraDistanceAttitude > 1) _cameraDistanceAttitude = 1;
        else if (_cameraDistanceAttitude < 0.3f) _cameraDistanceAttitude = 0.3f;

        _camera.position = _trackedObject.position + CalculateCurve();
        _camera.LookAt(_trackedObject.position + _trackedObjectBias);
    }
}

