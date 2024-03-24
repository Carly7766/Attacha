using UnityEngine;

namespace Attacha.Scripts.Effect
{
    public class GhostEffect : IEffect
    {
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;

        public void PrepareComponent(GameObject target)
        {
            _spriteRenderer = target.GetComponent<SpriteRenderer>();
            _collider = target.GetComponent<Collider2D>();

            _spriteRenderer.color = new Color(1, 1, 1, 0.3f);
            _collider.isTrigger = true;
        }

        public void Affect(float deltaTime)
        {
        }
    }
}