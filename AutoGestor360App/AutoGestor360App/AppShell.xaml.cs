using AutoGestor360App.Views;

namespace AutoGestor360App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(PgIngreso), typeof(PgIngreso));
            Routing.RegisterRoute(nameof(PgAjustes), typeof(PgAjustes));
        }
    }
}
