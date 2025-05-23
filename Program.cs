namespace DesignPatterns
{
    public class Singleton
    {
        private static Singleton instancia; // Variavel que obterá a instância da própria classe

        // Construtor privado para impedir criação de novas instâncias
        private Singleton() { }

        /*Cria construtor privado pois no C#, se não houver explícita a criação de um, é automaticamente
         criado um construtor público, permitindo com que outras instâncias fossem criadas*/

        // Método que criará a instância
        public static Singleton Instanciar() // Funcionará como ponto global, acessível de qualquer lugar do código
        {
            // Se não houver instância, cria uma
            if (instancia == null)
                instancia = new Singleton();

            return instancia; // Se já houver instância, retorna ela
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton obj1 = Singleton.Instanciar();
            Singleton obj2 = Singleton.Instanciar();

            /*Essa forma de impedir que sejam instanciados diversos objetos permite que
             independente de quantas instâncias forem feitas, sempre será a mesma, visto
            que o método de instanciar na classe serve para criar se não houver, e se houver,
            retornará o valor do método como a própria instância já criada*/

            Console.WriteLine(obj1 == obj2); // True
        }
    }
}