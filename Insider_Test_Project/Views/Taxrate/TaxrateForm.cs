using ClassLibraryIntegration;
namespace Insiders_Test_Project.Views.Taxrate
{
    public partial class TaxrateForm : Form
    {
        public TaxrateForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var city = await ClassLibraryIntegration.Taxrate.FetchData(Int32.Parse(textBox1.Text));
                MessageBox.Show(city.Rate.ToString());
            }
            catch (Exception ex) { MessageBox.Show("Error\n"+ex.Message); }
        }
    }
}
