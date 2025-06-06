﻿using System.Text;

namespace PadroesEstruturais
{
    // Adapter----------------------------------------------------
    interface InterfaceDispositivo_USB // Interface do USB
    {
        void Ligar(); // Método ilustrando o USB funcionando
    }

    // Implementando a interface com um novo dispositivo USB
    class Dispositivo_USB : InterfaceDispositivo_USB
    {
        public void Ligar()
        {
            Console.WriteLine("Dispositivo USB funcionando"); // Exibindo
        }
    }

    interface InterfaceAdaptador_HDMI // Interface onde o USB será convertido
    {
        void LigarHDMI(); // Método ilustrativo
    }

    class USBParaHDMI : InterfaceAdaptador_HDMI // Criando um novo adaptador HDMI
    {
        private Dispositivo_USB _dispositivo_USB; // Inserindo em uma variável um dispositivo USB a ser adaptado

        // Conversão
        public USBParaHDMI(Dispositivo_USB dispositivo_USB)
        {
            _dispositivo_USB = dispositivo_USB;
        }

        public void LigarHDMI()
        {
            Console.WriteLine("Dispositivo USB ligado no adaptador HDMI");
        }
    }

    // Bridge----------------------------------------------------
    interface InterfaceBolo
    {
        string FazerBolo(); // Delegando que um bolo será feito
    }

    class CriacaoBolo : InterfaceBolo
    {
        // StringBuilder que terá os ingredientes do bolo
        public StringBuilder builderBolo = new StringBuilder();

        public string FazerBolo()
        {
            // Inserindo no StringBuilder os ingredientes padrões de um bolo
            builderBolo.Append("Farinha, ");
            builderBolo.Append("Açúcar, ");
            builderBolo.Append("Ovo, ");
            builderBolo.Append("Leite");

            string bolo = builderBolo.ToString(); // Converte o StringBuilder em string
            return bolo; // Retorna ao método da interface a string dos ingredientes
        }
    }

    class Abstracao
    {
        // Inserindo em variável uma interface de um bolo
        protected InterfaceBolo _interfaceBolo;

        public Abstracao(InterfaceBolo interfaceBolo)
        {
            _interfaceBolo = interfaceBolo;
        }

        // Método que permite novas alterações
        public virtual string FazerBolo()
        {
            return _interfaceBolo.FazerBolo();
        }
    }

    class IngredienteAdicional1 : Abstracao
    {
        // Herdando o construtor da classe primitiva
        public IngredienteAdicional1(InterfaceBolo interfaceBolo) : base(interfaceBolo) { }

        public override string FazerBolo()
        {
            // Retornando a string com um novo ingrediente adicional
            return base.FazerBolo() + ", Extrato de baunilha";
        }
    }

    class IngredienteAdicional2 : IngredienteAdicional1
    {
        // Herdando o construtor da classe primitiva
        public IngredienteAdicional2(InterfaceBolo interfaceBolo) : base(interfaceBolo) { }

        public override string FazerBolo()
        {
            // Retornando a string com um novo ingrediente adicional
            return base.FazerBolo() + ", Gotas de chocolate";
        }
    }

    // Composite----------------------------------------------------
    interface IComponente // Todo o componente criado possuirá
    {
        // Exibindo no terminal
        void Exibir(int profundidade); // O int profundidade será usado para ilustrar hierarquias
    }

    class ComponentesFinais : IComponente
    {
        private string nome; // Nome que cada componente possuirá

        public ComponentesFinais(string nome)
        {
            this.nome = nome; // Atribuindo o valor da instância na variável
        }

        // Exibindo o valor final
        public void Exibir(int profundidade)
        {
            // "-" repete na linha conforme o valor de profundidade,e no final exibe o nome
            Console.WriteLine(new String('-', profundidade) + nome);
        }
    }

    // Componentes que possuirão filhos
    class ComponentesComFilhos : IComponente
    {
        public string nome; // Nome que cada componente possuirá
        public List<IComponente> filhos = new List<IComponente>(); // Lista onde serão adicionados os componentes filhos

        public ComponentesComFilhos(string nome)
        {
            this.nome = nome; // Atribuindo o valor da instância na variável
        }

        public void Adicionar(IComponente filho)
        {
            filhos.Add(filho); // Adiciona outras interfaces filho na lista
        }

        public void Remover(IComponente filho)
        {
            filhos.Remove(filho); // Remove da lista de interfaces
        }

        // Exibindo no terminal
        public void Exibir(int profundidade)
        {
            // "-" repete na linha conforme o valor de profundidade,e no final exibe o nome
            Console.WriteLine(new String('-', profundidade) + nome);

            // Percorrendo a lista de interfaces filho para exibir as hierarquias
            foreach (var filho in filhos)
            {
                // Chama o método de exibir de cada interface encontrada
                filho.Exibir(profundidade + 3); // Adiciona 3 em profundidade a cada hierarquia para melhor compreensão de hierarquias
            }
        }
    }

    // Decorator----------------------------------------------------
    interface InterfaceCafe
    {
        // Métodos padrão que todo tipo de café terá
        string ExibirDescricao();
        double ExibirValor();
    }

    // Implementador primário da interface, serão criados novos cafés a partir dele
    class CafeSimples : InterfaceCafe
    {
        // Implementando os métodos básicos
        public string ExibirDescricao()
        {
            // Exibindo o nome
            return "Café";
        }

        public double ExibirValor()
        {
            // Exibindo o valor
            return 1.50;
        }
    }

    // O decorador é o que permitirá com que outros cafés sejam criados a partir do simples
    class DecoradorCafe : InterfaceCafe
    {
        // Armazenando uma interface em uma variável
        protected InterfaceCafe cafe;

