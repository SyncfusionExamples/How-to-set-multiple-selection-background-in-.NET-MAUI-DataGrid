# How to set multiple selection background in .NET MAUI DataGrid

In this article, we will show you how to set multiple selection background in [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

**XAML**
```
    <syncfusion:SfDataGrid x:Name="sfGrid"
                           ColumnWidthMode="Auto"
                           GridLinesVisibility="Both"
                           HeaderGridLinesVisibility="Both"
                           AutoGenerateColumnsMode="None"
                           SelectionMode="Multiple"
                           ItemsSource="{Binding Employees}">
 
        <syncfusion:SfDataGrid.Columns>
            <syncfusion:DataGridNumericColumn MappingName="EmployeeID"
                                              HeaderText="Employee ID" />
            <syncfusion:DataGridTextColumn MappingName="Name"
                                           HeaderText="Employee Name" />
            <syncfusion:DataGridTextColumn MappingName="Title"
                                           HeaderText="Designation" />
            <syncfusion:DataGridDateColumn MappingName="HireDate"
                                           HeaderText="Hire Date" />
        </syncfusion:SfDataGrid.Columns>
    </syncfusion:SfDataGrid>
 ```

C#
The below code illustrates how to set multiple selection background with custom Cell renderer.
```
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            sfGrid.CellRenderers.Remove("Text");
            sfGrid.CellRenderers.Add("Text", new CustomRenderer());
            sfGrid.CellRenderers.Remove("Numeric");
            sfGrid.CellRenderers.Add("Numeric", new CustomRenderer());
            sfGrid.CellRenderers.Remove("CheckBox");
            sfGrid.CellRenderers.Add("CheckBox", new CustomRenderer());
            sfGrid.CellRenderers.Remove("Template");
            sfGrid.CellRenderers.Add("Template", new CustomRenderer());
            sfGrid.CellRenderers.Remove("Image");
            sfGrid.CellRenderers.Add("Image", new CustomRenderer());
            sfGrid.CellRenderers.Remove("DateTime");
            sfGrid.CellRenderers.Add("DateTime", new CustomRenderer());
            sfGrid.CellRenderers.Remove("ComboBox");
            sfGrid.CellRenderers.Add("ComboBox", new CustomRenderer());
        }
    }
 
    public class CustomRenderer : DataGridCellRenderer<View,View>
    {        
        protected override void OnSetCellStyle(DataColumnBase dataColumn)
        {
            base.OnSetCellStyle(dataColumn);
 
            if (dataColumn != null)
            {             
 
                var gridStyle = this.DataGrid?.DefaultStyle;
                DataGridCell? gridCell = dataColumn.ColumnElement;
                var dataRow = dataColumn.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("DataRow"))!.GetValue(dataColumn);
 
                if (DataGrid!.SelectionController.SelectedRows.Any(row => row.RowData == dataColumn.RowData && (dataRow as DataRow)!.IsSelectedRow))
                {
                    var rowData = (dataRow as DataRow).RowData as Employee;
                    if(rowData.Title.Equals("Assistant"))
                        (gridCell as DataGridCell).Background = Color.FromRgba("caf0f8");
                    else if (rowData.Title.Equals("Engineering"))
                        (gridCell as DataGridCell).Background = Color.FromRgba("00b4d8");
                    else if (rowData.Title.Equals("Designer"))
                        (gridCell as DataGridCell).Background = Color.FromRgba("ff99c8");
                    else if (rowData.Title.Equals("Manager"))
                        (gridCell as DataGridCell).Background = Color.FromRgba("fb6f92");
                }
 
                gridStyle = null;
                gridCell = null;
            }
        }
    }
```

 
 ![MultipleSelection.gif](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI1MDEzIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.bdYMSSL6gTiS4GiH7uL_It73U76jwrG1nXPYB_qW6RI)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-set-multiple-selection-background-in-.NET-MAUI-DataGrid)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to set multiple selection background in .NET MAUI DataGrid.
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!