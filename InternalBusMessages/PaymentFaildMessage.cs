namespace VendingMachine.InternalBusMessages
{
    public class PaymentFailedMessage : BaseMessage
    {
        public int Change { get; set; }
    }
}
