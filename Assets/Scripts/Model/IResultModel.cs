using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression;
using UnityEngine;

namespace App.Result
{
    public interface IResultModel
    {
        void SetResult(ComputePerformedParams result);
    }
}