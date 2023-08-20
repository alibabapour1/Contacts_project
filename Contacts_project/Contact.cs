using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_project
{
    public partial class Contact : Form
    {
        ContactsDbContext _dbContext = new ContactsDbContext();
        public Contact()
        {
            InitializeComponent();
            LoadContacts();
        }
        private void LoadContacts()
        {
            contactsListBox.Items.Clear();
            var contacts = _dbContext.Contacts.ToList();
            foreach (var contact in contacts)
            {
                contactsListBox.Items.Add(contact);
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();

            form1.Show();

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedItem is Contacts selectedContact)
            {
                using (var updateForm = new UpdateContactForm(selectedContact))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            _dbContext.SaveChanges();
                            LoadContacts(); // Refresh the list
                        }
                        catch (DbUpdateException ex)
                        {
                            // Handle Entity Framework database update exception
                            // Log the exception, display a user-friendly error message, etc.
                            MessageBox.Show("Error updating the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            // Handle other exceptions (non-Entity Framework related)
                            // Log the exception, display a user-friendly error message, etc.
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (contactsListBox.SelectedItem is Contacts selectedContact)
            {
                try
                {
                    _dbContext.Contacts.Remove(selectedContact);
                    _dbContext.SaveChanges(); _dbContext.Contacts.Remove(selectedContact);
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Handle Entity Framework database update exception
                    // Log the exception, display a user-friendly error message, etc.
                    MessageBox.Show("Error updating the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (non-Entity Framework related)
                    // Log the exception, display a user-friendly error message, etc.
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadContacts();
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _dbContext.Dispose();
        }
    }
}
