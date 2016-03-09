using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CDNVNONE
{
    public static class CDNVNContainer
    {     

        public static IUnityContainer RegisterTypeWithAttribute(IUnityContainer container)
        {
            if (container == null) return null;
            var asemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a=>!a.FullName.StartsWith("Unity"));
            var list = asemblies.SelectMany(a => a.GetTypes());
            var typesHasRegiterTypeAttr = list.Where(t => t.IsClass && Attribute.IsDefined(t, typeof(RegisterTypeAttribute)));
            foreach (var type in typesHasRegiterTypeAttr)
            {
                var attrType = type.GetCustomAttributes<RegisterTypeAttribute>().SingleOrDefault();
                if (attrType != null)
                {
                    switch (attrType.LifeTimeManager)
                    {
                        case LifeTimeManager.Transient:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new TransientLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new TransientLifetimeManager());
                            }
                            break;
                        }
                        case LifeTimeManager.ContainerControlled:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new ContainerControlledLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new ContainerControlledLifetimeManager());
                            }
                            break;
                        }
                        case LifeTimeManager.Hierarchical:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new HierarchicalLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new HierarchicalLifetimeManager());
                            }
                            break;
                        }
                        case LifeTimeManager.PerResolve:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new PerResolveLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new PerResolveLifetimeManager());
                            }
                            break;
                        }
                        case LifeTimeManager.PerThread:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new PerThreadLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new PerThreadLifetimeManager());
                            }
                            break;
                        }
                        case LifeTimeManager.ExternallyControlled:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new ExternallyControlledLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new ExternallyControlledLifetimeManager());
                            }
                            break;
                        }
                        default:
                        {
                            if (attrType.GetType() == null)
                            {
                                container.RegisterType(type, WithName.Default(type), new PerRequestLifetimeManager());
                            }
                            else
                            {
                                container.RegisterType(attrType.GetType(), type, WithName.Default(type), new PerRequestLifetimeManager());
                            }
                            break;
                        }
                    }
                    //Container.RegisterType(cstype, type, WithName.Default(type), WithLifetime.ExternallyControlled(type));
                    //if (attrType.GetType() == null)
                    //{
                    //    container.RegisterType(type, WithName.Default(type), new HierarchicalLifetimeManager());
                    //}
                    //else
                    //{
                    //    container.RegisterType(attrType.GetType(), type, WithName.Default(type), new HierarchicalLifetimeManager());
                    //}
                }
            }
            return container;
        }
    }
}
