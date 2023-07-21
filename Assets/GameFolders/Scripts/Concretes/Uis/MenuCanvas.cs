using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uis
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] MenuPanel menuPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleOnSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleOnSceneChanged;
        }

        private void HandleOnSceneChanged(bool isActive)
        {
            if (isActive == menuPanel.gameObject.activeSelf) return;

            menuPanel.gameObject.SetActive(isActive);
        }
    }
}