namespace InternetShop
{
public abstract class Delivery
{
    public int DeliveryId;
    public DateTime DeliveryOpenDate;
    public DateTime DeliveryDateTime;
    public Client Client;
    public string DeliveryAddress;
    public int DeliveryAmount;
    public string DeliverySummPaied;
    public bool IsDelFullyPaied;
    public Currency OrderCurrency;
    public string DeliveryDescription;
    public DateTime DeliveryCloseDate;


}

public class Payment
{
    public Currency PaymentCurrency;
    public int PaiedSummOfOrder;
    public int OrderSumm;
    public PaymentMethod PaymentMethod;
    public DateTime PaymentDateTime;
    public int PaymentAmount;
    public int PaymentDocNumber;
    public int OrderPaymentBalance;
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
    public byte Salary;
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

public class Partners : Company
{
    public int PartnerIDNumber;
    public int ContractIDNumber;
    public DateOnly ContractDate;
    public DateOnly ContractCloseDate;
    public int PartnerFee;
}

public class Curiers : Partners
{
    public int CuriersIDNumber;
    public DateTime CuriersDateContract;
    public DateTime CuriersCloseDateContract;
    public int CuriersFeeContract;
    public byte CuriersBalanceContract;
    public int CuriersOrdersQountity;
    public byte CurierRating;
    public string CurierDescription;
}

public abstract class Account
{
    public string AccountID;
    public string AccountName;
    public string AccountDescription;
    public string AccountType;
    public int AccountCurrency;
    public int AccountBalance;
    public DateTime AccountOpenDate;
    public DateTime AccountCloseDate;
}

public enum PaymentMethod
{
    cash,
    card,
    wire
}

public abstract class Currency
{ //что то тут дописать что бы карренси агрегировал фиатные карренси , крипто карренси, электронные деньги.


}

public class FiatCurrency : Currency
{
    public enum FiatCurrencyEnum
    {
        usd,
        byr,
        ryb,
        euro,
        chif,
        pound

    }
}

public class CryptoCurrency : Currency
{
    public enum CryptoCurrencyEnum
    {
        bitcoin,
        manero,
        bnb,
        Etherium

    }
}

public class ElectronicCurrency : Currency
{
    public enum ElectronicCurrencyEnum
    {
        webmoney,
        yandexmoney,
        manymailru,
        qiwi

    }
}
class HomeDelivery : Delivery
{
    /* ... */
    public Curiers Curier;
    public TimeOnly ClientWishTimeFrom;
    public TimeOnly ClientWishTimeTo;
    public bool IsPOSNeeded;
    public int EnterenceCode;
    public byte Floor;
    public bool IsLift;
    public byte AmountOfDeliveryTry;


}

class PickPointDelivery : Delivery
{
    /* ... */
    Partners PickPointPartner;
    public string PickPointName;
    public string PickPointDescription;
    public string PickPointAdress;
    public TimeOnly PickPointOpenDate;
    public TimeOnly PickPointCloseDate;
    public DateTime DeliveredToPickPoint;
    public DateTime TakeParcelDeadLine;
    public DateTime ReturnFromPickPoint;
}

class ShopDelivery : Delivery
{
    /* ... */
}

public class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int OrderNumber;

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
// расписать ниже как в book индексаторе, а так же можно добавить классы для адреса и мобильного телефона, дописать переопределение виртуальных методов,
// добавить свойства и конструкторы классов с параметрами, статических классов или элементов, сделать мод доступа прайвит для данных класса важных
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
}