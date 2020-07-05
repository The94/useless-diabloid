#pragma warning disable 0649
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementProcessor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private Camera       _mainCamera;
    [SerializeField] private float        _maxRaycastDistance = 50.0f;

    private BoxCollider[] _ground;
    private Ray          _ray;
    private RaycastHit   _hit;

    private void Start()
    {
        if (_playerAgent == null)
        {
            Debug.LogError("You need to setup Player's Navigation Mesh Agent!");
        }
        if (_mainCamera == null)
        {
            Debug.LogError("You need to setup Main Camera!");
        }

        GameObject[] all_ground_objects = GameObject.FindGameObjectsWithTag("ground");
        _ground = new BoxCollider[all_ground_objects.Length];
        for (int i = 0; i < _ground.Length; i++)
        {
            _ground[i] = all_ground_objects[i].GetComponent<BoxCollider>();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeybindManager.GetKeyByName(KeybindManager.KeyName.action_0)))
        {
            ProcessMovement();
        }
    }

    private void ProcessMovement()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        foreach(BoxCollider col in _ground)
        {
            if(col.Raycast(_ray, out _hit, _maxRaycastDistance))
            {
                _playerAgent.SetDestination(_hit.point);
                break;
            }
        }
    }
}

