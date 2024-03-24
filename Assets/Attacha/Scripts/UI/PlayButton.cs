using Attacha.Scripts.Manager;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private void Awake()
    {
        var button = GetComponent<Button>();
        button.OnClickAsObservable().Subscribe(_ => { GameManager.Instance.PlayGame(); });
    }
}