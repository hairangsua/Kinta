namespace Common.SqlBuilder
{
    public interface IProvider
    {
        string ValueToString(object value, bool quote);
    }
}