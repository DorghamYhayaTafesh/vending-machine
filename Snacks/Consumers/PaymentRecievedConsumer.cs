namespace VendingMachine.Snacks.Consumers
{
    class PaymentRecievedConsumer
    {
        // this will consume the payment recieved message and complete the process. 
        // the rest of the process is: giving the user the change if any (from the message body) and for the give him the item he paied for ( from the message body).
        // call the vending machine factory and get the single instance of the machine .. and call the "TakeProductOut" and pass the product type from the message.
    }
}
