﻿using System;
using System.Linq.Expressions;

namespace Newbe.ObjectVisitor.Validator.Rules
{
    public class LessThanRule<T, TValue> : ValueRangeRuleBase<T, TValue>
        where TValue : IComparable<TValue>
    {
        public LessThanRule(TValue max)
        {
            var pExp = Expression.Parameter(typeof(TValue), "value");
            var ltExp = CreateLtExpression(pExp, max, true);
            var funcExp = Expression.Lambda<Func<TValue, bool>>(ltExp, pExp);
            MustExpression = funcExp;
            ErrorMessageExpression = (input, value, p) =>
                $"Value of {p.Name} must be < {max}, but found {value}";
        }
    }
}