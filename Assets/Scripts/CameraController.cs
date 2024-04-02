using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingleTon<CameraController>
{
    float _cameraSpeed = 5.0f;

    float sizeX;
    float sizeY;

    [SerializeField] Transform _player;
    [SerializeField] Camera _camera;

    private void Update()
    {
        Vector3 _dir = _player.position - transform.position;
        Vector3 _moveVector = new Vector3(_dir.x * _cameraSpeed * Time.deltaTime, _dir.y * _cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(_moveVector);
    }

    private void Start()
    {
        sizeX = _camera.orthographicSize * Screen.width / Screen.height;
        sizeY = _camera.orthographicSize;
    }

    public float Bottom
    {
        get
        {
            return sizeY * -1 + _camera.gameObject.transform.position.y;
        }
    }

    public float Top
    {
        get
        {
            return sizeY + _camera.gameObject.transform.position.y;
        }
    }

    public float Left
    {
        get
        {
            return sizeX * -1 + _camera.gameObject.transform.position.x;
        }
    }

    public float Right
    {
        get
        {
            return sizeX + _camera.gameObject.transform.position.x;
        }
    }
}
