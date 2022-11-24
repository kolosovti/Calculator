using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.SaveStorage
{
    public class PlayerPrefsSaveStorage : ISaveStorage
    {
        private void Set<T>(string key, T value)
        {
            PlayerPrefs.SetString(key, value.ToString());
        }

        private T Get<T>(string key)
        {
            return (T) Convert.ChangeType(PlayerPrefs.GetString(key), typeof(T));
        }

        public void SetExpression(string data)
        {
            Set(GetExpressionKey(), data);
        }

        public string GetExpression()
        {
            return Get<string>(GetExpressionKey());
        }

        private string GetExpressionKey()
        {
            return "expression";
        }
    }
}
