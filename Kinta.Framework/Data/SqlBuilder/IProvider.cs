namespace Kinta.Framework.Data
{
    public interface IProvider
    {
        string ValueToString(object value, bool quote);
    }
}