using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float _cameraSpeed = 5.0f;

    [SerializeField] Transform _player;

    private void Update()
    {
        Vector3 _dir = _player.position - transform.position;
        Vector3 _moveVector = new Vector3(_dir.x * _cameraSpeed * Time.deltaTime, _dir.y * _cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(_moveVector);
    }
}
