namespace Common.SQLFromExpression
{
    public interface IProvider
    {
        string ValueToString(object value, bool quote);
    }
}