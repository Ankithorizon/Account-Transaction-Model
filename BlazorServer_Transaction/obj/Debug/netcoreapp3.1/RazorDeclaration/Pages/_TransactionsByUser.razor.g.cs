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
#line 7 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using EFCore_Transaction.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using Service_Transaction.DTO;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/transactionsByUser")]
    public partial class _TransactionsByUser : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 71 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
       

    public Array transactionTypes = Enum.GetValues(typeof(TransactionType));
    public Array transactionStatus = Enum.GetValues(typeof(TransactionStatus));

    private bool hover = true;

    // very first load of table for transactions,,, displays number of rows
    // in table
    // @ref="table" code in table configuration
    private MudTable<Transaction> table;
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        table.SetRowsPerPage(50);
        return base.OnAfterRenderAsync(firstRender);
    }

    private List<Transaction> transactions = new List<Transaction>();
    private List<UserList> users = new List<UserList>();
    private int UserId = 0;


    private string GetTransactionType(int trType)
    {
        return transactionTypes.GetValue(trType).ToString();
    }
    private string GetTransactionStatus(int trStatus)
    {
        return transactionStatus.GetValue(trStatus).ToString();
    }

    private void setTransactionsForSelectedUser()
    {

    }



    protected override async Task OnInitializedAsync()
    {
        users = await userService.GetUserList();
        transactions = await transactionService.GetTransactionsByUser(1);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MudBlazor.ISnackbar snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.IUserRepository userService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.ITransactionRepository transactionService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorServer_Transaction.ApiCallHelpers.TransactionApiClient transactionApi { get; set; }
    }
}
#pragma warning restore 1591
