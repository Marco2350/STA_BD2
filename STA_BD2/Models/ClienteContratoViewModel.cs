namespace STA_BD2.Models
{
    public class ClienteContratoViewModel
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Numero { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int TipoClienteId { get; set; }
        public int PaqueteId { get; set; }
        public int TecnicoId { get; set; }
        public int CuentaBancariaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
