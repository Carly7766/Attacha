using System;
using Attacha.Scripts.Manager;
using UnityEngine;

namespace Attacha.Scripts.Card
{
    public class GameView : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public GameObject GetGameObjectInGameView(Vector2 position)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, position, CameraUtil.UI,
                out var localClick);
            localClick.x = (_rectTransform.rect.xMin * -1) - (localClick.x * -1);
            localClick.y = (_rectTransform.rect.yMin * -1) - (localClick.y * -1);

            var viewportClick = new Vector2(localClick.x / _rectTransform.rect.size.x,
                localClick.y / _rectTransform.rect.size.y);

            var ray = CameraUtil.Main.ViewportPointToRay(new Vector3(viewportClick.x, viewportClick.y, 0));

            var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider)
            {
                return hit.collider.gameObject;
            }

            return null;
        }
    }
}