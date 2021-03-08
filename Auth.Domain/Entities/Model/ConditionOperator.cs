using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Entities.Model
{
    public enum ConditionOperator
    {
        ArnEquals,
        ArnNotEquals,
        ArnLike,
        ArnNotLike,
        BinaryEquals,
        BinaryNotEquals,
        StringEquals,
        StringNotEquals,
        StringEqualsIgnoreCase,
        StringNotEqualsIgnoreCase,
        StringLike,
        StringNotLike,
        Null,
        NumericEquals,
        NumericNotEquals,
        NumericLessThan,
        NumericLessThanEquals,
        NumericGreaterThan,
        NumericGreaterThanEquals,
        DateEquals,
        DateNotEquals,
        DateLessThan,
        DateLessThanEquals,
        DateGreaterThan,
        DateGreaterThanEquals,
        Bool,
        IpAddress,
        NotIpAddress
    }
}
