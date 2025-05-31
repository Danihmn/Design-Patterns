using System.Text;

namespace PadroesCriacao
{
    // Singleton----------------------------------------------------
    public class Singleton
    {
        private static Singleton instancia; // Variavel que obter� a inst�ncia da pr�pria classe

        // Construtor privado para impedir cria��o de novas inst�ncias
        private Singleton() { }// M�todo que criar� a inst�ncia
        public static Singleton Instanciar() // Funcionar� como ponto global, acess�vel de qualquer lugar do c�digo
        {
            // Se n�o houver inst�ncia, cria uma
            if (instancia == null)
                instancia = new Singleton();

            return instancia; // Se j� houver inst�ncia, retorna ela
        }
    }

    // Factory Method----------------------------------------------------
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

    // Abstract Factory----------------------------------------------------

    // Interfaces
    public interface IFabricaAbstrata // Interface da f�brica
    {
        // M�todos dos produtos a serem criados/implementados
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

    // Classe f�brica
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
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public string Cor { get; set; }

        public void Exibir()
        {
            Console.WriteLine("Novo carro constru�do\n");

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Modelo: " + Modelo);
            stringBuilder.AppendLine("Motor: " + Motor);
            stringBuilder.AppendLine("Cor: " + Cor);

            Console.WriteLine(stringBuilder);
        }
    }

    public interface InterfaceConstrutorCarro
    {
        void ConstruirModelo();
        void ConstruirMotor();
        void ConstruirCor();
        Carro ObterCarroConstruido();
    }

    public class ConstrutorCarroEsportivo : InterfaceConstrutorCarro
    {
        Carro _carro = new Carro();

        public void ConstruirModelo()
        {
            _carro.Modelo = "Chevrolet Camaro";
        }

        public void ConstruirMotor()
        {
            _carro.Motor = "V8";
        }

        public void ConstruirCor()
        {
            _carro.Cor = "Amarelo";
        }

        public Carro ObterCarroConstruido()
        {
            return _carro; // Retornando o carro constru�do
        }
    }

    public class Diretor
    {
        readonly InterfaceConstrutorCarro _builder;

        public Diretor(InterfaceConstrutorCarro builder)
        {
            _builder = builder;
        }

        public void ConstruirCarro()
        {
            _builder.ConstruirModelo();
            _builder.ConstruirMotor();
            _builder.ConstruirCor();
        }
    }

    // Prototype----------------------------------------------------
    abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    class PrototypeConcreto : Prototype
    {
        private string _atributo;

        public PrototypeConcreto(string atributo)
        {
            _atributo = atributo;
        }

        public override Prototype Clone()
        {
            return new PrototypeConcreto(_atributo);
        }

        public void DefinirAtributo(string atributo)
        {
            _atributo = atributo;
        }

        public void ExibirAtributo()
        {
            Console.WriteLine($"Atributo: {_atributo}");
        }
    }
}