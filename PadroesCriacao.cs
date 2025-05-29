namespace PadroesCriacao
{
    // Singleton----------------------------------------------------
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

    // Factory Method----------------------------------------------------
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

    // Abstract Factory----------------------------------------------------

    // Interfaces
    public interface IFabricaAbstrata // Interface da fábrica
    {
        // Métodos dos produtos a serem criados/implementados
        public IProdutoA CriarProdutoA();
        public IProdutoB CriarProdutoB();
    }

    // Interfaces dos produtos
    public interface IProdutoA
    {
        public void ExibirInfo();
    }

    public interface IProdutoB
    {
        public void ExibirInfo();
    }

    // Classes que implementam as interfaces
    class ProdutoA1 : IProdutoA
    {
        public void ExibirInfo()
        {
            Console.WriteLine("ProdutoA1");
        }
    }

    class ProdutoA2 : IProdutoA
    {
        public void ExibirInfo()
        {
            Console.WriteLine("ProdutoA2");
        }
    }

    class ProdutoB1 : IProdutoB
    {
        public void ExibirInfo()
        {
            Console.WriteLine("ProdutoB1");
        }
    }

    class ProdutoB2 : IProdutoB
    {
        public void ExibirInfo()
        {
            Console.WriteLine("ProdutoB2");
        }
    }

    // Classe fábrica
    class Fabrica1 : IFabricaAbstrata
    {
        public IProdutoA CriarProdutoA()
        {
            return new ProdutoA1();
        }

        public IProdutoB CriarProdutoB()
        {
            return new ProdutoB1();
        }
    }

    class Fabrica2 : IFabricaAbstrata
    {
        public IProdutoA CriarProdutoA()
        {
            return new ProdutoA2();
        }

        public IProdutoB CriarProdutoB()
        {
            return new ProdutoB2();
        }
    }

    // Builder----------------------------------------------------
    public class Carro
    {
        // Atribuições de um carro
        public string motor { get; set; }
        public int numeroRodas { get; set; }
        public string cor { get; set; }

        // Método que retorna a string final
        public string ParaString()
        {
            return $"Carro com motor: {motor}, {numeroRodas} rodas e cor {cor}";
        }
    }

    // Define o que será feito
    public interface InterfaceCarroBuilder
    {
        void DefinirMotor(string motor);
        void DefinirRodas(int rodas);
        void DefinirCor(string cor);

        Carro ObterResultado(); // Retorna o carro construído
    }

    class ConstrutorDeCarro : InterfaceCarroBuilder
    {
        // Instanciando a classe para obter as variáveis
        private Carro _carro = new Carro(); // Produto a ser construído

        public void DefinirMotor(string motor)
        {
            _carro.motor = motor;
        }

        public void DefinirRodas(int rodas)
        {
            _carro.numeroRodas = rodas;
        }

        public void DefinirCor(string cor)
        {
            _carro.cor = cor;
        }

        public Carro ObterResultado()
        {
            Carro resultado = _carro;
            _carro = new Carro(); // Garante que o próximo carro será novo
            return resultado;
        }
    }

    // Gerenciador de construções
    public class DiretorCarro
    {
        // Definindo que o _builder apenas pode ser atribuído uma vez com o readonly, é uma constante
        private readonly InterfaceCarroBuilder _builder;

        public DiretorCarro(InterfaceCarroBuilder builder)
        {
            _builder = builder;
        }

        public void CarroEsportivo()
        {
            _builder.DefinirMotor("V12");
            _builder.DefinirRodas(4);
            _builder.DefinirCor("Branco");
        }

        public void CarroRally()
        {
            _builder.DefinirMotor("V8");
            _builder.DefinirRodas(4);
            _builder.DefinirCor("Azul");
        }
    }
}