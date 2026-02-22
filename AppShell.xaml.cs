using GestionEmpleadosMaui.Pages;

namespace GestionEmpleadosMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SedeDetailPage), typeof(SedeDetailPage));
            Routing.RegisterRoute(nameof(EmpleadoDetailPage), typeof(EmpleadoDetailPage));
            Routing.RegisterRoute(nameof(DepartamentoDetailPage), typeof(DepartamentoDetailPage));
        }
    }
}
