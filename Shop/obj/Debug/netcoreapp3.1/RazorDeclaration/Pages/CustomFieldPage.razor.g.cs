#pragma checksum "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CustomFieldPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60c4e1fa8bf88be73b9262184609a97938e41ff3"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Shop.Pages
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
#line 3 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CustomFieldPage.razor"
using Shop.Data;

#line default
#line hidden
#line 4 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CustomFieldPage.razor"
using Shop.Services;

#line default
#line hidden
#line 5 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CustomFieldPage.razor"
using Shop.Pages;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/CustomField/{Parameter1}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/CustomField")]
    public partial class CustomFieldPage : OwningComponentBase<CustomFieldService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 95 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CustomFieldPage.razor"
       
    [Parameter]
    public string Parameter1
    {
        /* get
        {
            return _categoryId.ToString();
        } */
        set
        {
            if (int.TryParse(value, out int result))
            {
                _categoryId = result;
            }
            else
            {
                _categoryId = null;
            }
        }
    }
    private int? _categoryId;
    private Category category;
    private CustomField currentCustomField;
    private List<CustomField> customFields;
    private List<Category> categories;
    private bool showPopup = false;

    protected override void OnInitialized()
    {
        LoadCustomFields();
    }

    private void CreateCustomField()
    {
        currentCustomField = new CustomField();
        currentCustomField.CustomFieldId = 0;
        if (_categoryId != null)
        {
            currentCustomField.CategoryId = int.Parse(_categoryId.ToString());
        }
        ShowPopup();
    }

    private void EditCustomField(CustomField customField)
    {
        currentCustomField = customField;
        ShowPopup();
    }

    private void DeleteCustomField(CustomField customField)
    {
        var result = false;
        result = Service.DeleteCustomField(customField);
        LoadCustomFields();
    }

    private void ValidSubmit(CustomField customField)
    {
        var result = false;
        showPopup = false;

        if (currentCustomField.CustomFieldId > 0)
        {
            result = Service.UpdateCustomField(customField);
        }
        else
        {
            result = Service.CreateCustomField(customField);
        }

        LoadCustomFields();
    }

    private void ShowPopup()
    {
        categories = Service.GetCategories();
        showPopup = true;
    }

    private void ClosePopup()
    {
        showPopup = false;
    }

    private void LoadCustomFields()
    {
        if (_categoryId != null)
        {
            category = Service.GetCategory(int.Parse(_categoryId.ToString()));
            if (category != null)
            {
                customFields = Service.GetCustomFields(category.CategoryId);
            }
            else
            {
                customFields = Service.GetCustomFields();
            }
        }
        else
        {
            customFields = Service.GetCustomFields();
        }
    }

    private void NavigateToCategory(int categoryId)
    {
        NavigationManager.NavigateTo("/category/" + categoryId);
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
