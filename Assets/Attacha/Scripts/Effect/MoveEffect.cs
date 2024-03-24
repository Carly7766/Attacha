using UnityEngine;

namespace Attacha.Scripts.Effect
{
    public class MoveEffect : IEffect
    {
        private Vector2 _velocity;
        private Rigidbody2D _rigidbody;

        public MoveEffect(Vector2 velocity)
        {
            _velocity = velocity;
        }

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