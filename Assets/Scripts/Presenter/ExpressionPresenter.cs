using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using App.SaveStorage;
using UnityEngine;

namespace App.Expression
{
    public class ExpressionPresenter : IExpressionPresenter, IDisposable
    {
        private IExpressionView _view;
        private IExpressionModel _model;
        private ISaveStorage _saveStorage;

        public event EventHandler<ComputePerformedParams> OnComputePerformed;
        public ExpressionPresenter(IExpressionView view, IExpressionModel model, ISaveStorage saveStorage)
        {
            _view = view;
            _model = model;
            _saveStorage = saveStorage;

            _view.ComputeRequested += OnViewComputeRequested;
            _view.OnExpressionUpdated += OnViewExpressionUpdated;

            RestoreState();
        }

        public void ClearState()
        {
            _view.SetExpression(string.Empty);
            _model.SetExpression(string.Empty);
        }

        private void RestoreState()
        {
            _view.SetExpression(_saveStorage.GetExpression());
            _model.SetExpression(_saveStorage.GetExpression());
        }

        private void OnViewComputeRequested(object sender, EventArgs e)
        {
            var success = _model.Compute(out float result);
            OnComputePerformed?.Invoke(this, new ComputePerformedParams(success, result));
        }

        private void OnViewExpressionUpdated(object sender, string e)
        {
            _model.SetExpression(e);
        }

        public void Dispose()
        {
            _view.ComputeRequested -= OnViewComputeRequested;
            _view.OnExpressionUpdated -= OnViewExpressionUpdated;
        }
    }

    public class ComputePerformedParams
    {
        public bool IsSuccessful;
        public float Value;

        public ComputePerformedParams(bool success, float value)
        {
            IsSuccessful = success;
            Value = value;
        }
    }
}