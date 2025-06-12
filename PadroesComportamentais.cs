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
}