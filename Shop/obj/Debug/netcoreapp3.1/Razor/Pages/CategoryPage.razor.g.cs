#pragma checksum "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d409869132c3e020c849c7accb17756f9c045786"
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
#line 2 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
using Shop.Data;

#line default
#line hidden
#line 3 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
using Shop.Services;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/category")]
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
#line 15 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
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
#line 22 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (categories == null)
    {

#line default
#line hidden
            __builder.AddContent(21, "        ");
            __builder.AddMarkupContent(22, "<p><em>Loading or no categories exist</em></p>\r\n");
#line 25 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
    }
    else
    {

#line default
#line hidden
            __builder.AddContent(23, "        ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "custom-control custom-switch");
            __builder.AddMarkupContent(26, "\r\n            ");
            __builder.AddMarkupContent(27, "<a style=\"margin-right:40px\">Tree View</a>\r\n            ");
            __builder.OpenElement(28, "input");
            __builder.AddAttribute(29, "type", "checkbox");
            __builder.AddAttribute(30, "class", "custom-control-input");
            __builder.AddAttribute(31, "id", "customSwitch1");
            __builder.AddAttribute(32, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#line 30 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                              ToggleTreeView

#line default
#line hidden
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n            ");
            __builder.AddMarkupContent(34, "<label class=\"custom-control-label\" for=\"customSwitch1\">List View</label>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n");
#line 33 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        if (!showTree)
        {

#line default
#line hidden
            __builder.AddContent(36, "        ");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "container");
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.OpenComponent<Shop.Pages.Component.CategoryTreeViewComponent>(40);
            __builder.AddAttribute(41, "categories", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<Shop.Data.Category>>(
#line 36 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                         Service.GetRootCategories()

#line default
#line hidden
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(42, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
#line 38 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }
        else
        {

#line default
#line hidden
            __builder.AddContent(44, "            ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "container border p-3");
            __builder.AddMarkupContent(47, "\r\n                ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "row pt-4");
            __builder.AddMarkupContent(50, "\r\n                    ");
            __builder.OpenElement(51, "table");
            __builder.AddAttribute(52, "class", "table table-striped");
            __builder.AddMarkupContent(53, "\r\n                        ");
            __builder.AddMarkupContent(54, @"<thead>
                            <tr>
                                <th>Name</th>
                                <th>Parent Category</th>
                                <th></th>
                            </tr>
                        </thead>
                        ");
            __builder.OpenElement(55, "tbody");
            __builder.AddMarkupContent(56, "\r\n");
#line 52 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                             foreach (var category in categories)
                            {

#line default
#line hidden
            __builder.AddContent(57, "                                ");
            __builder.OpenElement(58, "tr");
            __builder.AddMarkupContent(59, "\r\n                                    ");
            __builder.OpenElement(60, "td");
            __builder.AddContent(61, 
#line 55 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                         category.CategoryName

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n");
#line 56 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                     if (Service.GetCategory(category.ParentCategoryId) != null)
                                    {

#line default
#line hidden
            __builder.AddContent(63, "                                        ");
            __builder.OpenElement(64, "td");
            __builder.AddContent(65, 
#line 58 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                             Service.GetCategory(category.ParentCategoryId).CategoryName

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n");
#line 59 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                    }
                                    else
                                    {

#line default
#line hidden
            __builder.AddContent(67, "                                        ");
            __builder.AddMarkupContent(68, "<td>Root Category</td>\r\n");
#line 63 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                    }

#line default
#line hidden
            __builder.AddContent(69, "                                    ");
            __builder.OpenElement(70, "td");
            __builder.AddMarkupContent(71, "\r\n                                        ");
            __builder.OpenElement(72, "div");
            __builder.AddAttribute(73, "class", "container");
            __builder.AddMarkupContent(74, "\r\n                                            ");
            __builder.AddMarkupContent(75, "<button class=\"btn btn-primary\" style=\"width:250px\">\r\n                                                Edit Custom Fields\r\n                                            </button>\r\n                                            ");
            __builder.OpenElement(76, "button");
            __builder.AddAttribute(77, "class", "btn btn-primary");
            __builder.AddAttribute(78, "style", "width:150px");
            __builder.AddAttribute(79, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 69 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                          () => EditCategory(category)

#line default
#line hidden
            ));
            __builder.AddMarkupContent(80, "\r\n                                                Edit\r\n                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n                                            ");
            __builder.OpenElement(82, "button");
            __builder.AddAttribute(83, "class", "btn btn-danger");
            __builder.AddAttribute(84, "style", "width:150px");
            __builder.AddAttribute(85, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 72 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                         () => DeleteCategory(category)

#line default
#line hidden
            ));
            __builder.AddMarkupContent(86, "\r\n                                                Delete\r\n                                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n                                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n");
#line 78 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                            }

#line default
#line hidden
            __builder.AddContent(91, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(92, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n");
#line 83 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }
    }

#line default
#line hidden
            __builder.AddMarkupContent(96, "\r\n");
#line 86 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (showPopup)
    {

#line default
#line hidden
            __builder.AddContent(97, "        ");
            __builder.OpenElement(98, "div");
            __builder.AddAttribute(99, "class", "modal");
            __builder.AddAttribute(100, "tabindex", "-1");
            __builder.AddAttribute(101, "style", "display:block");
            __builder.AddAttribute(102, "role", "dialog");
            __builder.AddMarkupContent(103, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(104);
            __builder.AddAttribute(105, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#line 89 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                              currentCategory

#line default
#line hidden
            ));
            __builder.AddAttribute(106, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#line 89 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                               ValidSubmit

#line default
#line hidden
            )));
            __builder.AddAttribute(107, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(108, "\r\n                ");
                __builder2.OpenElement(109, "div");
                __builder2.AddAttribute(110, "class", "modal-dialog");
                __builder2.AddMarkupContent(111, "\r\n                    ");
                __builder2.OpenElement(112, "div");
                __builder2.AddAttribute(113, "class", "modal-content");
                __builder2.AddMarkupContent(114, "\r\n                        ");
                __builder2.OpenElement(115, "div");
                __builder2.AddAttribute(116, "class", "modal-header");
                __builder2.AddMarkupContent(117, "\r\n                            ");
                __builder2.OpenElement(118, "h3");
                __builder2.AddAttribute(119, "class", "text-info");
                __builder2.AddContent(120, 
#line 93 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                    currentCategory.CategoryId != 0 ? "Update" : "Create"

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(121, "\r\n                            ");
                __builder2.OpenElement(122, "button");
                __builder2.AddAttribute(123, "type", "button");
                __builder2.AddAttribute(124, "class", "close");
                __builder2.AddAttribute(125, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 94 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                          ClosePopup

#line default
#line hidden
                ));
                __builder2.AddMarkupContent(126, "\r\n                                ");
                __builder2.AddMarkupContent(127, "<span aria-hidden=\"true\">X</span>\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(128, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(129, "\r\n                        ");
                __builder2.OpenElement(130, "div");
                __builder2.AddAttribute(131, "class", "modal-body");
                __builder2.AddMarkupContent(132, "\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(133);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(134, "\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(135);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(136, "\r\n                            ");
                __builder2.OpenElement(137, "div");
                __builder2.AddAttribute(138, "class", "row");
                __builder2.AddMarkupContent(139, "\r\n                                ");
                __builder2.OpenElement(140, "div");
                __builder2.AddAttribute(141, "class", "col-9");
                __builder2.AddMarkupContent(142, "\r\n                                    ");
                __builder2.OpenElement(143, "div");
                __builder2.AddAttribute(144, "class", "row py-2");
                __builder2.AddMarkupContent(145, "\r\n                                        ");
                __builder2.AddMarkupContent(146, "<div class=\"col-4\">\r\n                                            Category Name\r\n                                        </div>\r\n                                        ");
                __builder2.OpenElement(147, "div");
                __builder2.AddAttribute(148, "class", "col-8");
                __builder2.AddMarkupContent(149, "\r\n                                            ");
                __builder2.OpenElement(150, "input");
                __builder2.AddAttribute(151, "class", "form-control");
                __builder2.AddAttribute(152, "type", "text");
                __builder2.AddAttribute(153, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 108 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                           currentCategory.CategoryName

#line default
#line hidden
                ));
                __builder2.AddAttribute(154, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => currentCategory.CategoryName = __value, currentCategory.CategoryName));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(155, "\r\n                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(156, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(157, "\r\n                                    ");
                __builder2.OpenElement(158, "div");
                __builder2.AddAttribute(159, "class", "row py-2");
                __builder2.AddMarkupContent(160, "\r\n                                        ");
                __builder2.AddMarkupContent(161, "<div class=\"col-4\">\r\n                                            Parent Category ID\r\n                                        </div>\r\n                                        ");
                __builder2.OpenElement(162, "div");
                __builder2.AddAttribute(163, "class", "col-8");
                __builder2.AddMarkupContent(164, "\r\n                                            ");
                __builder2.OpenElement(165, "select");
                __builder2.AddAttribute(166, "class", "form-control");
                __builder2.AddAttribute(167, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 116 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                           currentCategory.ParentCategoryId

#line default
#line hidden
                ));
                __builder2.AddAttribute(168, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => currentCategory.ParentCategoryId = __value, currentCategory.ParentCategoryId));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(169, "\r\n");
#line 117 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                 foreach (var category in categories)
                                                {

#line default
#line hidden
                __builder2.AddContent(170, "                                                    ");
                __builder2.OpenElement(171, "option");
                __builder2.AddAttribute(172, "class", "dropdown-item");
                __builder2.AddAttribute(173, "value", 
#line 119 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                          category.CategoryId

#line default
#line hidden
                );
                __builder2.AddAttribute(174, "selected", 
#line 119 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                                           category.CategoryId == category.CategoryId ? true : false

#line default
#line hidden
                );
                __builder2.AddContent(175, 
#line 119 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                                                                                                                                        category.CategoryName

#line default
#line hidden
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(176, "\r\n");
#line 120 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                }

#line default
#line hidden
                __builder2.AddContent(177, "                                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(178, "\r\n                                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(179, "\r\n                                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(180, "\r\n                                    ");
                __builder2.AddMarkupContent(181, @"<div class=""row py-2"">
                                        <div class=""col-4"">

                                        </div>
                                        <div class=""col-8"">
                                            <button class=""btn btn-primary form-control"" type=""submit"">Submit</button>
                                        </div>
                                    </div>
                                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(182, "\r\n                            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(183, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(184, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(185, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(186, "\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(187, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(188, "\r\n");
#line 139 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
    }

#line default
#line hidden
            __builder.AddMarkupContent(189, "\r\n");
#line 141 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
     if (showPopupWarning)
        {

#line default
#line hidden
            __builder.AddContent(190, "            ");
            __builder.OpenElement(191, "div");
            __builder.AddAttribute(192, "class", "modal");
            __builder.AddAttribute(193, "tabindex", "-1");
            __builder.AddAttribute(194, "style", "display:block");
            __builder.AddAttribute(195, "role", "dialog");
            __builder.AddMarkupContent(196, "\r\n                ");
            __builder.OpenElement(197, "div");
            __builder.AddAttribute(198, "class", "modal-dialog");
            __builder.AddMarkupContent(199, "\r\n                    ");
            __builder.OpenElement(200, "div");
            __builder.AddAttribute(201, "class", "modal-content");
            __builder.AddMarkupContent(202, "\r\n                        ");
            __builder.OpenElement(203, "div");
            __builder.AddAttribute(204, "class", "modal-header");
            __builder.AddMarkupContent(205, "\r\n                            ");
            __builder.OpenElement(206, "h3");
            __builder.AddAttribute(207, "class", "text-primary");
            __builder.AddContent(208, 
#line 147 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                      warningMessage

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(209, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(210, "\r\n                        ");
            __builder.OpenElement(211, "div");
            __builder.AddAttribute(212, "class", "modal-body");
            __builder.AddMarkupContent(213, "\r\n                            ");
            __builder.OpenElement(214, "button");
            __builder.AddAttribute(215, "class", "btn btn-primary");
            __builder.AddAttribute(216, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 150 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
                                                                      ClosePopupWarning

#line default
#line hidden
            ));
            __builder.AddContent(217, "OK");
            __builder.CloseElement();
            __builder.AddMarkupContent(218, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(219, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(220, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(221, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(222, "\r\n");
#line 155 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
        }

#line default
#line hidden
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 158 "C:\Users\adamk\Documents\c#\PracaDyplomowa\Shop\Pages\CategoryPage.razor"
       

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

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
