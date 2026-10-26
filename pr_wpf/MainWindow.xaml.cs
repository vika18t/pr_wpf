using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private ObservableCollection<Student> students = new ObservableCollection<Student>();

		public MainWindow()
		{
			InitializeComponent();

			StudGrid.ItemsSource = students;
		}


		private void AddButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LoadButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}