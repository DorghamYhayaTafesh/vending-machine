namespace VendingMachine.Observer
{
    class CardSlotConsumer: BaseConsumer
    {
        //public void consume(OpenCardSlotMessage message)
        //{
        //    // here we consume the cardSlot message, open the slot and ask the user to enter his card. 
        //    // after the withrdawing process is done (the amount is the item price from the message body),
        //    // this will publish a new message (PaymentRecieved) to RabbitMQ that with the amount of recieved money and the change is ZERO.
        //}
    }
}
