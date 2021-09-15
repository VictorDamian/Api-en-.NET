using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentsModel
    {
        private int id;
        private string name;
        private string lastname;
        private string cellphone;

        public int _Id { get => id; set => id = value; }
        public string _Name { get => name; set => name = value; }
        public string _Lastname { get => lastname; set => lastname = value; }
        public string _Cellphone { get => cellphone; set => cellphone = value; }
    }
}
