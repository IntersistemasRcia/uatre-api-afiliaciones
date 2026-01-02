namespace CleanArchitecture.Application.Models;

/// <summary>
/// Combines a value, <see cref="Value"/>, and a flag, <see cref="HasValue"/>, 
/// indicating whether or not that value is meaningful.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public readonly struct Optional<T>
{
    /// <summary>
    /// Constructs an <see cref="Optional{T}"/> with a meaningful value.
    /// </summary>
    /// <param name="value"></param>
    public Optional(T value)
    {
        HasValue = true;
        Value = value;
    }

    /// <summary>
    /// Returns <see langword="true"/> if the <see cref="Value"/> will return a meaningful value.
    /// </summary>
    public readonly bool HasValue { get; }

    /// <summary>
    /// Gets the value of the current object.  Not meaningful unless <see cref="HasValue"/> returns <see langword="true"/>.
    /// </summary>
    /// <remarks>
    /// <para>Unlike <see cref="Nullable{T}.Value"/>, this property does not throw an exception when
    /// <see cref="HasValue"/> is <see langword="false"/>.</para>
    /// </remarks>
    /// <returns>
    /// <para>The value if <see cref="HasValue"/> is <see langword="true"/>; otherwise, the default value for type
    /// <typeparamref name="T"/>.</para>
    /// </returns>
    public readonly T Value { get; }

    /// <summary>
    /// Creates a new object initialized to a meaningful value. 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator Optional<T>(T value) => new(value);

    /// <summary>
    /// Extracts the contained value
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator T(Optional<T> value) => value.Value;

    public static bool operator ==(Optional<T>? left, Optional<T>? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Optional<T>? left, Optional<T>? right) => !(left == right);

    public static bool operator true(Optional<T> value) => value.HasValue;

    public static bool operator false(Optional<T> value) => !value.HasValue;

    /// <summary>
    /// Returns a string representation of this object.
    /// </summary>
    public override string ToString() => HasValue ? Value?.ToString() ?? "null" : "unset";

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (Optional.HasValue(obj) != HasValue) return false;
        object? value = Optional.Value(obj);
        if (!HasValue || Value == null) return value == null;
        return Value.Equals(value);
    }

    public override int GetHashCode() => HasValue ? Value?.GetHashCode() ?? 0 : 0;

    /// <summary>
    /// Gets the meaningful value of the object, <paramref name="defaultValue"/> otherwise.
    /// </summary>
    /// <param name="defaultValue">Value to return in case the contained value is not meaningful.</param>
    /// <returns>The <see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>; <paramref name="defaultValue"/> otherwise.</returns>
    public readonly T GetValueOr(T defaultValue) => HasValue ? Value : defaultValue;
}

public static class Optional
{
    public static bool HasValue(object? obj)
    {
        if (obj is null) return false;
        Type type = obj.GetType();
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Optional<>)) return true;
        return (bool)type.GetProperty(nameof(Optional<object>.HasValue))!.GetValue(obj, null)!;
    }

    public static object? Value(object? obj)
    {
        if (obj == null) return null;
        Type type = obj.GetType();
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Optional<>)) return obj;
        return type.GetProperty(nameof(Optional<object>.Value))!.GetValue(obj, null);
    }
}
