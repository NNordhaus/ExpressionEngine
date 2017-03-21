using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEngine
{
    public class ExpressionEvaluator
    {
        public List<string> Tags = new List<string>();

        public bool Evaluate(string exp)
        {
            // Split on first space
            var tokens = exp.Split(new char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);

            // If just one or none, eval the tag
            if (tokens.Length < 2)
            {
                return Tags.Contains(exp);
            }

            // Pull out the left, op, right
            var left = tokens[0];
            var op = tokens[1];
            var right = tokens[2];

            switch (op)
            {
                case "&&":
                    return AND(left, right);
                    break;
                case "||":
                    return OR(left, right);
                    break;
            }

            return false;
        }

        private bool AND(string left, string right)
        {
            // Short circuit on the left
            if (!Tags.Contains(left))
            {
                return false;
            }

            return Evaluate(right);
        }

        private bool OR(string left, string right)
        {
            // Short circuit on the left
            if(Tags.Contains(left))
            {
                return true;
            }

            return Evaluate(right);
        }
    }
}