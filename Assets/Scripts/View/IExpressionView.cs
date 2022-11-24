using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Expression
{
    public interface IExpressionView
    {
        void SetExpression(string e);
        event EventHandler<string> OnExpressionUpdated;
        event EventHandler ComputeRequested;
    }
}