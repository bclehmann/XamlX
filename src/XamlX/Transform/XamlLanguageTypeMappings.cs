using System;
using System.Collections.Generic;
using XamlX.TypeSystem;

namespace XamlX.Transform
{
    public class XamlLanguageTypeMappings
    {
        public XamlLanguageTypeMappings(IXamlTypeSystem typeSystem)
        {
            ServiceProvider = typeSystem.FindType("System.IServiceProvider");
            TypeDescriptorContext = typeSystem.FindType("System.ComponentModel.ITypeDescriptorContext");
            SupportInitialize = typeSystem.FindType("System.ComponentModel.ISupportInitialize");
            var tconv = typeSystem.FindType("System.ComponentModel.TypeConverterAttribute");
            if (tconv != null)
                TypeConverterAttributes.Add(tconv);
        }

        public List<IXamlType> XmlnsAttributes { get; set; } = new List<IXamlType>();
        public List<IXamlType> UsableDuringInitializationAttributes { get; set; } = new List<IXamlType>();
        public List<IXamlType> ContentAttributes { get; set; } = new List<IXamlType>();
        public List<IXamlType> TypeConverterAttributes { get; set; } = new List<IXamlType>();
        public IXamlType ServiceProvider { get; set; }
        public IXamlType TypeDescriptorContext { get; set; }
        public IXamlType SupportInitialize { get; set; }
        public IXamlType ProvideValueTarget { get; set; }
        public IXamlType RootObjectProvider { get; set; }
        public IXamlType ParentStackProvider { get; set; }
        public IXamlCustomAttributeResolver CustomAttributeResolver { get; set; }
        /// <summary>
        /// Expected signature:
        /// static void ApplyNonMatchingMarkupExtension(object target, object property, IServiceProvider prov, object value)
        /// </summary>
        public IXamlMethod MarkupExtensionCustomResultHandler { get; set; }
        public List<IXamlType> MarkupExtensionCustomResultTypes { get; set; } = new List<IXamlType>();
        public Func<IXamlProperty, IXamlType, bool> ShouldIgnoreMarkupExtensionCustomResultForProperty { get; set; }
        
        /// <summary>
        /// Expected signature:
        /// static IServiceProvider InnerServiceProviderFactory(IServiceProvider self);
        /// </summary>
        public IXamlMethod InnerServiceProviderFactoryMethod { get; set; }
    }

    public interface IXamlCustomAttributeResolver
    {
        IXamlCustomAttribute GetCustomAttribute(IXamlType type, IXamlType attributeType);
        IXamlCustomAttribute GetCustomAttribute(IXamlProperty property, IXamlType attributeType);
    }
}