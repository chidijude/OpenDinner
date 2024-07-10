using OpenDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; }
        public Rating(double value)
        {
            Value = value;
        }

        public static Rating CreateUnique(double rating = 0) => new( rating);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
