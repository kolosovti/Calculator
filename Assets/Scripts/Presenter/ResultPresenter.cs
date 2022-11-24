using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression;
using App.Result;
using UnityEngine;

namespace App.Result
{
    public class ResultPresenter : IResultPresenter, IDisposable
    {
        private IResultView _view;
        private IResultModel _model;
        private IExpressionPresenter _expressionPresenter;

        public ResultPresenter(IResultView view, IResultModel model, IExpressionPresenter expressionPresenter)
        {
            _view = view;
            _model = model;
            _expressionPresenter = expressionPresenter;
            _expressionPresenter.OnComputePerformed += OnComputePerformed;
            _view.ViewClosed += OnViewClosed;
        }

        private void OnViewClosed(object sender, EventArgs e)
        {
            _expressionPresenter.ClearState();
        }

        private void OnComputePerformed(object sender, ComputePerformedParams result)
        {
            _model.SetResult(result);
            _view.SetResult(result);
        }

        public void Dispose()
        {
            _expressionPresenter.OnComputePerformed -= OnComputePerformed;
            _view.ViewClosed -= OnViewClosed;
        }
    }
}