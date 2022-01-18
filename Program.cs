namespace InternetShop
{
    public abstract class Delivery
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryOpenDate { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        private Client Client { get; set; }
        protected string DeliveryAddress { get; set; }
        private int DeliveryAmount { get; set; }
        protected int DeliverySummPaied { get; set; }
        public bool IsDelFullyPaied { get; set; }
        public Currency OrderCurrency { get; set; }
        public string DeliveryDescription { get; set; }
        public DateTime DeliveryCloseDate { get; set; }

        public Delivery (int DeliveryID, DateTime DeliveryOpenDate, DateTime DeliveryDateTime, Client Client, string DeliveryAddress, 
                        int DeliveryAmount, int DeliverySummPaied, Currency OrderCurrency, string DeliveryDescription) 
        { 
        this.DeliveryId = DeliveryID;
            this.DeliveryOpenDate = DeliveryOpenDate;
            this.DeliveryDateTime = DeliveryDateTime;   
            this.Client = Client;
            this.DeliveryAddress = DeliveryAddress;
            this.DeliveryAmount = DeliveryAmount;
            this.DeliverySummPaied = DeliverySummPaied;
            this.OrderCurrency = OrderCurrency;
            this.DeliveryDescription = DeliveryDescription; 
            IsDelFullyPaied =  DeliverySummPaied >= DeliveryAmount ? true : false;
            
        }


    }

    public class Payment
    {
        public Currency PaymentCurrency;
        public int PaiedSummOfOrder;
        public int OrderSumm;
        public DateTime PaymentDateTime;
        public int PaymentAmount;
        public int PaymentDocNumber;
        public int OrderPaymentBalance;
        public enum PaymentMethod
    {
        cash,
        card,
        wire
    }
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

        public Person(string name)
        {
            Name = name;
        }

        public void DisplayName()
        {
            Console.WriteLine(Name);
        }

    }

    public class Human : Person
    {
        public string SurName;
        public string FatherName;
        public DateOnly Birthday;
        public bool IsMarried;
        public byte ChildrenQuantity;

        public Human(string name, string SurName, string FatherName, DateOnly Birthday, bool IsMarried, byte ChildrenQuantity) : base(name)
        {
            this.IsMarried = IsMarried;
            this.SurName = SurName;
            this.FatherName = FatherName;
            this.Birthday = Birthday;
            this.ChildrenQuantity = ChildrenQuantity;
        }
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

   

    public abstract class Currency
    { //что то тут дописать что бы карренси агрегировал фиатные карренси , крипто карренси, электронные деньги.
        public string CurrencyID;
        public string CurrencyFullName;
        public string CountryOfCurrency;

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
    // добавить классы для адреса и мобильного телефона, дописать переопределение виртуальных методов для аккаунта абстрактного,
    // добавить свойства и конструкторы классов с параметрами, статических классов или элементов, сделать мод доступа прайвит для данных класса важных
    public class Product
    {
        public int ProductID;
        public string ProductName;
        public string ProductDescription;
        public string ProductCategory;
        public int ProductCategoryID;
        public string ProductCategoryName;
        public string ProductCategoryDescription;
        public int ProductPrice;
    }


    public class ShoppingCart
    {
        private Product[] cart;
        public ShoppingCart(Product[] cart)
        {
            this.cart = cart;
        }
        // Индексатор по массиву покупательской корзины для заказа
        public Product this[int index]
        {
            get
            {
                // Проверяем, чтобы индекс был в диапазоне для массива товаров карзины
                if (index >= 0 && index < cart.Length)
                {
                    return cart[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                // Проверяем, чтобы индекс был в диапазоне для массива товаров карзины
                if (index >= 0 && index < cart.Length)
                {
                    cart[index] = value;
                }
            }
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            var array = new Product[]
            {
    new Product
    {
        ProductID = 1,
        ProductName = "Computer",
        ProductDescription = "Computer for gamers",
        ProductCategory = "Home technic",
        ProductCategoryID = 23,
        ProductCategoryName = "Peaple hometechnik for person",
        ProductCategoryDescription = "Home technic applayencies",
        ProductPrice = 1000,

    },
    new Product
    {
            ProductID = 2,
            ProductName = "Monitor",
            ProductDescription = "Monitor for gamers",
            ProductCategory = "Home Electronic",
            ProductCategoryID = 30,
            ProductCategoryName = "Peaple homeelectronic for person",
            ProductCategoryDescription = "Home electronic applayencies",
            ProductPrice = 500,
    },
            };
            ShoppingCart cart = new ShoppingCart(array);

            Product Product = cart[1];
        }
    }
}

