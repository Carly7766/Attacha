using Attacha.Scripts.Effect;
using Attacha.Scripts.Manager;
using R3;
using UnityEngine;

namespace Attacha.Scripts.Actor
{
    public class AttachableBlock : MonoBehaviour, IAttachable
    {
        private IEffect _attachedEffect;

        private void Start()
        {
            GameManager.Instance.OnUpdateWhilePlaying.Subscribe(_ =>
            {
                if (_attachedEffect != null)
                {
                    _attachedEffect.Affect(Time.deltaTime);
                }
            });
        }

        public void Attach(IEffect effect)
        {
            _attachedEffect = effect;
            _attachedEffect.PrepareComponent(gameObject);
        }
    }
}