using Assignment4.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment4
{
    public partial class Form2 : Form
    {
      
        private DateTime transactionDate;
        private decimal amount;
        private string description;
        private int accountId;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void transactionhistory(int accountId)
        {
            try
            {
                var dbContext = new MMABooksContext();
                textBox1.Text = accountId.ToString();

                List<TransactionHistory> transactiondetails = dbContext.TransactionHistories
                    .Where(a => a.AccountId == accountId)
                    .ToList();

                dataGridView1.DataSource = transactiondetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        //ADD BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            transactionDate = DateTime.Parse(textBox2.Text);
            amount = Convert.ToDecimal(textBox3.Text);
            description = textBox4.Text;
            int accountId = int.Parse(textBox1.Text);



            using (var dbContext = new MMABooksContext())
            {
                //debit this amount from main balance
                var currentBalance = (from a in dbContext.Accounts
                                      join t in dbContext.TransactionHistories
                                      on a.AccountId equals t.AccountId
                                      where t.AccountId == accountId
                                      select a.CurrentBalance).FirstOrDefault();
                Console.WriteLine(currentBalance);
                decimal newBalance = (decimal)currentBalance - amount;

                var account = dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (account != null)
                {
                    account.CurrentBalance = (double)newBalance;
                    dbContext.SaveChanges();
                }


                var newTransaction = new TransactionHistory
                {
                    AccountId = accountId,
                    TransactionDate = transactionDate,
                    Amount = amount,
                    Description = description
                };

                // Add the new transaction to the TransactionHistories DbSet
                dbContext.TransactionHistories.Add(newTransaction);
                dbContext.SaveChanges();
                transactionhistory(accountId);
               
                MessageBox.Show("Transaction added successfully.");
            }
        }

        //DELETE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            using (var dbContext = new MMABooksContext())
            {
                accountId = int.Parse(textBox1.Text);
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int transactionId = Convert.ToInt32(selectedRow.Cells["TransactionId"].Value);
                    var transaction = dbContext.TransactionHistories.FirstOrDefault(t => t.TransactionId == transactionId);
                    if (transaction != null)
                    {
                        // Remove the transaction from the DbSet
                        dbContext.TransactionHistories.Remove(transaction);
                        dbContext.SaveChanges();
                        List<TransactionHistory> accountTransactions = dbContext.TransactionHistories
                                .Where(t => t.AccountId == accountId)
                                .ToList();

                        //credit this amount from main balance
                        var currentBalance = (from a in dbContext.Accounts
                                              join t in dbContext.TransactionHistories
                                              on a.AccountId equals t.AccountId
                                              where t.AccountId == accountId
                                              select a.CurrentBalance).FirstOrDefault();
                        Console.WriteLine(currentBalance);
                        decimal newBalance = (decimal)currentBalance + amount;

                        var account = dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                        if (account != null)
                        {
                            account.CurrentBalance = (double)newBalance;
                            dbContext.SaveChanges();
                        }

                        // Bind the list of transactions to the DataGridView
                        dataGridView1.DataSource = accountTransactions;
                        MessageBox.Show("Transaction deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Transaction not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an account.");
                }
            }
        }

        //Update button
        private void button3_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Extract cell values from the selected row
                string transactionDateString = selectedRow.Cells["TransactionDate"].Value.ToString();
                string amountString = selectedRow.Cells["Amount"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string accountIdString = selectedRow.Cells["AccountId"].Value.ToString();

                if (DateTime.TryParse(transactionDateString, out DateTime parsedTransactionDate))
                {
                    transactionDate = parsedTransactionDate;
                }
                if (decimal.TryParse(amountString, out decimal parsedAmount))
                {
                    amount = parsedAmount;
                }
                this.description = description;
                if (int.TryParse(accountIdString, out int parsedAccountId))
                {
                    accountId = parsedAccountId;
                }

                // Set the values of text boxes with the extracted cell values
                textBox2.Text = transactionDate.ToString();
                textBox3.Text = amount.ToString();
                textBox4.Text = description;
                textBox1.Text = accountId.ToString();


                // Update transaction only if there are changes
                using (var dbContext = new MMABooksContext())
                {
                    var transactionId = Convert.ToInt32(selectedRow.Cells["TransactionId"].Value);
                    var transactionToUpdate = dbContext.TransactionHistories.Find(transactionId);
                    if (transactionToUpdate != null)
                    {
                        // Update the properties of the existing transaction
                        transactionToUpdate.TransactionDate = DateTime.Parse(textBox2.Text);
                        transactionToUpdate.Amount = Convert.ToDecimal(textBox3.Text);
                        transactionToUpdate.Description = textBox4.Text;

                        dbContext.SaveChanges();

                        MessageBox.Show("Transaction updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Transaction not found.");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
