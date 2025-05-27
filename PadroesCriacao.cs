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

    public interface ModeloProduto
    {
        void ExibirInfo(); // M�todo a ser implementado
    }

    // Classe implementadora do produto 1
    public class Produto1 : ModeloProduto
    {
        public void ExibirInfo()
        {
            Console.WriteLine("Produto 1");
        }
    }

    // Classe implementadora do produto 2
    public class Produto2 : ModeloProduto
    {
        public void ExibirInfo()
        {
            Console.WriteLine("Produto 2");
        }
    }

    public interface FabricaProduto
    {
        ModeloProduto CriarProduto(); // M�todo a ser implementado
    }

    public class FabricaProduto1 : FabricaProduto
    {
        public ModeloProduto CriarProduto()
        {
            return new Produto1(); // Retorna novo produto 1 da interface
        }
    }

    public class FabricaProduto2 : FabricaProduto
    {
        public ModeloProduto CriarProduto()
        {
            return new Produto2(); // Retorna novo produto 2 da interface
        }
    }
}