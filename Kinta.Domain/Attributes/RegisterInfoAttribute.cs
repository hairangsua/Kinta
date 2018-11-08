using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Domain.Attributes
{
    /// <summary>
    /// Mỗi class được đánh dấu bằng Attribute này sẽ đọc ra 1 file confi với fullname of type. Dùng cho quá trình init tất cả các service khi start
    /// </summary>
    public class RegisterInfoAttribute : System.Attribute
    {
    }
}
