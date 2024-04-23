using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ToastMgr : SingleTon<ToastMgr>
{
    [SerializeField]
    GameObject _canvas;
    [SerializeField]
    GameObject _toastBox;
    [SerializeField]
    TextMeshProUGUI _toastMsg;

    Vector3 _resetScale;
    string _toast;

    private void Start()
    {
        _resetScale = new Vector3(1.0f, 0.0f, 1.0f);
    }

    public void Show(string _msg)
    {
        _toast = _msg;

        Open();

        StopCoroutine("SetScreen");
        StartCoroutine("SetScreen");
    }

    public IEnumerator SetScreen()
    {
        _toastMsg.text = _toast;
        _toastBox.transform.localScale = _resetScale;

        _toastBox.transform.DOScaleY(1.0f, 0.3f);

        yield return new WaitForSeconds(2.0f);

        _toastBox.transform.DOScaleY(0.0f, 0.3f);

        yield return new WaitForSeconds(0.3f);

        Hide();
    }

    public void Open()
    {
        _canvas.SetActive(true);
    }

    public void Hide()
    {
        _canvas.SetActive(false);
    }
}
