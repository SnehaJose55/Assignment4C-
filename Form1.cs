using Assignment4.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {
             //fetching details from account table
            try
            {
                var dbContext = new MMABooksContext();

                var accounts = dbContext.Accounts.ToList();

                dataGridView1.DataSource = accounts;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //selecting one row from datagrid view
            //passing accountId to form2
            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (var dbContext = new MMABooksContext())
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int accountId = Convert.ToInt32(selectedRow.Cells["AccountId"].Value);
                
                    var transactionExists = dbContext.TransactionHistories.Any(t => t.AccountId == accountId);
                    if (transactionExists)
                    {
                        form2.transactionhistory(accountId);
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No transaction exists for this user");
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Please select an account.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
