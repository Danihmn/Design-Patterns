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
}