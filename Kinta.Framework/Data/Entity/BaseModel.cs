using Kinta.Framework.Helper;
using System;

namespace Kinta.Framework.Data
{
    public enum ModelState
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }

    public abstract class BaseModel
    {
        public ModelState ModelState { get; set; }

        public void SetGuid()
        {
            ReflectionHelper.SetPropValue(this, nameof(IId.Id), IdHelper.NewGuid());
        }

        public void SetCreatedTime()
        {
            if (ReflectionHelper.HasProperty(this, nameof(IDataTime.CreatedTime)))
            {
                ReflectionHelper.SetPropValue(this, nameof(IDataTime.CreatedTime), DateTime.Now);
            }
        }

        public void SetUpdatedTime()
        {
            if (ReflectionHelper.HasProperty(this, nameof(IDataTime.UpdatedTime)))
            {
                ReflectionHelper.SetPropValue(this, nameof(IDataTime.UpdatedTime), DateTime.Now);
            }
        }
    }

    public interface IId
    {
        string Id { get; set; }
    }

    public interface IDataTime
    {
        DateTime CreatedTime { get; set; }
        DateTime UpdatedTime { get; set; }
    }
}
