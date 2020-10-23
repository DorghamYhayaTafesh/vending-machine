namespace VendingMachine.InternalBusMessages
{
    public class OpenNotesSlotMessage : BaseMessage
    {
        public int ProductType { set; get; }

    }
}
