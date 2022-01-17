public abstract class Delivery
{
    public string DeliveryAddress;
    public int DeliveryId;
    public string DeliverySumm;
    public bool IsDelPaied;
    public bool IsPOSNeeded;
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
    public string ResidenceAdress;
    public byte PhoneNumber;
    public string DocName;
    public string DocNumber;
    public DateOnly DocIssueDate;
    public string WhoIssueDoc;

}

public class Human : Person
{
    public string SurName;
    public string FatherName;
    public DateOnly Birthday;
    public bool IsMarried;
    public byte ChildrenQuantity;
}

public class Company : Person
{
    public Human Director;
    public Human Accounter;
    public string BranchAdress;
    public string Accoutnumber;
    public string AccountBank;
    public string BankCorrespondent;
    public string BankAdress;
    public int VATNumber;
    public string RegistrationNumber;


}

public class Staff : Human
{
    public DateOnly HareDate;
    public DateOnly RetaingDate;
    public int StaffIDNumber;
}
public class Client : Person
{
    public string ClientID;
    private int CompanyClientAccountNumber;
    private int CompanyClientAccountBalance;
    public string CompanyClientAccountCurrency;
    public string CompanyClientAccountName;
    public DateTime CompanyClientAccOpenDate;
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

public class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int OrderNumber;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.DeliveryAddress);
    }

    // ... Другие поля
    public DateTime OrderDateTime;
    public Staff WhoTakeOrder;
    public bool IsDelivered;
    public bool IsGivenToCurrier;
    public Product[] OrderGoods;


}
// расписать ниже как в book индексаторе
public class Product
{
    public int ProductID;
    public string ProductName;
    public string ProductDescription;
    public string ProductCategory;
    public int ProductCategoryID;
    public int ProductCategoryName;
    public int ProductCategoryDescription;
    public int ProductPrice;
}