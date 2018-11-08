using System;

namespace Kinta.Domain.Entities
{
    public interface IEditTime
    {

        DateTime CreatedTime { get; set; }


        DateTime UpdatedTime { get; set; }
    }
}
