namespace VendingMachine.InternalBusMessages
{
    public class PaymentRecievedMessage : BaseMessage
    {
        public int ProductType { set; get; }
        public decimal Change { get; set; }

    }
}
