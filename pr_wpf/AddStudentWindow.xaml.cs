using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pr_wpf
{
	/// <summary>
	/// Логика взаимодействия для AddStudentWindow.xaml
	/// </summary>
	public partial class AddStudentWindow : Window
	{

		public Student NewStudent { get; private set; } 
		public AddStudentWindow()
		{
			InitializeComponent();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			// Проверка, что поля не пустые и введены корректные числа
			if (string.IsNullOrWhiteSpace(NameBox.Text) ||
				string.IsNullOrWhiteSpace(GroupBox.Text) ||
				string.IsNullOrWhiteSpace(EmailBox.Text))
			{
				MessageBox.Show("Заполните все текстовые поля!");
				return;
			}

			if (!int.TryParse(AgeBox.Text, out int age))
			{
				MessageBox.Show("Возраст должен быть целым числом!");
				return;
			}

			// Округляем балл или проверяем, что это число (замените точку на запятую, если нужно)
			if (!double.TryParse(GradeBox.Text.Replace('.', ','), out double grade))
			{
				MessageBox.Show("Балл должен быть числом (например, 4.8)!");
				return;
			}

			// Создаем объект
			NewStudent = new Student
			{
				Name = NameBox.Text,
				Age = age,
				Group = GroupBox.Text,
				Grade = grade,
				Email = EmailBox.Text
			};

			// Закрываем окно с результатом true (успех)
			this.DialogResult = true;
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			// Закрываем окно без сохранения (результат false)
			this.DialogResult = false;
		}
	}
}