using System;
using System.Data;
using Dapper;

namespace CleanArchitecture.Infrastructure.TypeHandlers
{
    public class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
    {
        public override TimeOnly Parse(object value)
        {
            if (value is TimeOnly t) return t;
            if (value is TimeSpan ts) return TimeOnly.FromTimeSpan(ts);
            if (value is DateTime dt) return TimeOnly.FromDateTime(dt);
            if (value is string s && TimeOnly.TryParse(s, out var parsed)) return parsed;

            throw new DataException($"No se puede convertir el valor de tipo '{value?.GetType()}' a TimeOnly.");
        }

        public override void SetValue(IDbDataParameter parameter, TimeOnly value)
        {
            parameter.DbType = DbType.Time;
            parameter.Value = value.ToTimeSpan();
        }
    }
}