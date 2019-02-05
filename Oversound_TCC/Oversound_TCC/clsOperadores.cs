using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oversound_TCC
{
    class clsOperadores
    {
        static int idGlobal = 1;
        private int id;

        public int Id
        {
            get { return id; }
           // set { id = value; }
        }

        public string Nome { get; set; }

        public string Nome_Usuario { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Nome_Banda { get; set; }

        public clsOperadores()
        {
            id = idGlobal++;
        }






    }
}
