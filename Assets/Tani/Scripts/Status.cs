
using R3;


public class Status
{
    public Status(int value, int max)
    {
        if (value < 0 || max < 0)
        {
            throw new System.Exception($"’l‚ª0ˆÈ‰º‚Å‚· value : {value},max : {max}");
        }
        if (max < value)
        {
            throw new System.Exception($"Max‚ªvalue‚æ‚è‚à¬‚³‚¢‚Å‚· Value : {value}, Max : {max}");
        }
        _value = value;
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

    //private
    private readonly int _value;
    private readonly int _max;



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

    public Observable<Status> Observable => _property;
}


