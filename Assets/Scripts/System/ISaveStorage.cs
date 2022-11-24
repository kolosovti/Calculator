using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.SaveStorage
{
    public interface ISaveStorage
    {
        void SetExpression(string data);
        string GetExpression();
    }
}