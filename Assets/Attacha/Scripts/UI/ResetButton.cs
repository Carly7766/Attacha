using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Attacha.Scripts.UI
{
    public class ResetButton : MonoBehaviour
    {
        private void Awake()
        {
            this.GetAsyncPointerUpTrigger().Subscribe(_ => SceneManager.LoadScene(0));
        }
    }
}