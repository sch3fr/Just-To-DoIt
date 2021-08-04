using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Basically you write task into the text box on new task page. The Add Task button adds it to the list on Task List page.
    /// On the Task List there are two buttons, one to delete selected task, the other to delete all tasks.
    /// You should be able to mark tasks as done with the checkbox next to every task.
    /// </summary>

    //Important Names
    //TextBox = textBox
    //Add Task button = buttonAddTask
    //Task List Box = list
    //Delete Single Task button = buttonDelOne
    //Delete All Tasks button = buttonDelAll
    //textblock in list = taskListNames
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> allTasks { get; set; }

        public MainWindow()
        {
            allTasks = new ObservableCollection<string>();
            this.DataContext = this;
            InitializeComponent();
        }
        private void buttonAddTask_Click(object sender, RoutedEventArgs e)
        {
            allTasks.Add(textBox.Text);
            
            MessageBox.Show("Task " + textBox.Text + " has been added to the list");
        }

        private void buttonDelAll_Click(object sender, RoutedEventArgs e)
        {
            allTasks.Clear();
        }

        private void buttonDelOne_Click(object sender, RoutedEventArgs e)
        {
            allTasks.Remove((string)list.SelectedItem);
        }
    }
}
