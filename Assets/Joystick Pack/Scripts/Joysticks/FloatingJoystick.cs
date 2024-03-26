using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    Transform _player;

    Vector3 _moveDir;
    float _playerSpeed;

    private void Update()
    {
        _moveDir = new Vector3(Horizontal, Vertical, 0).normalized;

        _player.Translate(_moveDir * _playerSpeed * Time.deltaTime);
    }

    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);

        _player = Player.Instance.GetTransform();
        _playerSpeed = Player.Instance.GetSpeed();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }


}