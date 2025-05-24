namespace PadroesCriacao
{
    public class Singleton
    {
        private static Singleton instancia; // Variavel que obter� a inst�ncia da pr�pria classe

        // Construtor privado para impedir cria��o de novas inst�ncias
        private Singleton() { }

        /*Cria construtor privado pois no C#, se n�o houver expl�cita a cria��o de um, � automaticamente
         criado um construtor p�blico, permitindo com que outras inst�ncias fossem criadas*/

        // M�todo que criar� a inst�ncia
        public static Singleton Instanciar() // Funcionar� como ponto global, acess�vel de qualquer lugar do c�digo
        {
            // Se n�o houver inst�ncia, cria uma
            if (instancia == null)
                instancia = new Singleton();

            return instancia; // Se j� houver inst�ncia, retorna ela
        }
    }
}