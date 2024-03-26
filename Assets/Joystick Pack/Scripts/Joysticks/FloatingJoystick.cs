using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    Rigidbody2D _player;
    float _playerSpeed;

    private void Update()
    {
        _player.velocity = new Vector2(Horizontal, Vertical) * _playerSpeed  * Time.deltaTime;
    }

    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);

        _player = Player.Instance.GetRigidbody();
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