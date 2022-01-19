namespace InternetShop
{
    public abstract class Delivery
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryOpenDate { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        private Client ClientForDelivery { get; set; }
        protected string DeliveryAddress { get; set; }
        private int DeliveryAmount { get; set; }
        protected int DeliverySummPaied { get; set; }
        public bool IsDelFullyPaied { get; set; }
        public Currency DeliveryOrderCurrency { get; set; }
        public string DeliveryDescription { get; set; }
        public DateTime DeliveryCloseDate { get; set; }
        public Delivery()
        {
            DeliveryId = 333000;
            DeliveryOpenDate = new DateTime();
            DeliveryDateTime = new DateTime();
            ClientForDelivery = new Client();
            DeliveryAddress = "Delivery Address is unknown";
            DeliveryAmount = 0;
            DeliverySummPaied = 0;
            DeliveryOrderCurrency = new Currency();
            DeliveryDescription = DeliveryDescription;
            IsDelFullyPaied = DeliverySummPaied >= DeliveryAmount ? true : false;
        }

        public Delivery(int DeliveryID, DateTime DeliveryOpenDate, DateTime DeliveryDateTime, Client ClientForDelivery, string DeliveryAddress,
                    int DeliveryAmount, int DeliverySummPaied, Currency OrderCurrency, string DeliveryDescription)
        {
            this.DeliveryId = DeliveryID;
            this.DeliveryOpenDate = DeliveryOpenDate;
            this.DeliveryDateTime = DeliveryDateTime;
            this.ClientForDelivery = ClientForDelivery;
            this.DeliveryAddress = DeliveryAddress;
            this.DeliveryAmount = DeliveryAmount;
            this.DeliverySummPaied = DeliverySummPaied;
            this.OrderCurrency = OrderCurrency;
            this.DeliveryDescription = DeliveryDescription;
            IsDelFullyPaied = DeliverySummPaied >= DeliveryAmount ? true : false;

        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.DeliveryAddress);
        }

    }

    public class Payment
    {
        public Currency PaymentCurrency { get; set; }
        public int PaiedSummOfOrder { get; set; }
        public int OrderSumm { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public int PaymentAmount { get; set; }
        public int PaymentDocNumber { get; set; }
        public int OrderPaymentBalance { get; set; }
        public enum PaymentMethod
        {
            cash,
            card,
            wire
        }
    }

    public abstract class Person
    {
        public string Name { get; set; }
        public string ResidenceAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string DocName { get; set; }
        public string DocNumber { get; set; }
        public DateOnly DocIssueDate { get; set; }
        public string WhoIssueDoc { get; set; }

        public Person()
        {
            Name = "unknown Name";
            ResidenceAdress = "unknown Adress";
            PhoneNumber = "unknown PhoneNumber";
            DocName = "unknown DocName";
            DocNumber = "unknown DocNumber";
            DocIssueDate = new DateOnly();
            WhoIssueDoc = "unknown WhoIssueDoc";
        }
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
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public DateOnly Birthday { get; set; }
        public bool IsMarried { get; set; }
        public byte ChildrenQuantity { get; set; }

        public Human()
        {

            SurName = "unknown SurName";
            FatherName = "unknown FatherName";
            Birthday = new DateOnly();
            IsMarried = false;
            ChildrenQuantity = 0;
        }
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
        public Human Director { get; set; } //Ассоциация в форме композиции
        public Human Accounter { get; set; }
        public string BranchAdress { get; set; }
        public string Accountnumber { get; set; }
        public string AccountBank { get; set; }
        public string BankCorrespondent { get; set; }
        public string BankAdress { get; set; }
        public int VATNumber { get; set; }
        public string RegistrationNumber { get; set; }

        public Company() : base()
        {
            this.Director = Director;
            this.Accounter = Accounter;
            this.BranchAdress = BranchAdress;
            this.Accountnumber = Accountnumber;
            this.AccountBank = AccountBank;
            this.BankCorrespondent = BankCorrespondent;
            this.BankAdress = BankAdress;
            this.VATNumber = VATNumber;
            this.RegistrationNumber = RegistrationNumber;

        }
        public Company(string name) : base(name)
        {
            Director = new Human("Ivanov", "Ivan", "Ivanovich", 01 - Jan - 01, true, 3); // Композиция
            Accounter = new Human("Jakovleva", "Svetlana", "Petrovna", 1976 - 03 - 19, true, 3);// Композиция
        }

        public Company(string name, Human Director, Human Accounter, string BranchAdress, string Accountnumber, string AccountBank, string BankCorrespondent,
           string BankAdress, int VATNumber, string RegistrationNumber) : base(name)
        {
            this.Director = Director;
            this.Accounter = Accounter;
            this.BranchAdress = BranchAdress;
            this.Accountnumber = Accountnumber;
            this.AccountBank = AccountBank;
            this.BankCorrespondent = BankCorrespondent;
            this.BankAdress = BankAdress;
            this.VATNumber = VATNumber;
            this.RegistrationNumber = RegistrationNumber;
        }
    }

    public class Staff : Human
    {
        public DateOnly HareDate;
        public DateOnly RetaingDate;
        public int StaffIDNumber { get; set; }
        public byte Salary;

        public Staff()
        {

            this.HareDate = new DateOnly();
            this.RetaingDate = new DateOnly();
            this.StaffIDNumber = 1;
            this.Salary = 0;

        }
        public Staff(string name, DateOnly HareDate, DateOnly RatingDate, int StaffIDNumber, byte Salary, string SurName, string FatherName,
            DateOnly Birthday, bool IsMarried, byte ChildrenQuantity) : base(name, SurName, FatherName, Birthday, IsMarried, ChildrenQuantity)
        {
            this.HareDate = HareDate;
            this.RetaingDate = RatingDate;
            this.Salary = Salary;
            this.StaffIDNumber = StaffIDNumber;
        }
    }

    public class Client : Human
    {
        public long ClientID
        {
            get
            {
                return ClientID;
            }
            set
            {
                if (CompanyClientAccountAmount <= value)
                {
                    ClientID = CompanyClientAccountAmount + 1000000000000;
                    CompanyClientAccountAmount++;
                }
                else
                {
                    ClientID = CompanyClientAccountAmount + 1000000000000;
                    ClientID = value + 1000000000000;
                }
            } // дописать логику что бы номер клиента шел по порядку и не повторялся с предыдущим клиентом
        protected internal int CompanyClientAccountNumber
        {
            get
            {
                return CompanyClientAccountNumber;
            }
            set
            {
                if (CompanyClientAccountAmount <= value)
                {
                    CompanyClientAccountNumber += CompanyClientAccountAmount;
                    CompanyClientAccountAmount++;
                }
                else
                {
                    CompanyClientAccountNumber = value;
                    CompanyClientAccountAmount++;
                }
            }
        }
        private int CompanyClientAccountBalance { get; set; }
        public FiatCurrency CompanyClientAccountCurrency { get; set; }
        public string CompanyClientAccountName { get; set; }
        public DateTime CompanyClientAccOpenDate { get; set; }
        public int CompanyClientAccountAmount { get; set; }

        public Client()
        {
            ClientID = 0;
            CompanyClientAccountAmount = 0; // общее количество клиентов приращиваеться на единицу каждый раз после создания нового, при присвоении
                                            // нового номера клиента в сетторе.
            CompanyClientAccountBalance = 0;
            CompanyClientAccountCurrency = new FiatCurrency();
            CompanyClientAccountName = "super new client has came";
            CompanyClientAccOpenDate = DateTime.Now;
            CompanyClientAccountAmount = 0;
        }
    }

    public class Partners<TClientType> where TClientType : Company //но партнером по идее может быть и человек, так что ограничение по типу универсальной
                                                                   //where TClientType : Human                           
                                                                   //можно и убрать в зависимости от бизнеслогики компании работает ли она со своими работниками как
                                                                   // с курьерами сторонними организациями или физическими лицами. Можно конечно было и не заводить 
                                                                   //переменную по учету общего количества клиентов но так удобнее и можно поле видимости шире сделать
                                                                   // но можно и не ограничивать тогда класс партнеры будут работать и с компаниями и с гражданами 

    {
        TClientType Partner = default(TClientType);
        public int PartnerIDNumber;
        public int ContractIDNumber;
        public DateOnly ContractDate;
        public DateOnly ContractCloseDate;
        public int PartnerFee;
        public Partners()
        {
            Partners<TClientType> Partner = new Partners<TClientType>();
            PartnerIDNumber = 2000;
            ContractIDNumber = 0;
            DateOnly ContractDate = new DateOnly();
            DateOnly ContractCloseDate = new DateOnly();
            PartnerFee = 2;

        }
    }

    public class Curiers<TCuriesIsEmployes> where TCuriesIsEmployes : Partners
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
        public Currency AccountCurrency;
        public int AccountBalance;
        public DateTime AccountOpenDate;
        public DateTime AccountCloseDate;
    }// реализовать этот класс счета для счетов клиентов, счетов сотрудников, счетов партнеров.

    public abstract class Transaction
    {
        public string TransactionID;
        public string TransactionType;
        public string TransactionAmount;
        public Currency TransactionCurrency;
        public Account TransactionSenderAccount;
        public string TransactionRecieverAccount;
    }



    public abstract class Currency
    { //что то тут дописать что бы карренси агрегировал фиатные карренси , крипто карренси, электронные деньги.
      // либо где надо использовать универсальный пораметр типа <TCurrency> где надо и вызывать конструктор уже конкретного класса по нужному типу
        public string CurrencyID;
        public string CurrencyFullName;
        public string CountryOfCurrency;

    }

    public class FiatCurrency : Currency
    {
        public int FiatCurrencyValue;
        public enum FiatCurrencyEnum
        {
            usd = 840,
            byr = 750,
            ryb = 375,
            euro = 220,
            chif = 348,
            pound = 465

        }
        public FiatCurrency()
        {
            FiatCurrencyValue = (int)FiatCurrencyEnum.byr;
        }
    }

    public class CryptoCurrency : Currency
    {

        public int CryptoCurrencyValue = 100;
        public enum CryptoCurrencyEnum
        {
            Bitcoin = 100,
            Manero = 100,
            Bnb = 200,
            Etherium = 500

        }
        public CryptoCurrency()
        {
            CryptoCurrencyValue = (int)CryptoCurrencyEnum.Etherium;
        }
    }

    public class ElectronicCurrency : Currency
    {
        public int ElectronicCurrencyValue = 700;
        public enum ElectronicCurrencyEnum
        {
            Webmoney = 700,
            Yandexmoney = 800,
           Moneymailru = 665,
           Qiwi = 116

        }
        public ElectronicCurrency()
        {
            ElectronicCurrencyValue = (int)ElectronicCurrencyEnum.Webmoney;
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

        public HomeDelivery(Curiers Curier, TimeOnly ClientWishTimeFrom, TimeOnly ClientWishTimeTo, bool IsPOSNeeded, int EnterenceCode, byte Floor,
            bool IsLift, byte AmountOfDeliveryTry)
        {
            this.Curier = Curier;
            this.ClientWishTimeFrom = ClientWishTimeFrom;
            this.ClientWishTimeTo = ClientWishTimeTo;
            this.IsPOSNeeded = IsPOSNeeded;
            this.EnterenceCode = EnterenceCode;
            this.Floor = Floor;
            this.IsLift = IsLift;
            this.AmountOfDeliveryTry = AmountOfDeliveryTry;
        }


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

        public PickPointDelivery()
        {

        }
    }

    class ShopDelivery : Delivery
    {
        /* ... */

        public ShopDelivery()
        {

        }
    }

    public class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int OrderNumber;

        public Order<TDelivery, TStruct>(int OrderNumber, )

        public void DisplayAddress()
        {
            Console.WriteLine(Order.DeliveryAddress);
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

