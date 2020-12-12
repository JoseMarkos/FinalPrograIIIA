using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Shared.Domain.ValueObjects
{
    public class IntValueObject
    {
        protected int value;

        public IntValueObject(int value)
        {
            EnsureIsNotEmpty(this.GetType().Name, value);
            this.value = value + 1;
        }

        public int GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public void EnsureIsNotEmpty(string fieldName, int value)
        {
            if (value == -1)
            {
                throw new EmptyFieldException(fieldName);
            }
        }
    }
}
