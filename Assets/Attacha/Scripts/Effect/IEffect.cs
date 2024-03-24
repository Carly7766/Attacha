using UnityEngine;

namespace Attacha.Scripts.Effect
{
    public interface IEffect
    {
        void PrepareComponent(GameObject target);
        void Affect(float deltaTime);
    }
}