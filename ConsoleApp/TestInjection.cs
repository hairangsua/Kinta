using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class TestInjection
    {
        public static void Test()
        {

        }

        public class BasicInjection
        {
            //Dictionary để chứa các interface và module tương ứng
            private static readonly Dictionary<Type, object>
                       ResgisteredModules = new Dictionary<Type, object>();


            public static void SetModule<TInterface, TModule>()
            {
                SetModule(typeof(TInterface), typeof(TModule));
            }

            public static T GetModule<T>()
            {
                return (T)GetModule(typeof(T));
            }

            private static void SetModule(Type interfaceType, Type moduleType)
            {
                //Kiểm tra module đã implement interface chưa
                if (!interfaceType.IsAssignableFrom(moduleType))
                {
                    throw new Exception("Wrong Module type");
                }

                //Tìm constructor đầu tiên
                var firstConstructor = moduleType.GetConstructors()[0];
                object module = null;
                //Nếu như không có tham số
                if (!firstConstructor.GetParameters().Any())
                {
                    //Khởi tạo module
                    module = firstConstructor.Invoke(null); // new Database(), new Logger()
                }
                else
                {
                    //Lấy các tham số của constructor
                    var constructorParameters = firstConstructor.GetParameters(); //IDatebase, ILogger

                    var moduleDependecies = new List<object>();
                    foreach (var parameter in constructorParameters)
                    {
                        var dependency = GetModule(parameter.ParameterType); //Lấy module tương ứng từ DIContainer
                        moduleDependecies.Add(dependency);
                    }

                    //Inject các dependency vào constructor của module
                    module = firstConstructor.Invoke(moduleDependecies.ToArray());
                }
                //Lưu trữ interface và module tương ứng
                ResgisteredModules.Add(interfaceType, module);
            }

            private static object GetModule(Type interfaceType)
            {
                if (ResgisteredModules.ContainsKey(interfaceType))
                {
                    return ResgisteredModules[interfaceType];
                }
                throw new Exception("Module not register");
            }
        }

        public INameService GetNameService()
        {
            return new SomeService("", 1);
        }

        public IAgeService GetAgeService()
        {
            return new SomeService("", 1);
        }

        public class SomeService : INameService, IAgeService
        {
            public SomeService()
            {

            }

            public SomeService(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public void PrintName()
            {
                Console.WriteLine(Name);
            }

            public void PrintAge()
            {
                Console.WriteLine(Age);
            }

            public bool IsDefaultService(string name)
            {
                return name == "Default";
            }
        }

        public interface INameService
        {
            string Name { get; set; }

            void PrintName();

            bool IsDefaultService(string Name);
        }

        public interface IAgeService
        {
            int Age { get; set; }

            void PrintAge();
        }
    }
}
