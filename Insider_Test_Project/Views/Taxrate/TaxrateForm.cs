using ClassLibraryIntegration;
namespace Insiders_Test_Project.Views.Taxrate
{
    public partial class TaxrateForm : Form
    {
        private readonly ClassLibraryIntegration.Taxrate _taxrate;
        public TaxrateForm(ClassLibraryIntegration.Taxrate taxrate)
        {
            InitializeComponent();
            _taxrate = taxrate;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var city = await _taxrate.FetchData(Int32.Parse(textBox1.Text));
                MessageBox.Show(city.Rate.ToString());
            }
            catch (Exception ex) { MessageBox.Show("Error\n"+ex.Message); }
        }
    }
}
