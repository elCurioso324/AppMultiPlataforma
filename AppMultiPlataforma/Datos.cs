using AppMultiPlataforma;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AppMultiPlataforma
{
    /// <summary>
    /// La siguiente clace permite mantener en memoria los datos registrados hasta el cierre de la aplicación
    /// </summary>
    public class Datos
    {
        /// <summary>
        /// La lista contendra los datos de los estudiantes registrados
        /// </summary>
        
        private static ClassUser[] userList = new ClassUser[50];
        private static ClassUser superUsuario = new ClassUser() ;

        internal ClassUser[] UserList { get => userList; set => userList = value; }
        internal ClassUser SuperUsuario { get => superUsuario; set => superUsuario = value; }
    }
}
