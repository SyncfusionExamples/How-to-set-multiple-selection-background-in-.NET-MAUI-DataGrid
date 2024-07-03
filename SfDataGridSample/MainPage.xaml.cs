using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.GridCommon.ScrollAxis;
using Syncfusion.Maui.Inputs;
using System.Collections.Specialized;
using System.Reflection;

namespace SfDataGridSample
{
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
}
