using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorizacia
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        public Form1()
        {
            InitializeComponent();
            
            //textBox2.MaxLength = 8
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            string querystring = $"insert into [user] values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, db.GetConnection());
            db.openConnection();

            if (Regex.IsMatch(textBox2.Text, @"^[@!][a-z][A-Z]$"))
            {
                MessageBox.Show("Аааа");
            }
            else
            {
                MessageBox.Show("Fffff");
            }
            
            if (command.ExecuteNonQuery() == 1)
            {


                checkuser();

            }
            

            db.closeConnection();

                


        }

        private Boolean checkuser()
        {
            string symb = "ABCDEFGHIJKLMNOPRSTUVWXYZabcdefghijklmnoprstuvwxyz1234567890!\"#$%&'()*+,-./::<=>?@[\\]:_{|}";
            if(textBox2.Text.IndexOfAny(symb.ToCharArray()) == -1 || textBox2.Text.Length < 8)
            {
                MessageBox.Show("Регистрация прошла успешно!", "АГА!");
                return true;
            }
            else
            {
                MessageBox.Show("Пароль должен состоять из 8 символов, включая буквы верхнего и нижнего регистров, а так же символы @,!", "Пароль не соответсвует правилам");
                return false;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string symb = "ABCDEFGHIJKLMNOPRSTUVWXYZ123456789!\"#$%&'()*+,-./::<=>?@[\\]:_{|}";
            if (textBox2.Text.IndexOfAny(symb.ToCharArray()) == -1 || textBox2.Text.Length < 8)
            {
                label3.ForeColor = System.Drawing.Color.Green;
                label3.Text = "OK";
            }
            else
            {
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "false";

            }
        }
    }
}
