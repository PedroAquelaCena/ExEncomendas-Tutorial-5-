using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex0Order.Entities
{
    internal class Client
    {
        public string Name { get;private set; }
        private string email;
        private DateTime birthDate;

        public Client(string name, string email, DateTime birthDate)
        {
            this.Name = name;
            this.email = email;
            this.birthDate = birthDate;
        }

        public override string ToString()
        {
            return $"\n\nDados do cliente {Name}:\n\tE-mail --> {email};\n\tData de nascimento --> {birthDate.ToLongDateString()}";
        }
    }
}
