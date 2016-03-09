using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDNVNONE
{
    public class RegisterTypeAttribute : Attribute
    {
        #region Constructors

        public RegisterTypeAttribute()
        {
            Set(null, LifeTimeManager.PerRequest);
        }

        public RegisterTypeAttribute(LifeTimeManager lifeTime)
        {
            Set(null, lifeTime);
        }
        public RegisterTypeAttribute(Type type)
        {
            Set(type, LifeTimeManager.PerRequest);
        }

        #endregion
        private void Set(Type type, LifeTimeManager lifeTime)
        {
            Type = type;
            LifeTimeManager = lifeTime;
        }
        public RegisterTypeAttribute(Type type, LifeTimeManager lifeTime)
        {
            Set(type, lifeTime);
        }
        public new Type GetType()
        {
            return Type;
        }
        public Type Type { get; protected set; }
        public LifeTimeManager LifeTimeManager { get; protected set; }
    }
    [DefaultValue(Hierarchical)]
    public enum LifeTimeManager
    {
        Transient, ContainerControlled, Hierarchical, PerRequest, PerResolve, PerThread, ExternallyControlled
    }
}
