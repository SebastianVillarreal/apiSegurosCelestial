namespace marcatel_api.Models

{
    public class TicketCreditoModel: TicketModel
    {
        public float Abonado { get; set; }
        public float Monto { get; set; }
        public int IdTicketCredito { get; set; }
    }
}