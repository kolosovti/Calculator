using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Expression
{
    public interface IExpressionModel
    {
        void SetExpression(string expression);
        bool Compute(out float result);
    }
}