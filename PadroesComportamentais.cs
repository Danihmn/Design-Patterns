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
}