using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay24
{
    public class MonadCalculator
    {
        public Dictionary<string, int> MonadValues { get; set; } = new Dictionary<string, int>();

        public void Input(string variableName, int a)
        {
            UpdateVariable(variableName, a);
        }

        public void Add(string variableName, int b)
        {
            var a = GetVariableValue(variableName);
            UpdateVariable(variableName, a + b);
        }
        public void Multiply(string variableName, int b)
        {
            var a = GetVariableValue(variableName);
            UpdateVariable(variableName, a * b);
        }

        public void Divide(string variableName, decimal b)
        {
            if (b == 0)
                return;

            var a = (decimal)GetVariableValue(variableName);
            var result = (int)Math.Round(decimal.Divide(a, b), MidpointRounding.ToZero);
            UpdateVariable(variableName, result);
        }
        public void Modulus(string variableName, int b)
        {
            var a = GetVariableValue(variableName);

            if (a < 0 || b < 0)
                return;

            UpdateVariable(variableName, a % b);
        }
        public void Equal(string variableName, int b)
        {
            var a = GetVariableValue(variableName);

            if (a == b)
            {
                UpdateVariable(variableName, 1);
                return;
            }

            UpdateVariable(variableName, 0);
        }

        private void UpdateVariable(string variableName, int value)
        {
            if (MonadValues.ContainsKey(variableName))
            {
                MonadValues[variableName] = value;
                return;
            }

            MonadValues.Add(variableName, value);
        }

        public int GetVariableValue(string variableName)
        {
            if (string.IsNullOrWhiteSpace(variableName))
                return 0;

            if (MonadValues.ContainsKey(variableName))
            {
                return MonadValues.FirstOrDefault(x => string.Equals(x.Key, variableName)).Value;
            }

            MonadValues.Add(variableName, 0);
            return 0;
        }
    }
}
