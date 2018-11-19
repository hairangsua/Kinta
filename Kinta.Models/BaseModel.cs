using Kinta.Common.Helper;
using System;

namespace Kinta.Models
{
    public abstract class BaseModel
    {
        public void SetGuid()
        {
            ReflectionHelper.SetPropValue(this, "Id", IdHelper.NewGuid());
        }

        public void SetCreatedTime()
        {
            if (ReflectionHelper.HasProperty(this, "CreatedTime"))
            {
                ReflectionHelper.SetPropValue(this, "CreatedTime", DateTime.Now);
            }
        }

        public void SetUpdatedTime()
        {
            if (ReflectionHelper.HasProperty(this, "UpdatedTime"))
            {
                ReflectionHelper.SetPropValue(this, "UpdatedTime", DateTime.Now);
            }
        }
    }
}
