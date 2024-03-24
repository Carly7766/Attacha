using R3;
using R3.Triggers;
using UnityEngine;

namespace Attacha.Scripts.Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        protected override bool DontDestroyOnLoad => true;

        private bool isGamePlaying;
        private Observable<Unit> _onUpdateWhilePlaying;
        public Observable<Unit> OnUpdateWhilePlaying => _onUpdateWhilePlaying;

        protected override void Awake()
        {
            base.Awake();
            _onUpdateWhilePlaying = this.UpdateAsObservable().Where(_ => isGamePlaying);
        }

        public void PlayGame()
        {
            isGamePlaying = true;
        }
    }
}