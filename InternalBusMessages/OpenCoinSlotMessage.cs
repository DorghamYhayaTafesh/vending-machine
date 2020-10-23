namespace VendingMachine.InternalBusMessages
{
    public class OpenCoinSlotMessage : BaseMessage
    {
        public int ProductType { set; get; }

    }
}
