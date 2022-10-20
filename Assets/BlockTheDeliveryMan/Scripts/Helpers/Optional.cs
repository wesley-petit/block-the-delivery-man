using System;

// https://stackoverflow.com/questions/16199227/optional-return-in-c-net
public struct Optional<T>
{
    public bool HasValue { get; private set; }
    private T _value;
    public T Value
    {
        get
        {
            if (HasValue)
                return _value;
            
            throw new InvalidOperationException();
        }
    }

    public Optional(T value)
    {
        _value = value;
        HasValue = true;
    }

    public static explicit operator T(Optional<T> optional)
    {
        return optional.Value;
    }
    public static explicit operator Optional<T>(T value)
    {
        return new Optional<T>(value);
    }

    public override bool Equals(object obj)
    {
        if (obj is Optional<T> optional)
            return this.Equals(optional);
        else
            return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_value, HasValue);
    }

    public bool Equals(Optional<T> other)
    {
        if (HasValue && other.HasValue)
            return object.Equals(_value, other._value);
        else
            return HasValue == other.HasValue;
    }
}