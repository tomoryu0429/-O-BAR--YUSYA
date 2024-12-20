
using R3;
using System;

public class Status
{
    public Status(int value, int max)
    {
        if (value < 0 || max < 0)
        {
            throw new System.Exception($"値が0以下です value : {value},max : {max}");
        }
        if (max < value)
        {
            throw new System.Exception($"Maxがvalueよりも小さいです Value : {value}, Max : {max}");
        }
        _value = value;
        _initialValue = value;
        _max = max;
    }

    public int Value { get => _value; }
    public int Max { get => _max; }


    public Status SetValue(int value, int max)
    {
        if (value <= 0) { value = 0; }
        if (max <= 0) { max = 0; }
        if (value > max) { value = max; }
        return new Status(value, max);
    }


    public Status ChangeValue(int value_diff, int max_diff)
    {
        return SetValue(_value + value_diff, _max + max_diff);
    }

    public Status ResetValueAsInitial()
    {
        return SetValue(_initialValue, _max);
    }

    //private
    private readonly int _value;
    private readonly int _max;
    private readonly int _initialValue;


}
public class ReactiveStatus
{
    public ReactiveStatus(int value, int max)
    {
        _property = new ReactiveProperty<Status>(new Status(value, max));
    }
    ReactiveProperty<Status> _property;

    public int Value
    {
        get => _property.Value.Value;
        set
        {
            _property.Value = _property.Value.SetValue(value, _property.Value.Max);
        }
    }
    public int Max
    {
        get => _property.Value.Max;
        set
        {
            _property.Value = _property.Value.SetValue(_property.Value.Value, value);
        }
    }

    public void Reset()
    {
        _property.Value = _property.Value.ResetValueAsInitial();
    }

    public Observable<Status> Observable => _property;
}
