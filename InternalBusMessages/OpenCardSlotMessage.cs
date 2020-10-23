namespace VendingMachine.InternalBusMessages
{
    public class OpenCardSlotMessage: BaseMessage
    {
        public int ProductType { set; get; }
    }
}
