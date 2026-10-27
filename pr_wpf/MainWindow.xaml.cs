using System.Collections.ObjectModel;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace pr_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		ObservableCollection<Student> students = new ObservableCollection<Student>();

		public MainWindow()
		{
			InitializeComponent();

			StudGrid.ItemsSource = students;
		}


		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			AddStudentWindow addWindow = new AddStudentWindow();
			addWindow.Owner = this;

			if (addWindow.ShowDialog() == true)
			{
				students.Add(addWindow.NewStudent);
			}
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			
			if (StudGrid.SelectedItem is Student selectedStudent)
			{
			
				MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить студента {selectedStudent.Name}?",
						"Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

				
				if (result == MessageBoxResult.Yes)
				{
					students.Remove(selectedStudent);
				}
			}
			else
			{
				
				MessageBox.Show("Выберите студента для удаления.");
			}
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true, 
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) 
			};

			string json = JsonSerializer.Serialize(students, options);
			File.WriteAllText("students.json", json);
		}


		private void LoadButton_Click(object sender, RoutedEventArgs e)
		{
			if (!File.Exists("students.json"))
			{
				MessageBox.Show("Файл students.json не найден!");
				return;
			}

			string json = File.ReadAllText("students.json");
			var loadedStudents = JsonSerializer.Deserialize<ObservableCollection<Student>>(json);

			students.Clear();
			foreach (var s in loadedStudents)
			{
				students.Add(s);
			}
			MessageBox.Show("Данные успешно загружены!");
		}
	}
}