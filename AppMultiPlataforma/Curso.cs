

namespace AppMultiPlataforma
{
    internal class Curso
    {
        private string codigo;
        private string asignatura;

        public Curso()
        {
            this.codigo = "";
            this.asignatura = "";
        }

        public Curso(string codigo, string asignatura)
        {
            this.codigo = codigo;
            this.asignatura = asignatura;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Asignatura { get => asignatura; set => asignatura = value; }
    }
}
