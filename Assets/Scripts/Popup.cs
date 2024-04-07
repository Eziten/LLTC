using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Popup<T> : SingleTon<T>
{
    [SerializeField] GameObject[] _PopupLayout;

    public void Close()
    {
        for (int i = 0; i < _PopupLayout.Length; i++)
        {
            _PopupLayout[i].SetActive(false);
        }
    }

    public void Open()
    {
        for (int i = 0; i < _PopupLayout.Length; i++)
        {
            _PopupLayout[i].SetActive(true);
        }
    }

}
