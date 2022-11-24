using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression.Compute;
using App.SaveStorage;
using UnityEngine;

namespace App.Expression
{
    public class ExpressionModel : IExpressionModel
    {
        private string Expression;
        private ISaveStorage _saveStorage;
        private IComputeStrategy _computeStrategy;

        public ExpressionModel(IComputeStrategy computeStrategy, ISaveStorage saveStorage)
        {
            _computeStrategy = computeStrategy;
            _saveStorage = saveStorage;
        }

        public bool Compute(out float result)
        {
            return _computeStrategy.Compute(Expression, out result);
        }

        public void SetExpression(string expression)
        {
            Expression = expression;
            _saveStorage.SetExpression(expression);
        }
    }
}