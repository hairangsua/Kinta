namespace ConsoleApp
{
    public class TestAttribute
    {
        //public static Dictionary<string, string> GetDbColumns()
        //{
        //    Dictionary<string, string> _dict = new Dictionary<string, string>();

        //    PropertyInfo[] props = typeof(CategoryModel).GetProperties();
        //    foreach (PropertyInfo prop in props)
        //    {
        //        object[] attrs = prop.GetCustomAttributes(true);
        //        foreach (object attr in attrs)
        //        {
        //            DbColumnAttribute fieldName = attr as DbColumnAttribute;
        //            if (fieldName != null)
        //            {
        //                _dict.Add(prop.Name, fieldName.FieldName);
        //            }
        //        }
        //    }

        //    return _dict;
        //}

        //[RegisterInfo]
        //public class TestModel
        //{
        //    public string Code { get; set; }
        //}

        //public static IEnumerable<Type> GetClassByAttribute()
        //{
        //    try
        //    {
        //        var rs = AttributeHelper.GetTypesWithHelpAttribute(Assembly.GetExecutingAssembly(), typeof(RegisterInfoAttribute));

        //        var a = GetTypesWithHelpAttribute(Assembly.GetExecutingAssembly());

        //        return rs;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly)
        //{
        //    foreach (Type type in assembly.GetTypes())
        //    {
        //        if (type.GetCustomAttributes(typeof(RegisterInfoAttribute), true).Length > 0)
        //        {
        //            yield return type;
        //        }
        //    }
        //}
    }
}
