using System.Windows.Forms;

namespace TodoListApp
{
    public partial class Form1 : Form
    {
        private TodoList todoList;
        private string filePath = "todolist.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                MessageBox.Show("§A¿ï¤F..." + listBox1.SelectedItem.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.todoList = new TodoList();
            todoList.LoadFromFile(filePath);
            listBox1.DataSource = todoList.GetItems();
        }
    }
}
