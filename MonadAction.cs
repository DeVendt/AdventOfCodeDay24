using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay24
{
    public class MonadAction
    {
        public MonadActionEnum ActionName { get; set; }
        public string VariableName { get; set; }
        private string Value { get; set; }

        public int GetValueAsInt => int.Parse(Value);
        public string GetValueAsVariable => Value;

        private bool? isInt { get; set; }
        public bool ValueIsInt
        {
            get
            {
                if (isInt == null)
                {
                    isInt = int.TryParse(Value, out _);
                }

                return (bool)isInt;
            }
        }

        public MonadAction(string monadAction)
        {
            var props = monadAction.Split(" ");

            for (int i = 0; i < props.Length; i++)
            {
                bool cont = false;
                switch (i)
                {
                    case 0:
                        var succes = Enum.TryParse<MonadActionEnum>(props[i], true, out MonadActionEnum result);
                        if (succes)
                        {
                            ActionName = result;
                            break;
                        }

                        cont = true;
                        break;
                    case 1: VariableName = props[i]; break;
                    case 2: Value = props[i]; break;
                }

                if (cont)
                    break;
            }
        }
    }
}
