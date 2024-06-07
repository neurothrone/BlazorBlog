using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace SharedComponents;

// We specified that type must inherit from FieldCssClassProvider and must have a constructor without parameters.
// The component inherits from ComponentBase, which makes it possible to place the component inside a Blazor component.
public class CustomCssClassProvider<ProviderType> : ComponentBase where ProviderType : FieldCssClassProvider, new()
{
    [CascadingParameter]
    EditContext? CurrentEditContext { get; set; }

    public ProviderType Provider { get; set; } = new();

    protected override void OnInitialized()
    {
        if (CurrentEditContext == null)
        {
            throw new InvalidOperationException(
                $"{nameof(CustomCssClassProvider<ProviderType>)} requires a cascading parameter of type {nameof(EditContext)}. For example, you can use {nameof(CustomCssClassProvider<ProviderType>)} inside an EditForm.");
        }

        CurrentEditContext.SetFieldCssClassProvider(Provider);
    }
}