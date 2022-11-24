using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace App.Expression.Compute
{
    public class DivideComputeStrategy : IComputeStrategy
    {
        private const string Pattern = @"^[0-9]+/\d+$";
        
        public bool Compute(string expression, out float result)
        {
            try
            {
                if (Regex.IsMatch(expression, Pattern))
                {
                    Parse(expression, out int numerator, out int denominator);
                    result = numerator / (float) denominator;
                    return true;
                }
                else
                {
                    result = 0f;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                result = 0f;
                return false;
            }
        }

        private void Parse(string e, out int numerator, out int denominator)
        {
            var str = e.Split("/");
            numerator = int.Parse(str[0]);
            denominator = int.Parse(str[1]);
        }
    }
}