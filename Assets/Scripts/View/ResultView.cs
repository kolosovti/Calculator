using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Result
{
    public class ResultView : MonoBehaviour, IResultView
    {
        [SerializeField] private GameObject _successGroup;
        [SerializeField] private GameObject _failGroup;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Button _successCloseButton;
        [SerializeField] private Button _failCloseButton;
        [SerializeField] private Button _successQuitButton;
        [SerializeField] private Button _failQuitButton;

        public event EventHandler ViewClosed;

        private void Awake()
        {
            _successCloseButton.onClick.AddListener(OnCloseButtonClick);
            _failCloseButton.onClick.AddListener(OnCloseButtonClick);
            _successQuitButton.onClick.AddListener(OnQuitButtonClick);
            _failQuitButton.onClick.AddListener(OnQuitButtonClick);

            gameObject.SetActive(false);
        }

        public void SetResult(ComputePerformedParams result)
        {
            gameObject.SetActive(true);
            _successGroup.SetActive(result.IsSuccessful);
            _failGroup.SetActive(!result.IsSuccessful);
            _resultText.text = result.Value.ToString();
        }

        private void OnCloseButtonClick()
        {
            ViewClosed?.Invoke(this, null);
            gameObject.SetActive(false);
        }

        private void OnQuitButtonClick()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            _successCloseButton.onClick.RemoveAllListeners();
            _failCloseButton.onClick.RemoveAllListeners();
            _successCloseButton.onClick.RemoveAllListeners();
            _failQuitButton.onClick.RemoveAllListeners();
        }
    }
}