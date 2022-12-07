// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 6 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_PayeeMgr.razor"
using EFCore_Transaction.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_PayeeMgr.razor"
using Service_Transaction.DTO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/payeemgr")]
    public partial class _PayeeMgr : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 112 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_PayeeMgr.razor"
       

    private bool hover = true;

    // very first load of table for payees,,, displays number of rows
    // in table
    // @ref="table" code in table configuration
    private MudTable<Payee> table;
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        table.SetRowsPerPage(5);
        return base.OnAfterRenderAsync(firstRender);
    }

    // response from background-worker-process
    private BKProcessResponse BKP_Response_DB = new BKProcessResponse();
    private BKProcessResponse BKP_Response_CSVFile = new BKProcessResponse();

    private List<Payee> payees = new List<Payee>();

    // add payees to db
    // call worker-process
    // via web-api call
    private async Task CallWorkerProcess_DB()
    {
        BKP_Response_DB = await payeeApi.AddPayeesToDB_BackgroundWorkerProcessAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        // call to api-payee-controller
        // this payee-controller[api-worker-service-controller],,,
        // next uses payee-repository[data-access-service] to access database
        payees = await payeeApi.GetPayeesAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MudBlazor.ISnackbar snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.IPayeeRepository payeeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorServer_Transaction.ApiCallHelpers.PayeeApiClient payeeApi { get; set; }
    }
}
#pragma warning restore 1591
