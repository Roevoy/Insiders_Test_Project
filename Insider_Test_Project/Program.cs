using Insiders_Test_Project;
using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.DataProviders.StoredProcedureProviders;
using Insiders_Test_Project.Managers;
using Insiders_Test_Project.Managers.Validators;
using Insiders_Test_Project.Views;

namespace WinFormProject1
{
    internal static class Program
    {
        public const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=InsidersTestProjectDb;Integrated Security=True;TrustServerCertificate=True;";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new DIContainer();

            container.Register<UserValidator>(() => new UserValidator());
            container.Register<OrderValidator>(() => new OrderValidator());
            container.Register<ProductValidator>(() => new ProductValidator());
            container.Register<CustomerValidator>(() => new CustomerValidator());

            container.Register<IUserDataProvider, StoredUserDataProvider>();
            container.Register<ICustomerDataProvider, StoredCustomerDataProvider>();
            container.Register<IProductDataProvider, StoredProductDataProvider>();
            container.Register<IOrderDataProvider, StoredOrderDataProvider>();

            container.Register<MainForm>(() => new MainForm(
                container.Resolve<UserManager>(), container.Resolve<OrderManager>()));
            container.Register<UserManager>(() => new UserManager(
                container.Resolve<IUserDataProvider>(), container.Resolve<UserValidator>()));
            container.Register<CustomerManager>(() => new CustomerManager(
                container.Resolve<ICustomerDataProvider>()));
            container.Register<ProductManager>(() => new ProductManager(
                container.Resolve<IProductDataProvider>()));
            container.Register<OrderManager>(() => new OrderManager(
                container.Resolve<IOrderDataProvider>()));
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(container.Resolve<MainForm>());
        }
    }
}