using System.Text;

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
}