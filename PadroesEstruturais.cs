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
}
