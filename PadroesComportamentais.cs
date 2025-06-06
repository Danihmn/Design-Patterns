namespace PadroesComportamentais
{
    // Iterator----------------------------------------------------
    #region Interface do iterador - Definir quais os m�todos para percorrer a lista
    public interface InterfaceIterador<T>
    {
        // O Iterador precisa ter um m�todo para verificar se h� um pr�ximo elemento a ser percorrido
        bool TemProximo(); // Tem pr�ximo?

        // Precisa ter um m�todo para retornar o pr�ximo valor a ser percorrido
        T Proximo(); // Me da o pr�ximo
    }
    #endregion

    #region Mochila (cole��o) - Obter a lista de l�pis, o m�todo de adicionar � lista novos l�pis, retornar a lista e chamar o percorredor da lista
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

    #region Iterador da mochila - Verifica se a classe foi percorrida, se n�o, percorrer
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
}