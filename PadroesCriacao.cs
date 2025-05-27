namespace PadroesCriacao
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

    public interface ModeloProduto
    {
        void ExibirInfo(); // Método a ser implementado
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
        ModeloProduto CriarProduto(); // Método a ser implementado
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