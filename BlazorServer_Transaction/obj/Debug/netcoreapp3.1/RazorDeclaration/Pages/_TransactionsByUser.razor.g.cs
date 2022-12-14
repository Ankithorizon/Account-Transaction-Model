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
#line 9 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using EFCore_Transaction.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using Service_Transaction.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using ChartJs.Blazor.BarChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
using ChartJs.Blazor.LineChart;

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
#line 140 "C:\Transaction-Model\APITransaction\BlazorServer_Transaction\Pages\_TransactionsByUser.razor"
       

    private bool showChart = false;

    // select list
    private List<UserList> users = new List<UserList>();
    private UserList selectedUser = new UserList();


    public Array transactionTypes = Enum.GetValues(typeof(TransactionType));
    public Array transactionStatus = Enum.GetValues(typeof(TransactionStatus));

    private bool hover = true;

    // very first load of table for transactions,,, displays number of rows
    // in table
    // @ref="table" code in table configuration
    private MudTable<Transaction> table = new MudTable<Transaction>();
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (transactions != null && transactions.Count() > 0)
        {
            table.SetRowsPerPage(50);
            return base.OnAfterRenderAsync(firstRender);
        }
        else
        {
            return base.OnAfterRenderAsync(firstRender);
        }
    }

    private List<Transaction> transactions = new List<Transaction>();

    private string GetTransactionType(int trType)
    {
        return transactionTypes.GetValue(trType).ToString();
    }
    private string GetTransactionStatus(int trStatus)
    {
        return transactionStatus.GetValue(trStatus).ToString();
    }

    private async Task SetTransactionsForSelectedUser(UserList selectedUser)
    {
        transactions = await transactionService.GetTransactionsByUser(selectedUser.UserId);

        chartDatas = await chartService.GetMonthly_Total_InOut_ChartReport(selectedUser.UserId);

        // mudblazor chart
        // CreateActualChart();

        // chartjs.mudblazor chart
        CreateChartJsBlazorBarChart();
        CreateChartJsBlazorLineChart();
    }


    protected override async Task OnInitializedAsync()
    {
        users = await userService.GetUserList();
        users = new List<UserList>(users.Where(x => x.UserId != 0)).ToList();

        transactions = await transactionService.GetTransactionsByUser(0);

        // chartjs.mudblazor
        initChartJsMudBlazorBarChart();
        initChartJsMudBlazorLineChart();
    }


    // chart-data
    // MonthlyTotalInOutChartData
    private MonthlyTotalInOutChartData chartDatas;
    private static string InLabel = "IN $K";
    private static string OutLabel = "OUT $K";
    private int Index = -1;

    public string[] XAxisLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    // mudblazor chart
    public List<ChartSeries> Series = new List<ChartSeries>()
{
        new ChartSeries() { Name = InLabel, Data = new double[] { 90, 79, 72, 69, 62, 62, 55, 65, 70, 10, 10, 10 } },
        new ChartSeries() { Name = OutLabel, Data = new double[] { 10, 41, 35, 51, 49, 62, 69, 91, 148, 10, 10, 10 } },
    };
    public void CreateActualChart()
    {
        var new_series = new List<ChartSeries>()
        {
            new ChartSeries() { Name = InLabel, Data = new double[12] },
            new ChartSeries() { Name = OutLabel, Data = new double[12] },
        };
        var ary = new double[chartDatas.TotalInData.InDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalInData.InDatas.Count; ii++)
        {
            ary[ii] = Convert.ToDouble(chartDatas.TotalInData.InDatas[ii] / 1000);
        }
        var aryOut = new double[chartDatas.TotalOutData.OutDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalOutData.OutDatas.Count; ii++)
        {
            aryOut[ii] = Convert.ToDouble(chartDatas.TotalOutData.OutDatas[ii] / 1000);
        }
        for (int i = 0; i < 11; i++)
        {
            new_series[0].Data[i] = ary[i];
            new_series[1].Data[i] = aryOut[i];
        }
        Series = new_series;
        StateHasChanged();
    }



    // chartjs.mudblazor
    private BarConfig _config;
    private LineConfig _configLine;
    // bar chart
    private void initChartJsMudBlazorBarChart()
    {
        _config = new BarConfig();
        _config.Options = new BarOptions
        {
            Responsive = true,
            Title = new OptionsTitle
            {
                Display = true,
                Text = "Monthly $In v/s $Out"
            }
        };
        foreach (string month in new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" })
        {
            _config.Data.Labels.Add(month);
        }
    }
    public void CreateChartJsBlazorBarChart()
    {

        // var ary = new double[chartDatas.TotalInData.InDatas.Count];
        var ary = new decimal[chartDatas.TotalInData.InDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalInData.InDatas.Count; ii++)
        {
            // ary[ii] = Convert.ToDouble(chartDatas.TotalInData.InDatas[ii] / 1000);
            // ary[ii] = Convert.ToDouble(chartDatas.TotalInData.InDatas[ii]);
            ary[ii] = chartDatas.TotalInData.InDatas[ii];
        }
        // var aryOut = new double[chartDatas.TotalOutData.OutDatas.Count];
        var aryOut = new decimal[chartDatas.TotalOutData.OutDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalOutData.OutDatas.Count; ii++)
        {
            // aryOut[ii] = Convert.ToDouble(chartDatas.TotalOutData.OutDatas[ii] / 1000);
            // aryOut[ii] = Convert.ToDouble(chartDatas.TotalOutData.OutDatas[ii]);
            aryOut[ii] = chartDatas.TotalOutData.OutDatas[ii];
        }
        // BarDataset<double> datasetIn = new BarDataset<double>(ary);
        // BarDataset<double> datasetOut = new BarDataset<double>(aryOut);
        BarDataset<decimal> datasetIn = new BarDataset<decimal>(ary);
        BarDataset<decimal> datasetOut = new BarDataset<decimal>(aryOut);

        datasetIn.BackgroundColor = new[]
        {
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
            ColorUtil.ColorHexString(75, 192, 192),
        };
        datasetIn.Label = chartDatas.TotalInData.Name;


        datasetOut.BackgroundColor = new[]
        {
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
            ColorUtil.ColorHexString(255, 99, 132),
        };
        datasetOut.Label = chartDatas.TotalOutData.Name;

        _config.Data.Datasets.Clear();

        _config.Data.Datasets.Add(datasetIn);
        _config.Data.Datasets.Add(datasetOut);

        showChart = true;
    }
    // line chart
    private void initChartJsMudBlazorLineChart()
    {
        _configLine = new LineConfig();
        _configLine.Options = new LineOptions
        {
            Responsive = true,
            Title = new OptionsTitle
            {
                Display = true,
                Text = "Monthly $In v/s $Out"
            }
        };
        foreach (string month in new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" })
        {
            _configLine.Data.Labels.Add(month);
        }
    }
    public void CreateChartJsBlazorLineChart()
    {
        var ary = new decimal[chartDatas.TotalInData.InDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalInData.InDatas.Count; ii++)
        {
            ary[ii] = chartDatas.TotalInData.InDatas[ii];
        }
        var aryOut = new decimal[chartDatas.TotalOutData.OutDatas.Count];
        for (var ii = 0; ii < chartDatas.TotalOutData.OutDatas.Count; ii++)
        {
            aryOut[ii] = chartDatas.TotalOutData.OutDatas[ii];
        }
        LineDataset<decimal> datasetIn = new LineDataset<decimal>(ary);
        LineDataset<decimal> datasetOut = new LineDataset<decimal>(aryOut);

        datasetIn.BackgroundColor = ColorUtil.ColorHexString(75, 192, 192);
        datasetIn.Label = chartDatas.TotalInData.Name;


        datasetOut.BackgroundColor = ColorUtil.ColorHexString(255, 99, 132);
        datasetOut.Label = chartDatas.TotalOutData.Name;

        _configLine.Data.Datasets.Clear();

        _configLine.Data.Datasets.Add(datasetIn);
        _configLine.Data.Datasets.Add(datasetOut);

        showChart = true;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MudBlazor.ISnackbar snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.IChartRepository chartService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.IUserRepository userService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Service_Transaction.Contracts.ITransactionRepository transactionService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorServer_Transaction.ApiCallHelpers.TransactionApiClient transactionApi { get; set; }
    }
}
#pragma warning restore 1591
