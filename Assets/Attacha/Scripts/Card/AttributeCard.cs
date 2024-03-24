using System;
using System.Collections.Generic;
using System.Threading;
using Attacha.Scripts.Actor;
using Attacha.Scripts.Effect;
using Attacha.Scripts.Manager;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Attacha.Scripts.Card
{
    public class AttributeCard : MonoBehaviour
    {
        public EffectType effectType;
        public Vector2 axis;
        private IEffect _effect;
        private RectTransform _rectTransform;
        private RectTransform _slotRectTransform;
        private Vector2 _clickPositionDiff;

        private void Start()
        {
            switch (effectType)
            {
                case EffectType.Move:
                    _effect = new MoveEffect(axis);
                    break;
                case EffectType.Ghost:
                    _effect = new GhostEffect();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var source = new CancellationTokenSource();
            var token = source.Token;

            _rectTransform = GetComponent<RectTransform>();
            _slotRectTransform = _rectTransform.parent as RectTransform;

            this.GetAsyncBeginDragTrigger().Subscribe(eventData =>
            {
                _clickPositionDiff = (Vector2)CameraUtil.UI.WorldToScreenPoint(_rectTransform.position) -
                                     eventData.position;
            }).RegisterTo(token).AddTo(this);

            this.GetAsyncDragTrigger().Subscribe(eventData =>
            {
                _rectTransform.localPosition = GetLocalPosition(eventData.position);
            }).RegisterTo(token).AddTo(this);

            this.GetAsyncEndDragTrigger().Subscribe(eventData =>
            {
                _rectTransform.position = _slotRectTransform.position;

                var rayCastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, rayCastResults);

                foreach (var hit in rayCastResults)
                {
                    if (hit.gameObject.TryGetComponent(out GameView gameView))
                    {
                        var gameObject = gameView.GetGameObjectInGameView(eventData.position);
                        if (gameObject.TryGetComponent<IAttachable>(out var attachable))
                        {
                            attachable.Attach(_effect);
                            this.gameObject.SetActive(false);
                        }
                    }
                }
            }).RegisterTo(token).AddTo(this);

            GameManager.Instance.OnGamePlaying.Subscribe(_ =>
            {
                source.Cancel();
                GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
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