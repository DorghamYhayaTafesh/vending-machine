namespace VendingMachine.Observer

{
    class CoinSlotConsumer: BaseConsumer
    {
        //public void consume(OpenCointSlotMessage message)
        //{
        //    // here we consume the coins Slot message, open the slot and ask the user to enter the money. 
        //    // this will validate the amount of entered money if it is a valid 10c • 20c • 50c • $1.
        //    // if the user didn't add money in 20 seconds or added  not valid amount, an "OperationFailedMessage" should be publish with the amounr he entered (if any).
        //    // if the user added a valid amount, the item price ( from the message body) should taken from the money and a "PaymentRecieved" Message should be publish with the
        //    // amount of the change will be calculated based on Greedy Algorithm ( See Class CoinChange.cs)
        //    // the class CoinChange contains CalculateChange which takes a parameter of the required change (initial amount - product price) which will calculate the comming change if it returns empty list then there is no change and the operation ended.
        //    // the class contains all coins transfered to dollars so the cents are 0.1 dollar , 0.2 dollars, 0.5 dollars and there is an array contains the capacity of each of them in the vending machine based on their index in the previouse array.

        //}
    }
}
