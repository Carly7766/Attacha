using System;
using UnityEngine;

namespace Attacha.Scripts.Actor
{
    public class Flag : MonoBehaviour
    {
        [SerializeField] private GameObject clearText;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                clearText.SetActive(true);
            }
        }
    }
}