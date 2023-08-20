using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_project
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           

        }
        ContactsDbContext db = new ContactsDbContext();

        private void button1_Click(object sender, EventArgs e)
        {
            var newcontact = new Contacts 
            {
                Address = textBox3.Text,
                Name = textBox1.Text,
                LastName = textBox2.Text,
                PhoneNumber = textBox4.Text
             };
            
            
            try
            {
                db.Contacts.Add(newcontact);
                db.SaveChanges();
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
            Form1 form1 = new Form1();
            form1.Close();
            MessageBox.Show("Contact Saved Succesfuly !");
            

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db.Dispose();
        }
    }
}
