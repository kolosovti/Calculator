using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Expression.Compute
{
    public interface IComputeStrategy
    {
        bool Compute(string expression, out float result);
    }
}