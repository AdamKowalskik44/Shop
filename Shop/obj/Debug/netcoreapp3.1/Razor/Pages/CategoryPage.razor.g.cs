#pragma checksum "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99921deeaad0fcc86c888a3980fa7ec852416df9"
// <auto-generated/>
#pragma warning disable 1591
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
#line 3 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
using Shop.Data;

#line default
#line hidden
#line 4 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
using Shop.Services;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/category")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/category/{Parameter1}")]
    public partial class CategoryPage : OwningComponentBase<CategoryService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container p-3");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "row");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<div class=\"col-9\">\r\n                <h3 class=\"text-primary\">Category List</h3>\r\n            </div>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-3");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "button");
            __builder.AddAttribute(14, "class", "btn btn-primary form-control");
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 16 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                       CreateCategory

#line default
#line hidden
            ));
            __builder.AddMarkupContent(16, "\r\n                    Add New Category\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\r\n");
#line 23 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (categories == null)
    {

#line default
#line hidden
            __builder.AddContent(21, "        ");
            __builder.AddMarkupContent(22, "<p><em>Loading or no categories exist</em></p>\r\n");
#line 26 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
    }
    else
    {

#line default
#line hidden
            __builder.AddContent(23, "        ");
            __builder.AddMarkupContent(24, @"<div class=""custom-control custom-switch"">
            <a style=""margin-right:40px"">Tree View</a>
            <input type=""checkbox"" class=""custom-control-input"" id=""customSwitch1"">
            <label class=""custom-control-label"" for=""customSwitch1"">List View</label>
        </div>
");
#line 34 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        if (showTree)
        {

#line default
#line hidden
            __builder.AddContent(25, "        ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "container");
            __builder.AddMarkupContent(28, "\r\n            ");
            __builder.OpenComponent<Shop.Pages.Component.CategoryTreeViewComponent>(29);
            __builder.AddAttribute(30, "categories", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<Shop.Data.Category>>(
#line 37 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                         Service.GetRootCategories()

#line default
#line hidden
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(31, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n");
#line 39 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }
        else
        {

#line default
#line hidden
            __builder.AddContent(33, "            ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "container border p-3");
            __builder.AddMarkupContent(36, "\r\n                ");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "row pt-4");
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.OpenElement(40, "table");
            __builder.AddAttribute(41, "class", "table table-striped");
            __builder.AddMarkupContent(42, "\r\n                        ");
            __builder.AddMarkupContent(43, @"<thead>
                            <tr>
                                <th>Name</th>
                                <th>Parent Category</th>
                                <th></th>
                            </tr>
                        </thead>
                        ");
            __builder.OpenElement(44, "tbody");
            __builder.AddMarkupContent(45, "\r\n");
#line 53 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                             foreach (var category in categories)
                            {

#line default
#line hidden
            __builder.AddContent(46, "                                ");
            __builder.OpenElement(47, "tr");
            __builder.AddMarkupContent(48, "\r\n                                    ");
            __builder.OpenElement(49, "td");
            __builder.AddContent(50, 
#line 56 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                         category.CategoryName

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n");
#line 57 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                     if (Service.GetCategory(category.ParentCategoryId) != null)
                                    {

#line default
#line hidden
            __builder.AddContent(52, "                                        ");
            __builder.OpenElement(53, "td");
            __builder.AddContent(54, 
#line 59 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                             Service.GetCategory(category.ParentCategoryId).CategoryName

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n");
#line 60 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                    }
                                    else
                                    {

#line default
#line hidden
            __builder.AddContent(56, "                                        ");
            __builder.AddMarkupContent(57, "<td>Root Category</td>\r\n");
#line 64 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                    }

#line default
#line hidden
            __builder.AddContent(58, "                                    ");
            __builder.OpenElement(59, "td");
            __builder.AddMarkupContent(60, "\r\n                                        ");
            __builder.OpenElement(61, "div");
            __builder.AddAttribute(62, "class", "container");
            __builder.AddMarkupContent(63, "\r\n                                            ");
            __builder.OpenElement(64, "button");
            __builder.AddAttribute(65, "class", "btn btn-primary");
            __builder.AddAttribute(66, "style", "width:250px");
            __builder.AddAttribute(67, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 67 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                          () => NavigateToCustomField(category)

#line default
#line hidden
            ));
            __builder.AddMarkupContent(68, "\r\n                                                Edit Custom Fields\r\n                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n                                            ");
            __builder.OpenElement(70, "button");
            __builder.AddAttribute(71, "class", "btn btn-primary");
            __builder.AddAttribute(72, "style", "width:150px");
            __builder.AddAttribute(73, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 70 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                          () => EditCategory(category)

#line default
#line hidden
            ));
            __builder.AddMarkupContent(74, "\r\n                                                Edit\r\n                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                                            ");
            __builder.OpenElement(76, "button");
            __builder.AddAttribute(77, "class", "btn btn-danger");
            __builder.AddAttribute(78, "style", "width:150px");
            __builder.AddAttribute(79, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 73 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                         () => DeleteCategory(category)

#line default
#line hidden
            ));
            __builder.AddMarkupContent(80, "\r\n                                                Delete\r\n                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\r\n                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n");
#line 79 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                            }

#line default
#line hidden
            __builder.AddContent(85, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n");
#line 84 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }
    }

#line default
#line hidden
            __builder.AddMarkupContent(90, "\r\n");
#line 87 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (showPopup)
    {

#line default
#line hidden
            __builder.AddContent(91, "        ");
            __builder.OpenElement(92, "div");
            __builder.AddAttribute(93, "class", "modal");
            __builder.AddAttribute(94, "tabindex", "-1");
            __builder.AddAttribute(95, "style", "display:block");
            __builder.AddAttribute(96, "role", "dialog");
            __builder.AddMarkupContent(97, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(98);
            __builder.AddAttribute(99, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#line 90 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                              currentCategory

#line default
#line hidden
            ));
            __builder.AddAttribute(100, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#line 90 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                               ValidSubmit

#line default
#line hidden
            )));
            __builder.AddAttribute(101, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(102, "\r\n                ");
                __builder2.OpenElement(103, "div");
                __builder2.AddAttribute(104, "class", "modal-dialog");
                __builder2.AddMarkupContent(105, "\r\n                    ");
                __builder2.OpenElement(106, "div");
                __builder2.AddAttribute(107, "class", "modal-content");
                __builder2.AddMarkupContent(108, "\r\n                        ");
                __builder2.OpenElement(109, "div");
                __builder2.AddAttribute(110, "class", "modal-header");
                __builder2.AddMarkupContent(111, "\r\n                            ");
                __builder2.OpenElement(112, "h3");
                __builder2.AddAttribute(113, "class", "text-info");
                __builder2.AddContent(114, 
#line 94 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                    currentCategory.CategoryId != 0 ? "Update" : "Create"

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(115, "\r\n                            ");
                __builder2.OpenElement(116, "button");
                __builder2.AddAttribute(117, "type", "button");
                __builder2.AddAttribute(118, "class", "close");
                __builder2.AddAttribute(119, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 95 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                          ClosePopup

#line default
#line hidden
                ));
                __builder2.AddMarkupContent(120, "\r\n                                ");
                __builder2.AddMarkupContent(121, "<span aria-hidden=\"true\">X</span>\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(122, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(123, "\r\n                        ");
                __builder2.OpenElement(124, "div");
                __builder2.AddAttribute(125, "class", "modal-body");
                __builder2.AddMarkupContent(126, "\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(127);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(128, "\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(129);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(130, "\r\n                            ");
                __builder2.OpenElement(131, "div");
                __builder2.AddAttribute(132, "class", "row");
                __builder2.AddMarkupContent(133, "\r\n                                ");
                __builder2.OpenElement(134, "div");
                __builder2.AddAttribute(135, "class", "col-9");
                __builder2.AddMarkupContent(136, "\r\n                                    ");
                __builder2.OpenElement(137, "div");
                __builder2.AddAttribute(138, "class", "row py-2");
                __builder2.AddMarkupContent(139, "\r\n                                        ");
                __builder2.AddMarkupContent(140, "<div class=\"col-4\">\r\n                                            Category Name\r\n                                        </div>\r\n                                        ");
                __builder2.OpenElement(141, "div");
                __builder2.AddAttribute(142, "class", "col-8");
                __builder2.AddMarkupContent(143, "\r\n                                            ");
                __builder2.OpenElement(144, "input");
                __builder2.AddAttribute(145, "class", "form-control");
                __builder2.AddAttribute(146, "type", "text");
                __builder2.AddAttribute(147, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 109 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                           currentCategory.CategoryName

#line default
#line hidden
                ));
                __builder2.AddAttribute(148, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => currentCategory.CategoryName = __value, currentCategory.CategoryName));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(149, "\r\n                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(150, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(151, "\r\n                                    ");
                __builder2.OpenElement(152, "div");
                __builder2.AddAttribute(153, "class", "row py-2");
                __builder2.AddMarkupContent(154, "\r\n                                        ");
                __builder2.AddMarkupContent(155, "<div class=\"col-4\">\r\n                                            Parent Category ID\r\n                                        </div>\r\n                                        ");
                __builder2.OpenElement(156, "div");
                __builder2.AddAttribute(157, "class", "col-8");
                __builder2.AddMarkupContent(158, "\r\n                                            ");
                __builder2.OpenElement(159, "select");
                __builder2.AddAttribute(160, "class", "form-control");
                __builder2.AddAttribute(161, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 117 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                           currentCategory.ParentCategoryId

#line default
#line hidden
                ));
                __builder2.AddAttribute(162, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => currentCategory.ParentCategoryId = __value, currentCategory.ParentCategoryId));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(163, "\r\n");
#line 118 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                 foreach (var category in categories)
                                                {

#line default
#line hidden
                __builder2.AddContent(164, "                                                    ");
                __builder2.OpenElement(165, "option");
                __builder2.AddAttribute(166, "class", "dropdown-item");
                __builder2.AddAttribute(167, "value", 
#line 120 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                          category.CategoryId

#line default
#line hidden
                );
                __builder2.AddAttribute(168, "selected", 
#line 120 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                                           category.CategoryId == category.CategoryId ? true : false

#line default
#line hidden
                );
                __builder2.AddContent(169, 
#line 120 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                                                                                                        category.CategoryName

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(170, "\r\n");
#line 121 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                }

#line default
#line hidden
                __builder2.AddContent(171, "                                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(172, "\r\n                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(173, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(174, "\r\n                                    ");
                __builder2.AddMarkupContent(175, @"<div class=""row py-2"">
                                        <div class=""col-4"">

                                        </div>
                                        <div class=""col-8"">
                                            <button class=""btn btn-primary form-control"" type=""submit"">Submit</button>
                                        </div>
                                    </div>
                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(176, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(177, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(178, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(179, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(180, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(181, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(182, "\r\n");
#line 140 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
    }

#line default
#line hidden
            __builder.AddMarkupContent(183, "\r\n");
#line 142 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (showPopupWarning)
        {

#line default
#line hidden
            __builder.AddContent(184, "            ");
            __builder.OpenElement(185, "div");
            __builder.AddAttribute(186, "class", "modal");
            __builder.AddAttribute(187, "tabindex", "-1");
            __builder.AddAttribute(188, "style", "display:block");
            __builder.AddAttribute(189, "role", "dialog");
            __builder.AddMarkupContent(190, "\r\n                ");
            __builder.OpenElement(191, "div");
            __builder.AddAttribute(192, "class", "modal-dialog");
            __builder.AddMarkupContent(193, "\r\n                    ");
            __builder.OpenElement(194, "div");
            __builder.AddAttribute(195, "class", "modal-content");
            __builder.AddMarkupContent(196, "\r\n                        ");
            __builder.OpenElement(197, "div");
            __builder.AddAttribute(198, "class", "modal-header");
            __builder.AddMarkupContent(199, "\r\n                            ");
            __builder.OpenElement(200, "h3");
            __builder.AddAttribute(201, "class", "text-primary");
            __builder.AddContent(202, 
#line 148 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                      warningMessage

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(203, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(204, "\r\n                        ");
            __builder.OpenElement(205, "div");
            __builder.AddAttribute(206, "class", "modal-body");
            __builder.AddMarkupContent(207, "\r\n                            ");
            __builder.OpenElement(208, "button");
            __builder.AddAttribute(209, "class", "btn btn-primary");
            __builder.AddAttribute(210, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 151 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                      ClosePopupWarning

#line default
#line hidden
            ));
            __builder.AddContent(211, "OK");
            __builder.CloseElement();
            __builder.AddMarkupContent(212, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(213, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(214, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(215, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(216, "\r\n");
#line 156 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }

#line default
#line hidden
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 159 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
       

    [Parameter]
    public string Parameter1
    {
        set
        {
            if (int.TryParse(value, out int result))
            {
                Category category = Service.GetCategory(result);
                if (category != null)
                {
                    EditCategory(category);
                }
            }
        }
    }

    List<Category> categories;
    Category currentCategory;

    //false = show list, true = show tree
    bool showTree = false;
    bool showPopup = false;
    bool showPopupWarning = false;
    string warningMessage = "";

    protected override void OnInitialized()
    {
        categories = Service.GetCategories();
    }

    private void CreateCategory()
    {
        currentCategory = new Category();
        currentCategory.CategoryId = 0;
        showPopup = true;
    }

    private void EditCategory(Category category)
    {
        currentCategory = category;
        showPopup = true;
    }

    private void DeleteCategory(Category category)
    {
        Service.DeleteCategory(category);
        categories = Service.GetCategories();
    }

    private void ClosePopup()
    {
        showPopup = false;
    }

    private void ValidSubmit()
    {
        var result = false;
        showPopup = false;
        Category parentCategory = Service.GetCategory(currentCategory.ParentCategoryId);

        if (currentCategory.CategoryId != 0 && currentCategory.CategoryId == parentCategory.ParentCategoryId)
        {
            ShowPopupWarning("Parent category cannot be children category!");
        }
        else
        {
            if (currentCategory.CategoryId > 0)
            {
                result = Service.UpdateCategory(currentCategory);
            }
            else
            {
                result = Service.CreateCategory(currentCategory);
            }
        }

        categories = Service.GetCategories();
    }

    private void ParentCategorySelectionChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value.ToString(), out int id))
        {
            currentCategory.ParentCategoryId = id;
        }
    }

    private void ToggleTreeView()
    {
        showTree = !showTree;
    }

    private void ShowPopupWarning(string message)
    {
        showPopupWarning = true;
        warningMessage = message;
    }

    private void ClosePopupWarning()
    {
        showPopupWarning = false;
        warningMessage = "";
    }

    private void NavigateToCustomField(Category category)
    {
        NavigationManager.NavigateTo("/CustomField/" + category.CategoryId);
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
