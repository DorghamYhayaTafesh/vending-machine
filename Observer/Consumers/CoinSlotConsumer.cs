namespace VendingMachine.Observer

{
    class CoinSlotConsumer: BaseConsumer
    {
        //public void consume(OpenCointSlotMessage message)
        //{
        //    // here we consume the coins Slot message, open the slot and ask the user to enter the money. 
        //    // this will validate the amount of entered money if it is a valid 10c • 20c • 50c • $1.
        //    // if the user didn't add money in 20 seconds or added  not valid amount, an "OperationFailedMessage" should be publish with the amounr he entered (if any).
              // if the user added a valid amount, the item price ( from the message body) should taken from the money and a "PaymentRecieved" Message should be publish with the amount of the change from the total amount of money (amount of money - item price).
        //}
    }
}
