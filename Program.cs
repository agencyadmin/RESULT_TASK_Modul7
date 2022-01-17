public abstract class Delivery
{
    public string Address;
}

public class Payment
{
    public string Currency;
    public string Balance;
    public string Fee;
    public int OrderSumm;
}

abstract public class Person
{
    public string Name;
    public string ResidanceAdress;
    public byte PhoneNumber;
}

public class Human : Person
{
    public string SurName;
    public string FatherName;
    public DateOnly Birthday;
}

public class Company : Person
{

}
abstract class Client : Person
{
    public string ID;
    public string Name;
    public string ResidenceAddress;
    public string DocNumber;
    public DateOnly DocIssueDate;
    public string DocName;
}

class HomeDelivery : Delivery
{
    /* ... */
}

class PickPointDelivery : Delivery
{
    /* ... */
}

class ShopDelivery : Delivery
{
    /* ... */
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    // ... Другие поля
    public DateTime OrderDateTime;
    public Staff;
}