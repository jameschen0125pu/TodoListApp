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
                //MessageBox.Show("§A¿ï¤F..." + listBox1.SelectedItem.ToString());
                TodoItem item = listBox1.SelectedItem as TodoItem;
                tbTitle.Text = item.Title;
                tbDesc.Text = item.Description;
                tbCreatedDate.Text = item.CreatedDate.ToString();
                dtPickerDue.Value = item.DueDate;
                rbStatus0.Checked = true;
                rbStatus1.Checked = item.Status == 1;
                rbStatus2.Checked = item.Status == 2;
                //
                btnAdd.Enabled = false;
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.todoList = new TodoList();
            todoList.LoadFromFile(filePath);
            listBox1.DataSource = todoList.GetItems();
            //listBox1.ClearSelected();
            listBox1.DisplayMember = "Title";
            listBox1.ValueMember = "Title";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbTitle.Text = "";
            tbDesc.Text = "";
            tbCreatedDate.Text = "";
            dtPickerDue.Value = DateTime.Now;
            rbStatus0.Checked = true;
            //
            btnAdd.Enabled = true;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1.

            // 2.
            string title = tbTitle.Text;
            string desc = tbDesc.Text;
            DateTime cDate = DateTime.Now;
            DateTime dDate = dtPickerDue.Value;
            //
            TodoItem item = new TodoItem
            {
                Title = title,
                Description = desc,
                CreatedDate = cDate,
                DueDate = dDate,
                Status = rbStatus0.Checked ? 0 : (rbStatus1.Checked ? 1 : 2)
            };

            //
            todoList.AddItem(item);

            // 3.
            tbTitle.Text = "";
            tbDesc.Text = "";
            tbCreatedDate.Text = "";
            dtPickerDue.Value = DateTime.Now;
            rbStatus0.Checked = true;
            //
            btnAdd.Enabled = true;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            todoList.SaveToFile(filePath);
        }
    }
}
