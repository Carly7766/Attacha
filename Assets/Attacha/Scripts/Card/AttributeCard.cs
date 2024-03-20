using System;
using System.Collections;
using System.Collections.Generic;
using Attacha.Scripts.Manager;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttributeCard : MonoBehaviour
{
    private RectTransform _rectTransform;
    private RectTransform _slotRectTransform;
    private Vector2 _clickPositionDiff;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _slotRectTransform = _rectTransform.parent as RectTransform;

        this.GetAsyncBeginDragTrigger().Subscribe(eventData =>
        {
            _clickPositionDiff = (Vector2)CameraManager.UI.WorldToScreenPoint(_rectTransform.position) -
                                 eventData.position;
        });

        this.GetAsyncDragTrigger().Subscribe(eventData =>
        {
            _rectTransform.localPosition = GetLocalPosition(eventData.position);
        });

        this.GetAsyncEndDragTrigger().Subscribe(eventData =>
        {
            _rectTransform.position = _slotRectTransform.position;
        });
    }

    private Vector3 GetLocalPosition(Vector2 screenPosition)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_slotRectTransform,
            screenPosition + _clickPositionDiff,
            CameraManager.UI, out var localPosition);
        return localPosition;
    }
}