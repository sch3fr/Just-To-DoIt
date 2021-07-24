using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JustToDoIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TodoItem> taskList = new List<TodoItem>();


        public MainWindow()
        {
            InitializeComponent();
            //items.Add(new TodoItem() { Title = "First task", Completion = false });
            list.ItemsSource = taskList;

        }

        public class TodoItem
        {
            public string Title { get; set; }
            public bool Completion { get; set; }
        }

        private void buttonAddTask_Click(object sender, RoutedEventArgs e)
        {
            taskList.Add(new TodoItem() { Title = textBox.Text, Completion = false });
            MessageBox.Show("Task " + textBox.Text + " has been added to the list");
        }

        private void buttonDelAll_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void buttonDelOne_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Remove(taskList);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
