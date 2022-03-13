using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay24
{
    public class MonadService
    {
        private MonadCalculator _calculator;
        public MonadService(MonadCalculator specialMonadCalculator)
        {
            _calculator = specialMonadCalculator;
        }

        public Dictionary<string, int> MonadValues => _calculator.MonadValues;

        public string[] GetDataFromFile(string filePath)
        {
            // check if path is empty
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("Filepath is null or empty");
            } // check if file exists
            else if (!System.IO.File.Exists(filePath))
            {
                throw new Exception("File does not exist");
            }

            //then read all lines
            return System.IO.File.ReadAllLines(filePath, Encoding.UTF8);
        }

        public List<MonadAction> BuildMonadTasks(string[] lines)
        {
            // If we dont have lines we dont need to continue;
            if (!lines.Any())
            {
                return null;
            }

            List<MonadAction> listOfMonadActions = new();
            // convert all monad tasks to models.
            foreach (var line in lines)
            {
                listOfMonadActions.Add(new MonadAction(line));
            }

            return listOfMonadActions;
        }

        public void LoopMonadActions(List<MonadAction> listOfActions)
        {
            foreach (var action in listOfActions)
            {
                int secondaryValue = 0;

                // if Value has a string we find that value in that string if its null we make it zero
                if (action.GetValueAsVariable?.All(Char.IsLetter) ?? false)
                {
                    secondaryValue = _calculator.GetVariableValue(action.GetValueAsVariable);
                }

                // each monad action is a function.
                switch (action.ActionName)
                {
                    case MonadActionEnum.Inp:
                        if (action.ValueIsInt)
                        {
                            _calculator.Input(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Input(action.GetValueAsVariable ?? action.VariableName, secondaryValue);
                        break;
                    case MonadActionEnum.Mul:
                        if (action.ValueIsInt)
                        {
                            _calculator.Multiply(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Multiply(action.GetValueAsVariable ?? action.VariableName, secondaryValue);

                        break;
                    case MonadActionEnum.Mod:
                        if (action.ValueIsInt)
                        {
                            _calculator.Modulus(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Modulus(action.GetValueAsVariable ?? action.VariableName, secondaryValue);
                        break;
                    case MonadActionEnum.Div:
                        if (action.ValueIsInt)
                        {
                            _calculator.Divide(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Divide(action.GetValueAsVariable ?? action.VariableName, secondaryValue);
                        break;
                    case MonadActionEnum.Eql:
                        if (action.ValueIsInt)
                        {
                            _calculator.Equal(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Equal(action.GetValueAsVariable ?? action.VariableName, secondaryValue);
                        break;
                    case MonadActionEnum.Add:
                        if (action.ValueIsInt)
                        {
                            _calculator.Add(action.VariableName, action.GetValueAsInt);
                            break;
                        }

                        _calculator.Add(action.GetValueAsVariable ?? action.VariableName, secondaryValue);
                        break;
                }
            }
        }
    }
}
