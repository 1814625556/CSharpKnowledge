using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Annotations;
using WinFormTest.Entitys;

namespace WinFormTest
{
    public partial class BindingFormTest : Form
    {
        private BindingClass _viewModel; 
        public BindingFormTest()
        {
            InitializeComponent();
            _viewModel = new BindingClass()
            {
                Str1 = "initial",
                Str2 = "second",
                Str3 = "third",
                LoginBodys = new LoginBodyEntity()
                {
                    Name = "chen",
                    Password= "123"
                }
            };
            this.label1.DataBindings.Add("Text", _viewModel, "Str1", false, DataSourceUpdateMode.OnPropertyChanged);
            this.label2.DataBindings.Add("Text", _viewModel, "Str2", false, DataSourceUpdateMode.OnPropertyChanged);
            this.label3.DataBindings.Add("Text", _viewModel, "Str3", false, DataSourceUpdateMode.OnPropertyChanged);
            this.loginBody1.LoginBodyBindingDates(_viewModel.LoginBodys);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewModel.Str1 = "Baby";
            _viewModel.Str2 = "Love";
            _viewModel.Str3 = "Pig";
            _viewModel.LoginBodys.Name="zhang san";
            _viewModel.LoginBodys.Password = "1234";
            SetLabel4();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Hello";
            this.label2.Text = "World";
            this.label3.Text = "~~~";
            _viewModel.LoginBodys.Name = "lisi";
            _viewModel.LoginBodys.Password = "123456";
            SetLabel4();
        }

        private void SetLabel4()
        {
            this.label4.Text = $"{_viewModel.Str1},{_viewModel.Str2},{_viewModel.Str3}";
        }
    }

    public class BindingClass : INotifyPropertyChanged
    {
        
        private string str1;
        public string Str1
        {
            get => str1;
            set
            {
                str1 = value;
                OnPropertyChanged();
            }
        }
        private string str2;
        public string Str2
        {
            get => str2;
            set
            {
                str2 = value;
                OnPropertyChanged();
            }
        }
        private string str3;
        public string Str3
        {
            get => str3;
            set
            {
                str3 = value;
                OnPropertyChanged();
            }
        }

        //private LoginBodyEntity loginBody { get; set; }
        public LoginBodyEntity LoginBodys { get; set; }
        //{
        //    get => loginBody;
        //    set
        //    {
        //        loginBody = value;
        //        OnPropertyChanged();
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
