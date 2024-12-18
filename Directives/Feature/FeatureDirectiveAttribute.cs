using System.Reflection;
using HotChocolate.Types.Descriptors;

namespace HC14_Bug.Directives.Feature;

public class FeatureDirectiveAttribute(string name) : DescriptorAttribute
{
    protected override void TryConfigure(
        IDescriptorContext context,
        IDescriptor descriptor,
        ICustomAttributeProvider element)
    {
        switch (descriptor)
        {
            case ObjectFieldDescriptor desc:
                desc.Directive(new FeatureDirective(name));
                break;
            case InputFieldDescriptor desc:
                desc.Directive(new FeatureDirective(name));
                break;
            default:
                throw new IndexOutOfRangeException();
        }
    }
}
