using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Views;

public partial class MainWindowView : Window
{
	public DataSet? DataSet1 { get; set; }
	public List<Book> Books1 { get; set; }
	public List<string>? Sel { get; set; }

	public MainWindowView()
	{
		InitializeComponent();

		Sel = new List<string>() { "Authors", "Themes", "Categories" };

		TypesCB.ItemsSource = Sel;

		TypesCB.Items.Refresh();

		lw.ItemsSource = Books1;

	}

	private void ColumnChangedExecute(object sender, SelectionChangedEventArgs e)
	{
		using LibraryContext DB = new();

		if (TypesCB.SelectedValue.ToString() == Sel[0])
		{
			ResultsCB.ItemsSource = DB.Authors.ToList();
		}
		else if (TypesCB.SelectedValue.ToString() == Sel[1])
		{
			ResultsCB.ItemsSource = DB.Themes.ToList();
		}
		else if (TypesCB.SelectedValue.ToString() == Sel[2])
		{
			ResultsCB.ItemsSource = DB.Categories.ToList();
		}

		ResultsCB.Items.Refresh();
	}

	private void RowChangedExecute(object sender, SelectionChangedEventArgs e)
	{
		if (ResultsCB.SelectedItem is null)
		{
			lw.ItemsSource = null;
			lw.Items.Refresh();
			return;
		}

		using LibraryContext DB = new();

		if (TypesCB.SelectedValue.ToString() == Sel![0])
		{
			Books1 = DB.Books.Where(b => b.IdAuthor == (ResultsCB.SelectedItem as Author)!.Id).ToList();
		}
		else if (TypesCB.SelectedValue.ToString() == Sel[1])
		{
			Books1 = DB.Books.Where(b => b.IdThemes == (ResultsCB.SelectedItem as Theme)!.Id).ToList();
		}
		else if (TypesCB.SelectedValue.ToString() == Sel[2])
		{
			Books1 = DB.Books.Where(b => b.IdCategory == (ResultsCB.SelectedItem as Category)!.Id).ToList();
		}

		lw.ItemsSource = Books1;
		lw.Items.Refresh();
	}
}