        public DecoradorCafe(InterfaceCafe cafe)
        {
            // Atribue o valor da instância à variável
            this.cafe = cafe;
        }

        // Os métodos virtuais serão reescritos, é onde serão feitos os novos cafés a partir do simples
        public virtual string ExibirDescricao()
        {
            // Retorna o método de exibir a descrição da variável que receberá a interface na instância
            return cafe.ExibirDescricao();
        }

        public virtual double ExibirValor()
        {
            // Retorna o método de exibir a descrição da variável que receberá a interface na instância
            return cafe.ExibirValor();
        }
    }

    // Novo café que será feito a partir do simples
    class CafeComLeite : DecoradorCafe
    {
        // Herda o construtor da classe primitiva
        public CafeComLeite(InterfaceCafe cafe) : base(cafe) { }

        // Reescrevendo os métodos
        public override string ExibirDescricao()
        {
            // Alterando a descrição
            return cafe.ExibirDescricao() + " com leite";
        }

        public override double ExibirValor()
        {
            // Alterando o valor
            return cafe.ExibirValor() + 1.20;
        }
    }

    // Facade----------------------------------------------------
    class Luzes
    {
        // Método de ligar
        public void Ligar()
        {
            Console.WriteLine("Luzes ligadas");
        }

        // Método de desligar
        public void Desligar()
        {
            Console.WriteLine("Luzes desligadas");
        }
    }

    class ArCondicionado
    {
        // Método de ligar
        public void Ligar()
        {
            Console.WriteLine("Ar condicionado ligadas");
        }

        // Método de desligar
        public void Desligar()
        {
            Console.WriteLine("Ar condicionado desligadas");
        }
    }

    class Som
    {
        // Método de ligar
        public void Ligar()
        {
            Console.WriteLine("Som ligadas");
        }

        // Método de desligar
        public void Desligar()
        {
            Console.WriteLine("Som desligadas");
        }
    }

    // Classe que inicializa todos os eletrônicos para ligar e desligar eles
    class Automacao
    {
        // Readonly permite que o valor seja atribuído depois da declaração, porém também só pode ser atribuído uma só vez
        private readonly Luzes luzes;
        private readonly ArCondicionado arCondicionado;
        private readonly Som som;

        public Automacao()
        {
            // Inicializa todas as instâncias
            luzes = new Luzes();
            arCondicionado = new ArCondicionado();
            som = new Som();
        }

        // Método que liga tudo
        public void LigarTudo()
        {
            luzes.Ligar();
            arCondicionado.Ligar();
            som.Ligar();
        }

        // Método que desliga tudo
        public void DesligarTudo()
        {
            luzes.Desligar();
            arCondicionado.Desligar();
            som.Desligar();
        }
    }

    // Flyweight----------------------------------------------------
    interface InterfaceImprimirElementos // Imprimindo elementos gráficos em papéis
    {
        // Cada elemento tem sua posição no papel
        void ImprimirElemento(int posicaoElemento);
    }

    class NovoElemento : InterfaceImprimirElementos
    {
        private string Elemento; // String que irá armazenar o elemento

        public NovoElemento(string posicaoElemento)
        {
            // Atribue o valor da instância no elemento
            Elemento = posicaoElemento;
        }

        // Exibindo
        public void ImprimirElemento(int posicaoElemento)
        {
            // Exibe qual o elemento e em qual posição ele está na folha
            Console.WriteLine($"Elemento: {Elemento} na posição {posicaoElemento}");
        }
    }

    // Irá gerenciar o que irá imprimir
    class FabricaDeImpressao
    {
        // Dicionário que irá armazenar a posição dos elementos impressos
        private Dictionary<string, InterfaceImprimirElementos> Elementos = new Dictionary<string, InterfaceImprimirElementos>();

        // Método responsável por verificar se há ou não elementos já criados
        public InterfaceImprimirElementos ObterElementos(string chave)
        {
            // Caso no dicionário não contenha o elemento com a chave X
            if (!Elementos.ContainsKey(chave))
            {
                // Cria um novo elemento com a chave X
                Elementos[chave] = new NovoElemento(chave);
            }

            // Caso já o houver, retorna ele
            return Elementos[chave];
        }

        public void Listar()
        {
            // Exibe a quantidade de elementos diferentes impressos
            Console.WriteLine(Elementos.Count() + " Elementos impressos");

            // Percorre o dicionário dos elementos
            foreach (var elemento in Elementos)
            {
                // Exibe os elementos
                Console.WriteLine(elemento.Key);
            }
        }
    }

    // Proxy----------------------------------------------------
    interface InterfaceObjetivo
    {
        // Solicitar conexão com o banco de dados
        void Solicitar();
    }

    // Classe que cria e acessa a conexão com o banco de dados
    class ObjetivoReal : InterfaceObjetivo
    {
        // Realiza a operação de conexão com o banco
        public ObjetivoReal() // Conexão é criada por um construtor logo na instância
        {
            // Operação cara
            Console.WriteLine("Conexão ao banco");
        }

        // Método que acessa de fato o banco de dados
        public void Solicitar() // Acesso ao banco deve ser solicitado separadamente
        {
            // Acessa o banco de dados
            Console.WriteLine("Objetivo real: Solicitação");
        }
    }

    class VirtualProxy : InterfaceObjetivo
    {
        // Armazena a classe que cria conexão com o banco e acessa o banco
        private ObjetivoReal _real;

        public void Solicitar()
        {
            // Se ainda não houver instância para criar a conexão com o banco de dados
            if (_real == null)
                _real = new ObjetivoReal(); // Cria conexão com o banco de dados

            // Se já houver objeto instanciado com a conexão com o banco de dados
            _real.Solicitar(); // Acessa o banco
        }
    }
}