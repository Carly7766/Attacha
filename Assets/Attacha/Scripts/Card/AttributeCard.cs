using System.Collections.Generic;
using Attacha.Scripts.Manager;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Attacha.Scripts.Card
{
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
                _clickPositionDiff = (Vector2)CameraUtil.UI.WorldToScreenPoint(_rectTransform.position) -
                                     eventData.position;
            });

            this.GetAsyncDragTrigger().Subscribe(eventData =>
            {
                _rectTransform.localPosition = GetLocalPosition(eventData.position);

                var rayCastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, rayCastResults);

                foreach (var hit in rayCastResults)
                {
                    if (hit.gameObject.TryGetComponent(out GameView gameView))
                    {
                        var gameObject = gameView.GetGameObjectInGameView(eventData.position);
                    }
                }
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
                CameraUtil.UI, out var localPosition);
            return localPosition;
        }
    }
}