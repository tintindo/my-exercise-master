using System;
using System.Linq;
using System.Reflection;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using AutoMapper;

namespace EOffice.UnitTest
{
    public abstract class EOfficeUnitTestBase
    {
        protected EOfficeUnitTestBase()
        {
            FindAndAutoMapTypes();
        }

        private void FindAndAutoMapTypes()
        {
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + @"\EOffice.Application.dll");
            var types = assembly.GetTypes().Where(t => t.IsDefined(typeof (AutoMapAttribute)));

            foreach (var type in types)
            {
                CreateMap(type);
            }
        }

        private void CreateMap(Type type)
        {
            if (!type.IsDefined(typeof (AutoMapAttribute)))
            {
                return;
            }

            foreach (var autoMapAttribute in type.GetCustomAttributes<AutoMapAttribute>())
            {
                if (autoMapAttribute.TargetTypes.IsNullOrEmpty())
                {
                    continue;
                }

                foreach (var targetType in autoMapAttribute.TargetTypes)
                {
                    if (autoMapAttribute is AutoMapToAttribute)
                    {
                        Mapper.CreateMap(type, targetType);
                    }

                    if (autoMapAttribute is AutoMapFromAttribute)
                    {
                        Mapper.CreateMap(targetType, type);
                    }
                }
            }
        }
    }
}