using PadroesCriacao;

namespace DesignPatterns
{
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