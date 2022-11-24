using System;
using System.Collections;
using System.Collections.Generic;
using App.Expression;
using UnityEngine;

namespace App.Result
{
    public class ResultModel : IResultModel
    {
        private ComputePerformedParams _result;

        public void SetResult(ComputePerformedParams result)
        {
            _result = result;
        }
    }
}