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
}