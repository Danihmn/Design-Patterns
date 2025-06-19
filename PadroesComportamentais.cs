namespace PadroesComportamentais
{
    // Iterator----------------------------------------------------
    #region Interface do iterador - Definir quais os metodos para percorrer a lista
    public interface InterfaceIterador<T>
    {
        // O Iterador precisa ter um m�todo para verificar se h� um pr�ximo elemento a ser percorrido
        bool TemProximo(); // Tem pr�ximo?

        // Precisa ter um m�todo para retornar o pr�ximo valor a ser percorrido
        T Proximo(); // Me da o pr�ximo
    }
    #endregion

    #region Mochila (colecao) - Obter a lista de lapis, o m�todo de adicionar a lista novos lapis, retornar a lista e chamar o percorredor da lista
    public class Mochila
    {
        // Lista que armazenar� os l�pis
        private List<string> lapis = new List<string>();

        public void AdicionarLapis(string cor)
        {
            lapis.Add(cor); // Adicionar lapis na lista
        }

        // M�todo para retornar a lista, ser� usado para percorrer a lista
        public List<string> ObterLapis()
        {
            return lapis; // Retorna a lista de lapis
        }

        // M�todo com o valor da interface do iterador, possuindo o m�todo TemProximo e Proximo
        public InterfaceIterador<string> CriarIterador() // Servie para de fato chamar a classe que percorre a lista
        {
            // Passa seu pr�prio m�todo objeto na inst�ncia
            return new MochilaIterador(this);
        }
    }
    #endregion

    #region Iterador da mochila - Verifica se a classe foi percorrida, se nao, percorrer
    // Incrementa a interface para possuir os m�todos de verificar e percorrer a lista
    class MochilaIterador : InterfaceIterador<string>
    {
        private Mochila mochila; // Armazena uma classe de mochila

        // Valor que ser� usado para percorrer a lista de lapis
        private int posicao = 0;

        public MochilaIterador(Mochila mochila)
        {
            // Atribuir o valor da inst�ncia � vari�vel
            this.mochila = mochila;
        }

        // M�todo para verificar se a lista j� foi toda percorrida
        public bool TemProximo()
        {
            // Retorna True ou False caso o contador de posi��o esteja ou n�o no fim da lista
            return posicao < mochila.ObterLapis().Count;
        }

        public string Proximo()
        {
            // Retorna o �ndice da lista de l�pis correspondente ao contador 
            return mochila.ObterLapis()[posicao++];
        }
    }
    #endregion

    // Observer----------------------------------------------------
    #region Interface que cada classe de assinante herdar�
    interface InterfaceAssitantes
    {
        void Atualizar(object dados);
    }
    #endregion

    #region Classe do jornal
    class Jornal // Quando atualizado, todos os assinantes s�o notificados
    {
        // Armazena as classes de assinantes assinantes
        private List<InterfaceAssitantes> assinantes = new List<InterfaceAssitantes>();

        public void Adicionar(InterfaceAssitantes assinante)
        {
            assinantes.Add(assinante);
        }

        public void Remover(InterfaceAssitantes assinante)
        {
            assinantes.Remove(assinante);
        }

        public void Notificar(object dados)
        {
            // Percorre a lista
            foreach (var assinante in assinantes)
            {
                // Para cada assinante, chama sua fun��o de atualizar
                assinante.Atualizar(dados);
            }
        }
    }
    #endregion

    #region Assinantes
    class Assinante1 : InterfaceAssitantes
    {
        public void Atualizar(object dados)
        {
            Console.WriteLine("Atualiza��es do assinante 1: " + dados);
        }
    }

    class Assinante2 : InterfaceAssitantes
    {
        public void Atualizar(object dados)
        {
            Console.WriteLine("Atualiza��es do assinante 2: " + dados);
        }
    }

    class Assinante3 : InterfaceAssitantes
    {
        public void Atualizar(object dados)
        {
            Console.WriteLine("Atualiza��es do assinante 3: " + dados);
        }
    }
    #endregion

    // Strategy----------------------------------------------------
    #region Interface das estrat�gias de ataque
    interface Estrategia
    {
        // Cada personagem ter� alguma estrat�gia de ataque
        void ExecutarAtaque();
    }
    #endregion

    #region Estrat�gias implementadoras da interface
    class EstrategiaEspada : Estrategia
    {
        public void ExecutarAtaque()
        {
            Console.WriteLine("Ataque com espada!");
        }
    }

    class EstrategiaEspingarda : Estrategia
    {
        public void ExecutarAtaque()
        {
            Console.WriteLine("Ataque com espingarda!");
        }
    }

    class EstrategiaCanhao : Estrategia
    {
        public void ExecutarAtaque()
        {
            Console.WriteLine("Ataque com canh�o!");
        }
    }
    #endregion

    #region Local que define qual a estrat�gia usada
    class Contexto
    {
        private Estrategia estrategia;

        public Contexto(Estrategia estrategia)
        {
            this.estrategia = estrategia;
        }

        public void DefinirEstrategia(Estrategia estrategia)
        {
            // Insere na vari�vel o valor da nova estrat�gia que for passada na inst�ncia
            this.estrategia = estrategia;
        }

        public void ExecutarEstrategia()
        {
            this.estrategia.ExecutarAtaque();
        }
    }
    #endregion

    // Command----------------------------------------------------
    #region Interface dos comandos
    interface InterfaceComando
    {
        void Executar(); // Delega que haver� um comando a ser executado
    }
    #endregion

    #region Class que tem a l�gica de ligar e desligar a TV
    class TV
    {
        public void Ligar()
        {
            Console.WriteLine("TV ligada");
        }

        public void Desligar()
        {
            Console.WriteLine("TV desligada");
        }
    }
    #endregion

    #region Comandos concretos para desligar e ligar a TV
    class DesligarTV : InterfaceComando
    {
        private TV tv;

        public DesligarTV(TV tv)
        {
            this.tv = tv;
        }

        public void Executar()
        {
            tv.Desligar();
        }
    }

    class LigarTV : InterfaceComando
    {
        private TV tv;

        public LigarTV(TV tv)
        {
            this.tv = tv;
        }

        public void Executar()
        {
            tv.Ligar();
        }
    }
    #endregion

    #region Classe do controle remoto
    class ControleRemoto
    {
        // Onde ser�o inseridos os comandos
        private Dictionary<string, InterfaceComando> comandos = new Dictionary<string, InterfaceComando>();

        public void DefinirComando(string botao, InterfaceComando comando)
        {
            // Apenas atribui sem o m�todo Add para que os valores possam ser substitu�dos
            comandos[botao] = comando;
        }

        public void PressionarBotao(string botao)
        {
            if (comandos.ContainsKey(botao))
                comandos[botao].Executar();
        }
    }
    #endregion

    // State----------------------------------------------------
    #region Interface dos m�todos do fluxo de venda
    interface InterfaceEstado
    {
        // Delega que o fluxograma da m�quina ter� a parte de pagamento, sele��o de produtos e retirada
        void InserirPagamento(MaquinaDeVendas maquina);
        void SelecionarProduto(MaquinaDeVendas maquina);
        void RetirarProduto(MaquinaDeVendas maquina);
    }
    #endregion

    // Implementa��es concretas das trocas de estado
    #region Classe que muda o estado da m�quina para uma nova venda
    class AguardandoPagamento : InterfaceEstado
    {
        public void InserirPagamento(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Moeda inserida, selecione o produto");
            maquina.DefinirEstado(new AguardandoSelecao()); // Muda o estado quando o pagamento for feito
        }

        public void SelecionarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Primeiro insira o pagamento");
        }

        public void RetirarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Primeiro insira o pagamento");
        }
    }
    #endregion

    #region Classe que muda o estado da m�quina para selecionar o produto
    class AguardandoSelecao : InterfaceEstado
    {
        public void InserirPagamento(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Pagamento j� inserido, selecione o produto");
        }

        public void SelecionarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Produto selecionado! Dispensando o produto...");
            maquina.DefinirEstado(new AguardandoRetirada()); // Muda o estado quando o produto for selecionado
        }

        public void RetirarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Primeiro selecione um produto");
        }
    }
    #endregion

    #region Classe que muda o estado do produto para uma nova venda novamente
    class AguardandoRetirada : InterfaceEstado
    {
        public void InserirPagamento(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Aguarde, o produto est� sendo dispensado");
        }

        public void SelecionarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Aguarde, o produto est� sendo dispensado");
        }

        public void RetirarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Produto retirado!");
            maquina.DefinirEstado(new AguardandoPagamento()); // Volta para o estado inicial quando a venda for finalizada
        }
    }
    #endregion

    #region Classe da m�quina
    class MaquinaDeVendas
    {
        // Armazena a interface
        private InterfaceEstado estado;

        public MaquinaDeVendas()
        {
            this.estado = new AguardandoPagamento(); // Come�a no estado inicial do fluxo
        }

        // Onde � definido o novo estado no fluxo
        public void DefinirEstado(InterfaceEstado novoEstado)
        {
            estado = novoEstado;
        }

        #region M�todos da interface
        public void InserirPagamento()
        {
            estado.InserirPagamento(this);
        }

        public void SelecionarProduto()
        {
            estado.SelecionarProduto(this);
        }

        public void RetirarProduto()
        {
            estado.RetirarProduto(this);
        }
        #endregion
    }
    #endregion

    // Template Method----------------------------------------------------
    abstract class Relatorios
    {
        public void ProcessarRelatorio()
        {
            // Chama todos os m�todos do relat�rio
            ConectarBanco();
            BuscarDados();
            GerarRelatorioPDF();
            EnviarRelatorio();
        }

        #region Metodos padrao do processo de gerar relatorios
        protected void ConectarBanco()
        {
            Console.WriteLine("Acesso ao banco de dados");
        }

        protected void GerarRelatorioPDF()
        {
            Console.WriteLine("Relat�rio PDF criado");
        }

        protected void EnviarRelatorio()
        {
            Console.WriteLine("Relat�rio PDF enviado por e-mail");
        }

        // Ser� implementado pois pode variar de acordo com a busca
        protected abstract void BuscarDados();
        #endregion
    }

    #region Implementacoes das variacoes de busca de dados
    // Compras por cliente
    class ComprasPorCliente : Relatorios
    {
        protected override void BuscarDados()
        {
            Console.WriteLine("Dados de compras por cliente encontrados");
        }
    }

    // Produtos vendidos por per�odo
    class ProdutosVendidosPorPeriodo : Relatorios
    {
        protected override void BuscarDados()
        {
            Console.WriteLine("Dados de produtos vendidos por per�odo encontrados");
        }
    }
    #endregion

    // Chain of Responsibility----------------------------------------------------
    #region Interface do suporte
    interface ISuporte
    {
        ISuporte PassarAoProximo(ISuporte suporte); // Passa ao pr�ximo manipulador
        void SolicitacaoDeSuporte(int nivel); // Atende a solicita��o
    }
    #endregion

    #region Classe do suporte onde tem a logica de passar ao proximo ou executar o suporte
    abstract class Suporte : ISuporte
    {
        private ISuporte _ProximoSuporte; // Armazena um manipulador

        // L�gica de passar ao pr�ximo manipulador
        public ISuporte PassarAoProximo(ISuporte suporte)
        {
            _ProximoSuporte = suporte;
            return suporte;
        }

        // L�gica de atender ao pedido de acordo com o n�vel do problema
        public virtual void SolicitacaoDeSuporte(int nivel)
        {
            if (_ProximoSuporte != null)
                _ProximoSuporte.SolicitacaoDeSuporte(nivel);
        }
    }
    #endregion

    #region Implementacoes concretas da classe de suporte
    class SuporteNivel1 : Suporte
    {
        public override void SolicitacaoDeSuporte(int nivel)
        {
            if (nivel == 1)
                Console.WriteLine("Suporte de n�vel 1 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }

    class SuporteNivel2 : Suporte
    {
        public override void SolicitacaoDeSuporte(int nivel)
        {
            if (nivel == 2)
                Console.WriteLine("Suporte de n�vel 2 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }

    class SuporteNivel3 : Suporte
    {
        public override void SolicitacaoDeSuporte(int nivel)
        {
            if (nivel == 3)
                Console.WriteLine("Suporte de n�vel 3 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }
    #endregion

    // Mediator----------------------------------------------------
    #region Interfae do mediador, delega o que o chat mediador dever� implementar
    interface IMediator
    {
        void EnviarMensagem(string mensagem, Usuario usuario);
        void AdicionarUsuario(Usuario usuario);
    }
    #endregion

    #region Mediador, define a logica de quem envia e quem recebe
    class Chat : IMediator
    {
        private List<Usuario> _usuarios; // Armazena os usu�rios

        public Chat()
        {
            _usuarios = new List<Usuario>(); // Inicializa a lista
        }

        // M�todo que apenas faz quem n�o enviou a mensagem receb�-la
        public void EnviarMensagem(string mensagem, Usuario usuario)
        {
            foreach (var u in _usuarios)
            {
                // �nico que n�o recebe � o passado no par�metro, o resto da lista sim
                if (u != usuario)
                    u.ReceberMensagem(mensagem); // Chama o m�todo apenas para aqueles que n�o sejam igual ao que enviou a mensagem
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario); // Adiciona � lista
        }
    }
    #endregion

    #region Classe abstrata responsavel por armazenar e delegar o que cada usuario faz
    abstract class Usuario
    {
        protected IMediator _mediador; // Armazena refer�ncia para a interface
        protected string _nome;

        public Usuario(IMediator mediador, string nome)
        {
            _mediador = mediador;
            _nome = nome;
        }

        // Todos podem enviar e receber mensagens
        public abstract void EnviarMensagem(string mensagem);
        public abstract void ReceberMensagem(string mensagem);
    }
    #endregion

    #region Classe implementadora da superclasse de usuarios
    class UsuarioConcreto : Usuario
    {
        public UsuarioConcreto(IMediator mediador, string nome) : base(mediador, nome) { } // Herda o construtor da superclasse

        public override void EnviarMensagem(string mensagem)
        {
            Console.WriteLine(_nome + " enviou " + mensagem);
            _mediador.EnviarMensagem(mensagem, this); // Chama o m�todo da classe do chat, passando seu pr�prio objeto no par�metro
        }

        public override void ReceberMensagem(string mensagem)
        {
            // S� aparecer� para aqueles que n�o enviaram mensagem
            Console.WriteLine(_nome + " recebeu " + mensagem);
        }
    }
    #endregion

    // Memento----------------------------------------------------
    #region Memento
    class Memento
    {
        public string Estado { get; private set; } // Vers�o do texto

        public Memento(string estado)
        {
            Estado = estado;
        }
    }
    #endregion

    #region Originator
    class EditorTexto
    {
        public string Texto { get; set; } // Texto em si

        public Memento Salvar()
        {
            return new Memento(Texto);
        }

        public void Restaurar(Memento memento)
        {
            Texto = memento.Estado;
        }
    }
    #endregion

    #region CareTaker
    class Historico
    {
        private Stack<Memento> _historico = new Stack<Memento>();

        public void Adicionar(Memento memento)
        {
            _historico.Push(memento);
        }

        public void Desfazer()
        {
            _historico.Pop(); // Tira o �ltimo elememento armazenado na pilha, volta para a anterior
        }
    }
    #endregion

    // Visitor----------------------------------------------------
    #region Metodos que todo o fiscal tem
    interface IFiscal
    {
        void VisitarSetorFinanceiro(SetorFinanceiro financeiro);
        void VisitarSetorFabricacao(SetorFabrica fabrica);
        void VisitarSetorTI(SetorTI ti);
    }
    #endregion

    #region Insercao de diversos fiscais de forma flexivel
    class FiscalDedetizacao : IFiscal
    {
        public void VisitarSetorFinanceiro(SetorFinanceiro financeiro)
        {
            Console.WriteLine("Fiscal de dedetiza��o visitou o setor: " + financeiro.NomeSetor());
        }

        public void VisitarSetorFabricacao(SetorFabrica fabrica)
        {
            Console.WriteLine("Fiscal de dedetiza��o visitou o setor: " + fabrica.NomeSetor());
        }

        public void VisitarSetorTI(SetorTI ti)
        {
            Console.WriteLine("Fiscal de dedetiza��o visitou o setor: " + ti.NomeSetor());
        }
    }

    class FiscalSegurancaDoTrabalho : IFiscal
    {
        public void VisitarSetorFinanceiro(SetorFinanceiro financeiro)
        {
            Console.WriteLine("Fiscal de seguran�a do trabalho visitou o setor: " + financeiro.NomeSetor());
        }

        public void VisitarSetorFabricacao(SetorFabrica fabrica)
        {
            Console.WriteLine("Fiscal de seguran�a do trabalho visitou o setor: " + fabrica.NomeSetor());
        }

        public void VisitarSetorTI(SetorTI ti)
        {
            Console.WriteLine("Fiscal de seguran�a do trabalho visitou o setor: " + ti.NomeSetor());
        }
    }
    #endregion

    #region Metodos que todo o setor tem
    interface ISetor
    {
        void Aceitar(IFiscal fiscal);
    }
    #endregion

    #region Implementacao dos setores
    class SetorFinanceiro : ISetor
    {
        public void Aceitar(IFiscal fiscal)
        {
            // Passa seu pr�prio objeto como par�metro
            fiscal.VisitarSetorFinanceiro(this);
        }

        public string NomeSetor()
        {
            return "Setor do financeiro";
        }
    }

    class SetorFabrica : ISetor
    {
        public void Aceitar(IFiscal fiscal)
        {
            // Passa seu pr�prio objeto como par�metro
            fiscal.VisitarSetorFabricacao(this);
        }

        public string NomeSetor()
        {
            return "Setor de fabrica��o";
        }
    }

    class SetorTI : ISetor
    {
        public void Aceitar(IFiscal fiscal)
        {
            // Passa seu pr�prio objeto como par�metro
            fiscal.VisitarSetorTI(this);
        }

        public string NomeSetor()
        {
            return "Setor de TI";
        }
    }
    #endregion
}