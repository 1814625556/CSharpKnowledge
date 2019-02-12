using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Entitys;

namespace WinFormTest.UIControls
{
    public partial class LoginBody : UserControl
    {
        public LoginBody()
        {
            InitializeComponent();
        }

        private LoginBodyEntity viewModel;
        public void LoginBodyBindingDates(LoginBodyEntity entity)
        {
            //if(entity==null)
            //    entity= new LoginBodyEntity();
            viewModel = entity;
            this.txtName.DataBindings.Add("Text", viewModel, "Name",false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtPass.DataBindings.Add("Text", viewModel, "Password", false, DataSourceUpdateMode.OnPropertyChanged);//绑定属性
            this.LoginBtn.Click += new EventHandler(viewModel.LoginBtn);//绑定事件
        }

    }
}
