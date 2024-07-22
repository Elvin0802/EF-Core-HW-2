using System.Windows;
using WpfApp1.Views;

namespace WpfApp1;

public partial class App : Application
{
	private void Application_Startup(object sender, StartupEventArgs e)
	{
		var f = new MainWindowView().ShowDialog();
	}
}
