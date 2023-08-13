using System;
using System.Collections.Generic;
using System.Text;

namespace AppMultiPlataforma
{
    class ClassUser
    {
        private string name;
        private string idUser;
        private string lastName1;
        private string lastName2;
        private DateTime bornDate;
        private string emailAddress;
        private string phoneNumber;
        private string password;
        private Curso[] cursos;

        public ClassUser()
        {
            this.name = "";
            this.idUser = "";
            this.lastName1 = "";
            this.lastName2 = "";
            this.bornDate = new DateTime();
            this.emailAddress = "";
            this.phoneNumber = "";
            this.password = "";
            this.cursos = new Curso[3];
        }
        public ClassUser(string name, string idUser, string lastName1, string lastName2, DateTime bornDate, string emailAddress, string phoneNumber, string password, Curso[] cursos)
        {
            this.name = name;
            this.idUser = idUser;
            this.lastName1 = lastName1;
            this.lastName2 = lastName2;
            this.bornDate = bornDate;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.cursos = cursos;
        }

        public string Name { get => name; set => name = value; }
        public string IdUser { get => idUser; set => idUser = value; }
        public string LastName1 { get => lastName1; set => lastName1 = value; }
        public string LastName2 { get => lastName2; set => lastName2 = value; }
        public DateTime BornDate { get => bornDate; set => bornDate = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Password { get => password; set => password = value; }
        public Curso[] Cursos { get => cursos; set => cursos = value; }
    }
}
