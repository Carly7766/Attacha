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

        private Subject<Unit> _onGamePlaying;
        public Observable<Unit> OnGamePlaying => _onGamePlaying;

        protected override void Awake()
        {
            base.Awake();
            RestartGame();
            _onUpdateWhilePlaying = this.UpdateAsObservable().Where(_ => isGamePlaying);
        }

        public void PlayGame()
        {
            isGamePlaying = true;
            _onGamePlaying.OnNext(Unit.Default);
            _onGamePlaying.OnCompleted();
        }

        public void RestartGame()
        {
            _onGamePlaying = new Subject<Unit>();
            isGamePlaying = false;
        }
    }
}