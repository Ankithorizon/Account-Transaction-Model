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
#line 7 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionMgr.razor"
using EFCore_Transaction.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionMgr.razor"
using Service_Transaction.DTO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/transactionmgr")]
    public partial class _TransactionMgr : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 162 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionMgr.razor"
       

    public Array transactionTypes = Enum.GetValues(typeof(TransactionType));
    public Array transactionStatus = Enum.GetValues(typeof(TransactionStatus));

    private bool hover = true;

    // very first load of table for transactions,,, displays number of rows
    // in table
    // @ref="table" code in table configuration
    private MudTable<TransactionDto> table;
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        table.SetRowsPerPage(50);
        return base.OnAfterRenderAsync(firstRender);
    }

    // response from background-worker-process
    private BKProcessResponse BKP_Response_DB = new BKProcessResponse();
    private BKProcessResponse BKP_Response_CSVFile = new BKProcessResponse();

    private List<Transaction> transactions = new List<Transaction>();
    private List<TransactionDto> transactions_ = new List<TransactionDto>();

    private string GetTransactionType(int trType)
    {
        return transactionTypes.GetValue(trType).ToString();
    }
    private string GetTransactionStatus(int trStatus)
    {
        return transactionStatus.GetValue(trStatus).ToString();
    }


    // add transactions to db
    // call worker-process
    // via web-api call
    private async Task CallWorkerProcess_DB()
    {
        BKP_Response_DB = await transactionApi.AddTransactionsToDB_BackgroundWorkerProcessAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        // call to api-transaction-controller
        // this transaction-controller[api-worker-service-controller],,,
        // next uses transaction-repository[data-access-service] to access database
        // transactions = await transactionApi.GetTransactionsAsync();

        transactions_ = await transactionService.Get_AllTransactions();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MudBlazor.ISnackbar snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.IPayeeRepository payeeService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.ITransactionRepository transactionService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorServer_Transaction.ApiCallHelpers.TransactionApiClient transactionApi { get; set; }
    }
}
#pragma warning restore 1591
