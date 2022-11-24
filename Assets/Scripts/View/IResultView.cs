using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression;
using UnityEngine;

namespace App.Result
{
    public interface IResultView
    {
        event EventHandler ViewClosed;
        public void SetResult(ComputePerformedParams result);
    }
}