using System;

internal class SelectionController<T> //: ISelectionController<T>
{
    internal event Action<T[]> onValuesChanged;
    internal event Action<T> onValueChanged;
    private T _value;

    internal void SetValues(T[] values)
    {
        onValuesChanged.Invoke(values);
    }

    internal void SetValue(T value)
    {
        _value = value;
        onValueChanged.Invoke(_value);
    }

    internal T GetValue()
    {
        return _value;
    }
}
