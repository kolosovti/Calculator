using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Expression
{
    public class ExpressionView : MonoBehaviour, IExpressionView
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _resultButton;

        public event EventHandler<string> OnExpressionUpdated = delegate { };
        public event EventHandler ComputeRequested = delegate { };

        private void Awake()
        {
            _inputField.onValueChanged.AddListener(OnInputChanged);
            _resultButton.onClick.AddListener(OnResultButtonClick);
        }

        private void OnInputChanged(string e)
        {
            OnExpressionUpdated.Invoke(this, e);
        }
        
        private void OnResultButtonClick()
        {
            ComputeRequested.Invoke(this, null);
        }

        public void SetExpression(string e)
        {
            _inputField.text = e;
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveAllListeners();
            _resultButton.onClick.RemoveAllListeners();
        }
    }
}