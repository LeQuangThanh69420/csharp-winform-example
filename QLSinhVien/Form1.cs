﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class Form1 : Form
    {
        QLSinhVienDataContext db = new QLSinhVienDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == txt_Username.Text);
            if (user == null)
            { 
                MessageBox.Show("Account not found");
                return;
            }
            if (user.Password == txt_Password.Text)
            {
                new FormSinhVien(this, user.Username).Show();
                this.Hide();
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckb_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = !ckb_ShowPassword.Checked;
        }
    }
}
