using PadroesCriacao;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Singleton----------------------------------------------------
            Console.WriteLine("Singleton----------------------------------------------------");

            Singleton obj1 = Singleton.Instanciar();
            Singleton obj2 = Singleton.Instanciar();

            /*Essa forma de impedir que sejam instanciados diversos objetos permite que
             independente de quantas instâncias forem feitas, sempre será a mesma, visto
            que o método de instanciar na classe serve para criar se não houver, e se houver,
            retornará o valor do método como a própria instância já criada*/

            Console.WriteLine(obj1 == obj2); // True

            // Factory Method----------------------------------------------------
            Console.WriteLine("Factory Method----------------------------------------------------");

            FabricaProduto fabrica = new FabricaProduto1();
            ModeloProduto modelo = fabrica.CriarProduto();
            modelo.ExibirInfo(); // Exibindo o produto 1

            fabrica = new FabricaProduto2();
            modelo = fabrica.CriarProduto();
            modelo.ExibirInfo(); // Exibindo o produto 2

            // Abstract Factory----------------------------------------------------
            Console.WriteLine("Abstract Factory----------------------------------------------------");

            IFabricaAbstrata fabricaAbstrata = new Fabrica1();
            IProdutoA produtoA1 = fabricaAbstrata.CriarProdutoA();
            IProdutoB produtoB1 = fabricaAbstrata.CriarProdutoB();

            produtoA1.ExibirInfo();
            produtoB1.ExibirInfo();

            IFabricaAbstrata fabricaAbstrata2 = new Fabrica2();
            IProdutoA produtoA2 = fabricaAbstrata2.CriarProdutoA();
            IProdutoB produtoB2 = fabricaAbstrata2.CriarProdutoB();

            produtoA2.ExibirInfo();
            produtoB2.ExibirInfo();

            // Builder----------------------------------------------------
            Console.WriteLine("Builder----------------------------------------------------");

            InterfaceConstrutorCarro builder = new ConstrutorCarroEsportivo();
            Diretor diretor = new Diretor(builder);
            diretor.ConstruirCarro(); // Manda construir o carro

            Carro carro = builder.ObterCarroConstruido(); // Define o carro já construído na variável carro
            carro.Exibir();

            // Prototype----------------------------------------------------
            Console.WriteLine("Prototype----------------------------------------------------");

            PrototypeConcreto prototipo = new PrototypeConcreto("Elemento 1"); // Criando o primeiro elemento
            PrototypeConcreto clone = (PrototypeConcreto)prototipo.Clone(); // Criando um novo elemento sendo cópia do primeiro

            // Mudando o valor da cópia
            clone.DefinirAtributo("Modificado");

            // Exibindo os protótipos
            prototipo.ExibirAtributo();
            clone.ExibirAtributo();
        }
    }
}