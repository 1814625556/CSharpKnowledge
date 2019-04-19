using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    public class Item
    {
        public static string PhoneNum { get; set; }
        protected int Age = 9;
        private string _address;
        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public string Name { get; set; }

        public Item(string name,string address,string phoneNum)
        {
            Name = name;
            _address = address;
            PhoneNum = phoneNum;
        }

        public void Method1()
        {
        }

        public void Method2()
        {
        }

        public void Method3()
        {
        }

        public static void Method4()
        {
        }
    }

}
