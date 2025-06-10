using PadroesComportamentais;
using PadroesCriacao;
using PadroesEstruturais;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            /*
            Padrões de criação: 
            
            PadroesCriacao.PadraoSingleton(); // Singleton
            PadroesCriacao.AbstractFactory(); // Abstract Factory
            PadroesCriacao.Builder(); // Builder
            PadroesCriacao.Prototype(); // Prototype
            */

            /*
            Padrões estruturais
            PadroesEstruturais.Adapter(); // Adapter
            PadroesEstruturais.Bridge(); // Bridge
            PadroesEstruturais.Composite(); // Composite
            PadroesEstruturais.Decorator(); // Decorator
            PadroesEstruturais.Facade(); // Facade
            PadroesEstruturais.FlyWeight(); // FlyWeight
            PadroesEstruturais.VirtualProxy(); // Virtual Proxy
            PadroesComportamentais.Iterator(); // Iterator
            PadroesComportamentais.Observer(); // Observer
            */

            PadroesComportamentais.Strategy();
        }
    }

    class PadroesCriacao
    {
        public static void PadraoSingleton()
        {
            // Singleton----------------------------------------------------
            Console.WriteLine("Singleton----------------------------------------------------");

            Singleton obj1 = Singleton.Instanciar();
            Singleton obj2 = Singleton.Instanciar();

            Console.WriteLine(obj1 == obj2); // True

            // Factory Method----------------------------------------------------
            Console.WriteLine("Factory Method----------------------------------------------------");

            FabricaProduto fabrica = new FabricaProduto1();
            ModeloProduto modelo = fabrica.CriarProduto();
            modelo.ExibirInfo(); // Exibindo o produto 1

            fabrica = new FabricaProduto2();
            modelo = fabrica.CriarProduto();
            modelo.ExibirInfo(); // Exibindo o produto 2
        }

        public static void FactoryMethod()
        {
            FabricaProduto fabrica = new FabricaProduto1(); // Criando a fabrica do produto 1

            // Chamando o método de criar o produto 1
            ModeloProduto produto1 = fabrica.CriarProduto();
            produto1.ExibirInfo(); // Exibindo

            // Chamando o método de criar o produto 1
            fabrica = new FabricaProduto2();
            ModeloProduto produto2 = fabrica.CriarProduto();
            produto2.ExibirInfo(); // Exibindo
        }

        public static void AbstractFactory()
        {
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
        }

        public static void Builder()
        {
            // Builder----------------------------------------------------
            Console.WriteLine("Builder----------------------------------------------------");

            InterfaceConstrutorCarro builder = new ConstrutorCarroEsportivo();
            Diretor diretor = new Diretor(builder);
            diretor.ConstruirCarro(); // Manda construir o carro

            Carro carro = builder.ObterCarroConstruido(); // Define o carro já construído na variável carro
            carro.Exibir();
        }

        public static void Prototype()
        {
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

    class PadroesEstruturais
    {
        public static void Adapter()
        {
            // Instanciando novo adaptador, recebendo como parâmetro o dispositivo USB criado
            InterfaceAdaptador_HDMI adaptador = new USBParaHDMI(new Dispositivo_USB());
            adaptador.LigarHDMI(); // Exibindo
        }

        public static void Bridge()
        {
            // Instância do método de criação do bolo pertencente da interface
            InterfaceBolo bolo = new CriacaoBolo();

            // Adicionando à classe de abstração a instância do método bolo
            Abstracao adicaoIngrediente1 = new IngredienteAdicional1(bolo);

            // Adicionando à classe de abstração a instância do método bolo
            Abstracao adicaoIngrediente2 = new IngredienteAdicional2(bolo);

            // Exibindo todos os ingredientes, tanto padrões quanto adicionais
            Console.WriteLine(adicaoIngrediente2.FazerBolo());
        }

        public static void Composite()
        {
            // Criando uma raiz que será a pai
            ComponentesComFilhos raiz = new ComponentesComFilhos("Raiz");

            // Adicionando interfaces filhas
            raiz.Adicionar(new ComponentesFinais("Filho 1"));
            raiz.Adicionar(new ComponentesFinais("Filho 2"));
            raiz.Adicionar(new ComponentesFinais("Filho 3"));

            // Criando outro componente que terá filhos
            ComponentesComFilhos subRaiz = new ComponentesComFilhos("Sub Raiz");

            // Adicionando interfaces filhas
            subRaiz.Adicionar(new ComponentesFinais("Filho 1"));
            subRaiz.Adicionar(new ComponentesFinais("Filho 2"));
            subRaiz.Adicionar(new ComponentesFinais("Filho 3"));

            // Adicionando na raiz principal a subRaiz que tem outros componentes filho
            raiz.Adicionar(subRaiz);

            raiz.Exibir(1); // Exibindo o resultado final da árvore
        }

        public static void Decorator()
        {
            // Criando novo café simples
            InterfaceCafe cafe = new CafeSimples();

            // Exibindo os componentes do café simples
            Console.WriteLine(cafe.ExibirDescricao());
            Console.WriteLine(cafe.ExibirValor().ToString("C")); // Formata em reais

            // Definindo que agora a interface cafe será cafe com leite
            cafe = new CafeComLeite(cafe);

            // Exibindo os valores após ele ter sido modificado
            Console.WriteLine(cafe.ExibirDescricao());
            Console.WriteLine(cafe.ExibirValor().ToString("C")); // Formata em reais
        }

        public static void Facade()
        {
            // Instancia a classe que liga e desliga tudo
            Automacao automacao = new Automacao();

            // Chamando os métodos
            automacao.LigarTudo();
            automacao.DesligarTudo();
        }

        public static void FlyWeight()
        {
            // Criando nova fábrica de impressões, que conterá
            FabricaDeImpressao fabrica = new FabricaDeImpressao();

            // Criando o elemento de impressão 1
            var Impressao1 = fabrica.ObterElementos("A");
            Impressao1.ImprimirElemento(1);

            // Criando o elemento de impressão 2
            var Impressao2 = fabrica.ObterElementos("B");
            Impressao2.ImprimirElemento(2);

            // Criando o elemento de impressão 3
            var Impressao3 = fabrica.ObterElementos("A");
            Impressao3.ImprimirElemento(3);

            // Exibindo os elementos criados
            fabrica.Listar();
        }

        public static void VirtualProxy()
        {
            // Cria um Proxy para monitorar a conexão com o banco
            InterfaceObjetivo proxy = new VirtualProxy(); // Nesse momento, exibe a conexão com o banco de dados

            // Chama o método de acesso ao banco
            proxy.Solicitar();
            proxy.Solicitar();
        }
    }

    class PadroesComportamentais
    {
        public static void Iterator()
        {
            // Crian um novo objeto da classe Mochila
            Mochila minhaMochila = new Mochila();

            // Adiciona alguns lápis
            minhaMochila.AdicionarLapis("Vermelho");
            minhaMochila.AdicionarLapis("Azul");
            minhaMochila.AdicionarLapis("Verde");
            minhaMochila.AdicionarLapis("Rosa");
            minhaMochila.AdicionarLapis("Marrom");
            minhaMochila.AdicionarLapis("Preto");
            minhaMochila.AdicionarLapis("Dourado");

            // Chama o método do iterador, para percorrer a lista de lápis
            var iterador = minhaMochila.CriarIterador();

            Console.WriteLine("Lápis que estão na mochila: ");

            // enquanto ela não for totalmente percorrida
            while (iterador.TemProximo())
            {
                // Armazena na string o próximo índice da lista
                string lapis = iterador.Proximo();
                Console.WriteLine($"Peguei o lápis: {lapis}");
            }
        }

        public static void Observer()
        {
            Jornal jornal = new Jornal(); // Possui os assinantes o observando

            // Cria os assinantes
            Assinante1 assinante1 = new Assinante1();
            Assinante2 assinante2 = new Assinante2();

            // Os adiciona na lista
            jornal.Adicionar(assinante1);
            jornal.Adicionar(assinante2);

            // Fez alteração no jornal
            jornal.Notificar("Nova matéria");
        }

        public static void Strategy()
        {
            // Cria nova instância já com a primeira estratégia de combate
            Contexto contexto = new Contexto(new EstrategiaEspada());
            contexto.ExecutarEstrategia();

            // Trocou de fase
            contexto.DefinirEstrategia(new EstrategiaEspingarda());
            contexto.ExecutarEstrategia();

            // Trocou de fase
            contexto.DefinirEstrategia(new EstrategiaCanhao());
            contexto.ExecutarEstrategia();
        }
    }
}