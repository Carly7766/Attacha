using UnityEngine;

namespace Attacha.Scripts.Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        protected override bool DontDestroyOnLoad => true;

        protected override void Awake()
        {
            base.Awake();
            Debug.Log("test");
        }
    }
}