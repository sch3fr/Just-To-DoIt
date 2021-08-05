using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
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
    /// After pressing the close button the app generates .xml file with all tasks. The file is loded on startup.
    /// </summary>

    //Important Names
    //TextBox = textBox
    //Add Task button = buttonAddTask
    //Task List Box = list
    //Delete Single Task button = buttonDelOne
    //Delete All Tasks button = buttonDelAll
    //textblock in list = taskListNames

    /*TODO 
        move task down the list when checked as done
    */
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> allTasks { get; set; } //

        public MainWindow()
        {
            allTasks = new ObservableCollection<string>();
            this.DataContext = this;

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<string>));

            try //the .xml file is not created on the first startup, so this try-catch block saves the program from crashing by creating the xaml file first.
            {
                using (StreamReader rd = new StreamReader("AllTasksList.xml"))
                {
                    allTasks = xs.Deserialize(rd) as ObservableCollection<string>;
                }
            }
            catch
            {
                File.Create("AllTasksList.xml");
            }

            InitializeComponent();

            this.Closed += new EventHandler(MainWindow_Closed); // creates new event when the window is closed


            
        }

        void MainWindow_Closed(object sender, EventArgs e) //saves the tasks when user presses the close button
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<string>));
            using (StreamWriter wr = new StreamWriter("AllTasksList.xml"))
            {
                xs.Serialize(wr, allTasks);
            }
        }
        private void buttonAddTask_Click(object sender, RoutedEventArgs e) //adds tasks from the textBox to the taskList
        {
            allTasks.Add(textBox.Text);
            MessageBox.Show("Task " + textBox.Text + " has been added to the list");
        }

        private void buttonDelAll_Click(object sender, RoutedEventArgs e) //deletes all tasks from the list
        {
            allTasks.Clear();
        }

        private void buttonDelOne_Click(object sender, RoutedEventArgs e) //removes selected task from the list
        {
            allTasks.Remove((string)list.SelectedItem);
        }
    }
}
