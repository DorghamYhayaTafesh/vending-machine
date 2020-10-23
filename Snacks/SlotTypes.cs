using System.ComponentModel;

namespace VendingMachine.Snacks
{
    public enum SlotTypes
    {
        [Description("Coins Slot")]
        CoinSlot = 1,
        [Description("Cards Slot")]
        CardSlot = 2,
        [Description("Notes Slot")]
        NotesSlot = 3
    }
}
