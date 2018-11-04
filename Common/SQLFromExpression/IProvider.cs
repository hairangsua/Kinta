namespace Common
{
    public interface IProvider
    {
        TableDefinition GetTableDefinitionFor<T>();
        string ValueToString(object value, bool quote);
    }
}