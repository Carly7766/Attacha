using UnityEngine;

namespace Attacha.Scripts.Effect
{
    public class MoveEffect : IEffect
    {
        private Vector2 _velocity = new Vector2(1.0f, 0);
        private Rigidbody2D _rigidbody;

        public void PrepareComponent(GameObject target)
        {
            _rigidbody = target.GetComponent<Rigidbody2D>();
        }

        public void Affect(float deltaTime)
        {
            _rigidbody.velocity = _velocity;
        }
    }
}