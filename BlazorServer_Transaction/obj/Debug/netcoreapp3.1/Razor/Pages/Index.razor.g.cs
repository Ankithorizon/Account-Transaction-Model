#pragma checksum "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1f8843a350da90c8664558f67211702fb8ebce4"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorServer_Transaction.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using BlazorServer_Transaction;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using BlazorServer_Transaction.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common.Axes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common.Axes.Ticks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common.Handlers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Common.Time;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Util;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\_Imports.razor"
using ChartJs.Blazor.Interop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
using ChartJs.Blazor.PieChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
using ChartJs.Blazor.BarChart;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style>\r\n    .subItem {\r\n        padding-left: 100px;\r\n    }\r\n</style>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddMarkupContent(2, "\r\n\r\n    ");
            __builder.OpenComponent<ChartJs.Blazor.Chart>(3);
            __builder.AddAttribute(4, "Config", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ChartJs.Blazor.Common.ConfigBase>(
#nullable restore
#line 14 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
                   _config

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n<p></p>\r\n<hr>\r\n<p></p>\r\n\r\n\r\n");
            __builder.AddMarkupContent(7, "<h3>Account-Transaction-Model [using Worker Service@ Web-API Core]</h3>\r\n<p></p>\r\n");
            __builder.OpenComponent<MudBlazor.MudCard>(8);
            __builder.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(10, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudCardContent>(11);
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(13, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudList>(14);
                    __builder3.AddAttribute(15, "Clickable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 25 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
                            false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(17, "\r\n            ");
                        __builder4.OpenComponent<MudBlazor.MudListItem>(18);
                        __builder4.AddAttribute(19, "Text", "Blazor-Server-App calls Web-Api Core[Worker-Service] to generate");
                        __builder4.AddAttribute(20, "InitiallyExpanded", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 27 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
                                            true

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(21, "NestedList", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(22, "\r\n                    ");
                            __builder5.OpenComponent<MudBlazor.MudListItem>(23);
                            __builder5.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddMarkupContent(25, "\r\n                        ");
                                __builder6.AddMarkupContent(26, "<span class=\"subItem\">\r\n                            - randomly 10-Users, 10-Payees, 30-Accounts and 100-Transactions\r\n                        </span>\r\n                    ");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(27, "\r\n                ");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(28, "\r\n            ");
                        __builder4.OpenComponent<MudBlazor.MudListItem>(29);
                        __builder4.AddAttribute(30, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(31, "\r\n                Blazor-Server-App display[Table/Chart] live update from Users, Payees, Accounts and Transactions\r\n            ");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(32, "\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(33, "\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(34, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudCardActions>(35);
                __builder2.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(37, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudElement>(38);
                    __builder3.AddAttribute(39, "HtmlTag", "a");
                    __builder3.AddAttribute(40, "Class", "ma-0");
                    __builder3.AddAttribute(41, "Style", "color:red;font-weight:bold;");
                    __builder3.AddAttribute(42, "href", "https://github.com/Ankithorizon/Transaction-Model-Blazor-WorkerThread");
                    __builder3.AddAttribute(43, "target", "blank");
                    __builder3.AddAttribute(44, "rel", "noopener noreferrer");
                    __builder3.AddAttribute(45, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(46, "\r\n            Source-Code\r\n        ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(47, "\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\Index.razor"
      
        Color _color = Color.Primary;

    //private PieConfig _config;

        //protected override async Task OnInitializedAsync()
        //{
        //    _config = new PieConfig
        //    {
        //        Options = new PieOptions
        //        {
        //            Responsive = true,
        //            Title = new OptionsTitle
        //            {
        //                Display = true,
        //                Text = "ChartJs.Blazor Pie Chart"
        //            }
        //        }
        //    };

        //    foreach (string color in new[] { "Red", "Yellow", "Green", "Blue" })
        //    {
        //        _config.Data.Labels.Add(color);
        //    }

        //    PieDataset<int> dataset = new PieDataset<int>(new[] { 6, 5, 3, 7 })
        //    {
        //        BackgroundColor = new[]
        //        {
        //        ColorUtil.ColorHexString(255, 99, 132), // Slice 1 aka "Red"
        //        ColorUtil.ColorHexString(255, 205, 86), // Slice 2 aka "Yellow"
        //        ColorUtil.ColorHexString(75, 192, 192), // Slice 3 aka "Green"
        //        ColorUtil.ColorHexString(54, 162, 235), // Slice 4 aka "Blue"
        //    }
        //    };

        //    _config.Data.Datasets.Add(dataset);
        //}


    private BarConfig _config;
    protected override void OnInitialized()
    {
        _config = new BarConfig
        {
            Options = new BarOptions
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Bar Chart"
                }
            }
        };

        foreach (string color in new[] { "Red", "Green" })
        {
            _config.Data.Labels.Add(color);
        }

        BarDataset<int> datasetIn = new BarDataset<int>(new[] { 6, 5, 3, 7 });
        BarDataset<int> datasetOut = new BarDataset<int>(new[] { 3, 7, 8, 2 });
        _config.Data.Datasets.Add(datasetIn);
        _config.Data.Datasets.Add(datasetOut);
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
