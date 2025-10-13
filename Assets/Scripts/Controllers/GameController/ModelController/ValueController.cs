using System;

internal class ValueController<T> where T : class
{
    internal event Action<T[]> onValuesChanged;
    internal event Action<T> onValueChanged;
    private T[] _values;
    private T _value;

    internal void SetValues(T[] values)
    {
        _values = values;
        onValuesChanged?.Invoke(_values);

        if (!Array.Exists(_values, i => i == _value))
            _value = values.Length > 0? values[0] : null;

        onValueChanged?.Invoke(_value);
    }

    internal T[] GetValues() => _values;

    internal void SetValue(T value)
    {
        _value = value;
        onValueChanged?.Invoke(_value);
    }

    internal T GetValue() => _value;
}
