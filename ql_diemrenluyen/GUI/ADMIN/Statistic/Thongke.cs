using ScottPlot;
using ScottPlot.WinForms;

namespace ql_diemrenluyen.GUI.ADMIN.Statistic
{
    public partial class Thongke : Form
    {
        private FormsPlot formsPlot1;
        public Thongke()
        {
            InitializeComponent();
            InitializeFormsPlot();  // Khởi tạo và thêm FormsPlot vào form
            CreatePieChart();  //
        }

        private void InitializeFormsPlot()
        {
            // Khởi tạo FormsPlot
            formsPlot1 = new FormsPlot();
            this.panel4.Controls.Add(formsPlot1);  // Thêm FormsPlot vào panel4
            formsPlot1.Dock = DockStyle.Fill;  // Đảm bảo FormsPlot chiếm toàn bộ diện tích panel
            formsPlot1.Width = 600;  // Thiết lập chiều rộng của FormsPlot
            formsPlot1.Height = 400;  // Thiết lập chiều cao của FormsPlot
        }

        private void CreatePieChart()
        {
            PieSlice slice1 = new() { Value = 5, FillColor = Colors.Red, Label = "alpha" };
            PieSlice slice2 = new() { Value = 2, FillColor = Colors.Orange, Label = "beta" };
            PieSlice slice3 = new() { Value = 8, FillColor = Colors.Gold, Label = "gamma" };
            PieSlice slice4 = new() { Value = 4, FillColor = Colors.Green, Label = "delta" };
            PieSlice slice5 = new() { Value = 8, FillColor = Colors.Blue, Label = "epsilon" };

            List<PieSlice> slices = new() { slice1, slice2, slice3, slice4, slice5 };

            // setup the pie to display slice labels
            var pie = formsPlot1.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = .5;

            double total = pie.Slices.Select(x => x.Value).Sum();
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].Label = $"{pie.Slices[i].Label}";
                pie.Slices[i].LegendText = $"{pie.Slices[i].Label} " +
                    $"({pie.Slices[i].Value / total:p1})";
            }

            // color each label's text to match the slice
            slices.ForEach(x => x.LabelFontColor = x.FillColor.Darken(.5));

            // hide unnecessary plot components
            formsPlot1.Plot.Axes.Frameless();
            formsPlot1.Plot.HideGrid();

            formsPlot1.Refresh();
        }

        private void resize(object sender, EventArgs e)
        {
            formsPlot1.Refresh();
        }




        private void dungeonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
