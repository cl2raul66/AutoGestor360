using AutoGestor360App.Views;

namespace AutoGestor360App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PgAddRegister), typeof(PgAddRegister));
        Routing.RegisterRoute(nameof(PgRegister), typeof(PgRegister));
        Routing.RegisterRoute(nameof(PgAddReview), typeof(PgAddReview));
        Routing.RegisterRoute(nameof(PgReview), typeof(PgReview));
        Routing.RegisterRoute(nameof(PgSettings), typeof(PgSettings));
        Routing.RegisterRoute(nameof(PgConnection), typeof(PgConnection));
        Routing.RegisterRoute(nameof(PgTasks), typeof(PgTasks));
    }
}
