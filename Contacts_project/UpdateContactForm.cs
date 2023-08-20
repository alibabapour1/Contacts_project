using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Contacts_project
{
    public partial class UpdateContactForm : Form
    {
        private Contacts _contact;

        public UpdateContactForm(Contacts contact)
        {
            InitializeComponent();
            _contact = contact;
            // Set initial values of textboxes based on _contact properties
            textBox1.Text = _contact.Name;
            textBox2.Text = _contact.LastName;
            textBox3.Text = _contact.Address;
            textBox4.Text = _contact.PhoneNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update the properties of _contact with values from textboxes
            _contact.Name = textBox1.Text;
            _contact.LastName = textBox2.Text;
            _contact.Address = textBox3.Text;
            _contact.PhoneNumber = textBox4.Text;
            // Close the form with DialogResult.OK to indicate successful update
            DialogResult = DialogResult.OK;
        }
    }
}
