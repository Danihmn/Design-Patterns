namespace PadroesComportamentais
{
    // Iterator----------------------------------------------------
    #region Interface do iterador - Definir quais os metodos para percorrer a lista
    public interface InterfaceIterador<T>
    {
        // O Iterador precisa ter um método para verificar se há um próximo elemento a ser percorrido
        bool TemProximo(); // Tem próximo?

        // Precisa ter um método para retornar o próximo valor a ser percorrido
        T Proximo(); // Me da o próximo
    }
    #endregion

    #region Mochila (colecao) - Obter a lista de lapis, o método de adicionar a lista novos lapis, retornar a lista e chamar o percorredor da lista
    public class Mochila
    {
        // Lista que armazenará os lápis
        private List<string> lapis = new List<string>();

        public void AdicionarLapis(string cor)
        {
            lapis.Add(cor); // Adicionar lapis na lista
        }

        // Método para retornar a lista, será usado para percorrer a lista
        public List<string> ObterLapis()
        {
            return lapis; // Retorna a lista de lapis
        }

        // Método com o valor da interface do iterador, possuindo o método TemProximo e Proximo
        public InterfaceIterador<string> CriarIterador() // Servie para de fato chamar a classe que percorre a lista
        {
            // Passa seu próprio método objeto na instância
            return new MochilaIterador(this);
        }
    }
    #endregion

    #region Iterador da mochila - Verifica se a classe foi percorrida, se nao, percorrer
    // Incrementa a interface para possuir os métodos de verificar e percorrer a lista
    class MochilaIterador : InterfaceIterador<string>
    {
        private Mochila mochila; // Armazena uma classe de mochila

        // Valor que será usado para percorrer a lista de lapis
        private int posicao = 0;

        public MochilaIterador(Mochila mochila)
        {
            // Atribuir o valor da instância à variável
            this.mochila = mochila;
        }

        // Método para verificar se a lista já foi toda percorrida
        public bool TemProximo()
        {
            // Retorna True ou False caso o contador de posição esteja ou não no fim da lista
            return posicao < mochila.ObterLapis().Count;
        }

        public string Proximo()
        {
            // Retorna o índice da lista de lápis correspondente ao contador 
            return mochila.ObterLapis()[posicao++];
        }
    }
    #endregion

    // Observer----------------------------------------------------
    #region Interface que cada classe de assinante herdará
    interface InterfaceAssitantes
    {
        void Atualizar(object dados);
    }
    #endregion

    #region Classe do jornal
    class Jornal // Quando atualizado, todos os assinantes são notificados
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
                // Para cada assinante, chama sua função de atualizar
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
            Console.WriteLine("Atualizações do assinante 1: " + dados);
        }
    }

    class Assinante2 : InterfaceAssitantes
    {
        public void Atualizar(object dados)
        {
            Console.WriteLine("Atualizações do assinante 2: " + dados);
        }
    }

    class Assinante3 : InterfaceAssitantes
    {
        public void Atualizar(object dados)
        {
            Console.WriteLine("Atualizações do assinante 3: " + dados);
        }
    }
    #endregion

    // Strategy----------------------------------------------------
    #region Interface das estratégias de ataque
    interface Estrategia
    {
        // Cada personagem terá alguma estratégia de ataque
        void ExecutarAtaque();
    }
    #endregion

    #region Estratégias implementadoras da interface
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
            Console.WriteLine("Ataque com canhão!");
        }
    }
    #endregion

    #region Local que define qual a estratégia usada
    class Contexto
    {
        private Estrategia estrategia;

        public Contexto(Estrategia estrategia)
        {
            this.estrategia = estrategia;
        }

        public void DefinirEstrategia(Estrategia estrategia)
        {
            // Insere na variável o valor da nova estratégia que for passada na instância
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
        void Executar(); // Delega que haverá um comando a ser executado
    }
    #endregion

    #region Class que tem a lógica de ligar e desligar a TV
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
        // Onde serão inseridos os comandos
        private Dictionary<string, InterfaceComando> comandos = new Dictionary<string, InterfaceComando>();

        public void DefinirComando(string botao, InterfaceComando comando)
        {
            // Apenas atribui sem o método Add para que os valores possam ser substituídos
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
    #region Interface dos métodos do fluxo de venda
    interface InterfaceEstado
    {
        // Delega que o fluxograma da máquina terá a parte de pagamento, seleção de produtos e retirada
        void InserirPagamento(MaquinaDeVendas maquina);
        void SelecionarProduto(MaquinaDeVendas maquina);
        void RetirarProduto(MaquinaDeVendas maquina);
    }
    #endregion

    // Implementações concretas das trocas de estado
    #region Classe que muda o estado da máquina para uma nova venda
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

    #region Classe que muda o estado da máquina para selecionar o produto
    class AguardandoSelecao : InterfaceEstado
    {
        public void InserirPagamento(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Pagamento já inserido, selecione o produto");
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
            Console.WriteLine("Aguarde, o produto está sendo dispensado");
        }

        public void SelecionarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Aguarde, o produto está sendo dispensado");
        }

        public void RetirarProduto(MaquinaDeVendas maquina)
        {
            Console.WriteLine("Produto retirado!");
            maquina.DefinirEstado(new AguardandoPagamento()); // Volta para o estado inicial quando a venda for finalizada
        }
    }
    #endregion

    #region Classe da máquina
    class MaquinaDeVendas
    {
        // Armazena a interface
        private InterfaceEstado estado;

        public MaquinaDeVendas()
        {
            this.estado = new AguardandoPagamento(); // Começa no estado inicial do fluxo
        }

        // Onde é definido o novo estado no fluxo
        public void DefinirEstado(InterfaceEstado novoEstado)
        {
            estado = novoEstado;
        }

        #region Métodos da interface
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
            // Chama todos os métodos do relatório
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
            Console.WriteLine("Relatório PDF criado");
        }

        protected void EnviarRelatorio()
        {
            Console.WriteLine("Relatório PDF enviado por e-mail");
        }

        // Será implementado pois pode variar de acordo com a busca
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

    // Produtos vendidos por período
    class ProdutosVendidosPorPeriodo : Relatorios
    {
        protected override void BuscarDados()
        {
            Console.WriteLine("Dados de produtos vendidos por período encontrados");
        }
    }
    #endregion

    // Chain of Responsibility----------------------------------------------------
    #region Interface do suporte
    interface ISuporte
    {
        ISuporte PassarAoProximo(ISuporte suporte); // Passa ao próximo manipulador
        void SolicitacaoDeSuporte(int nivel); // Atende a solicitação
    }
    #endregion

    #region Classe do suporte onde tem a logica de passar ao proximo ou executar o suporte
    abstract class Suporte : ISuporte
    {
        private ISuporte _ProximoSuporte; // Armazena um manipulador

        // Lógica de passar ao próximo manipulador
        public ISuporte PassarAoProximo(ISuporte suporte)
        {
            _ProximoSuporte = suporte;
            return suporte;
        }

        // Lógica de atender ao pedido de acordo com o nível do problema
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
                Console.WriteLine("Suporte de nível 1 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }

    class SuporteNivel2 : Suporte
    {
        public override void SolicitacaoDeSuporte(int nivel)
        {
            if (nivel == 2)
                Console.WriteLine("Suporte de nível 2 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }

    class SuporteNivel3 : Suporte
    {
        public override void SolicitacaoDeSuporte(int nivel)
        {
            if (nivel == 3)
                Console.WriteLine("Suporte de nível 3 atendeu ao problema");
            else
                base.SolicitacaoDeSuporte(nivel);
        }
    }
    #endregion

    // Mediator----------------------------------------------------
    #region Interfae do mediador, delega o que o chat mediador deverá implementar
    interface IMediator
    {
        void EnviarMensagem(string mensagem, Usuario usuario);
        void AdicionarUsuario(Usuario usuario);
    }
    #endregion

    #region Mediador, define a logica de quem envia e quem recebe
    class Chat : IMediator
    {
        private List<Usuario> _usuarios; // Armazena os usuários

        public Chat()
        {
            _usuarios = new List<Usuario>(); // Inicializa a lista
        }

        // Método que apenas faz quem não enviou a mensagem recebê-la
        public void EnviarMensagem(string mensagem, Usuario usuario)
        {
            foreach (var u in _usuarios)
            {
                // Único que não recebe é o passado no parâmetro, o resto da lista sim
                if (u != usuario)
                    u.ReceberMensagem(mensagem); // Chama o método apenas para aqueles que não sejam igual ao que enviou a mensagem
            }
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario); // Adiciona à lista
        }
    }
    #endregion

    #region Classe abstrata responsavel por armazenar e delegar o que cada usuario faz
    abstract class Usuario
    {
        protected IMediator _mediador; // Armazena referência para a interface
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
            _mediador.EnviarMensagem(mensagem, this); // Chama o método da classe do chat, passando seu próprio objeto no parâmetro
        }

        public override void ReceberMensagem(string mensagem)
        {
            // Só aparecerá para aqueles que não enviaram mensagem
            Console.WriteLine(_nome + " recebeu " + mensagem);
        }
    }
    #endregion

    // Memento----------------------------------------------------
    #region Memento
    class Memento
    {
        public string Estado { get; private set; } // Versão do texto

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
            _historico.Pop(); // Tira o último elememento armazenado na pilha, volta para a anterior
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
            Console.WriteLine("Fiscal de dedetização visitou o setor: " + financeiro.NomeSetor());
        }

        public void VisitarSetorFabricacao(SetorFabrica fabrica)
        {
            Console.WriteLine("Fiscal de dedetização visitou o setor: " + fabrica.NomeSetor());
        }

        public void VisitarSetorTI(SetorTI ti)
        {
            Console.WriteLine("Fiscal de dedetização visitou o setor: " + ti.NomeSetor());
        }
    }

    class FiscalSegurancaDoTrabalho : IFiscal
    {
        public void VisitarSetorFinanceiro(SetorFinanceiro financeiro)
        {
            Console.WriteLine("Fiscal de segurança do trabalho visitou o setor: " + financeiro.NomeSetor());
        }

        public void VisitarSetorFabricacao(SetorFabrica fabrica)
        {
            Console.WriteLine("Fiscal de segurança do trabalho visitou o setor: " + fabrica.NomeSetor());
        }

        public void VisitarSetorTI(SetorTI ti)
        {
            Console.WriteLine("Fiscal de segurança do trabalho visitou o setor: " + ti.NomeSetor());
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
            // Passa seu próprio objeto como parâmetro
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
            // Passa seu próprio objeto como parâmetro
            fiscal.VisitarSetorFabricacao(this);
        }

        public string NomeSetor()
        {
            return "Setor de fabricação";
        }
    }

    class SetorTI : ISetor
    {
        public void Aceitar(IFiscal fiscal)
        {
            // Passa seu próprio objeto como parâmetro
            fiscal.VisitarSetorTI(this);
        }

        public string NomeSetor()
        {
            return "Setor de TI";
        }
    }
    #endregion
}