using UnityEngine;

namespace Attacha.Scripts.Manager
{
    public static class RuntimeInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeBeforeSceneLoad()
        {
            var gameObject = new GameObject("GameManager", typeof(GameManager));
        }
    }
}