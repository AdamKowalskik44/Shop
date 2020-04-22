#pragma checksum "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\Component\DropDownItemComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ac02538439a9d343eb8d46f043fe823e2fe500b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Shop.Pages.Component
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 3 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 4 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 5 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 6 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 7 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 8 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Shop;

#line default
#line hidden
#line 9 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\_Imports.razor"
using Shop.Shared;

#line default
#line hidden
#line 1 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\Component\DropDownItemComponent.razor"
using Shop.Data;

#line default
#line hidden
#line 2 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\Component\DropDownItemComponent.razor"
using Shop.Services;

#line default
#line hidden
    public partial class DropDownItemComponent : OwningComponentBase<DropDownItemService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 101 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\Component\DropDownItemComponent.razor"
       
    [Parameter]
    public CustomField CurrentCustomField { get; set; }

    [Parameter]
    public List<Category> Categories { get; set; }

    [Parameter]
    public EventCallback Close { get; set; }

    [Parameter]
    public EventCallback<CustomField> Submit { get; set; }

    private List<DropDownItem> dropDownItems;
    private DropDownItem currentDropDownItem;

    protected override void OnInitialized()
    {
        dropDownItems = Service.GetDropDownItems(CurrentCustomField.CustomFieldId);
        currentDropDownItem = new DropDownItem();
        currentDropDownItem.DropDownItemId = 0;
        currentDropDownItem.CustomFieldId = CurrentCustomField.CustomFieldId;
    }

    private void ValidSubmit()
    {
        foreach (var dropDownItem in dropDownItems)
        {
            SaveItem(dropDownItem);
        }
        Submit.InvokeAsync(CurrentCustomField);
    }

    private void SaveItem(DropDownItem dropDownItem)
    {
        var result = false;

        if (dropDownItem.DropDownItemName != null && dropDownItem.DropDownItemName != "")
        {
            if (dropDownItem.DropDownItemId > 0)
            {
                result = Service.UpdateDropDownItem(dropDownItem);
            }
            else
            {
                result = Service.CreateDropDownItem(dropDownItem);
            }
        }

        dropDownItems = Service.GetDropDownItems(CurrentCustomField.CustomFieldId);
        currentDropDownItem = new DropDownItem();
        currentDropDownItem.DropDownItemId = 0;
        currentDropDownItem.CustomFieldId = CurrentCustomField.CustomFieldId;
    }

    private void DeleteItem(DropDownItem dropDownItem)
    {
        var result = false;
        result = Service.DeleteDropDownItem(dropDownItem);
        dropDownItems = Service.GetDropDownItems(CurrentCustomField.CustomFieldId);
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591