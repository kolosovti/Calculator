using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Expression
{
    public interface IExpressionPresenter
    {
        event EventHandler<ComputePerformedParams> OnComputePerformed;
        void ClearState();
    }
}