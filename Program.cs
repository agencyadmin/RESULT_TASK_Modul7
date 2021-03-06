namespace InternetShop
{
    public abstract class Delivery
    {
        protected int DeliveryId { get; set; }
        public DateTime DeliveryOpenDate { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        private Client ClientForDelivery { get; set; }
        public string DeliveryAddress { get; set; }
        private int DeliveryAmount { get; set; }
        protected int DeliverySummPaied { get; set; }
        public bool IsDelFullyPaied { get; set; }
        protected static Currency DeliveryOrderCurrency { get; set; }
        public string DeliveryDescription { get; set; }
        public DateTime DeliveryCloseDate { get; set; }
        public Delivery()
        {
            DeliveryId = 333000;
            DeliveryOpenDate = new DateTime(1998, 2, 4);
            DeliveryDateTime = new DateTime(1977, 3, 8);
            ClientForDelivery = new Client();
            DeliveryAddress = "Delivery Address is unknown";
            DeliveryAmount = 0;
            DeliverySummPaied = 0;
            DeliveryOrderCurrency = new FiatCurrency();
            DeliveryDescription = "some Delivery for somebody";
            IsDelFullyPaied = DeliverySummPaied >= DeliveryAmount ? true : false;
        }

        public Delivery(int DeliveryID, DateTime DeliveryOpenDate, DateTime DeliveryDateTime, Client ClientForDelivery, string DeliveryAddress,
                    int DeliveryAmount, int DeliverySummPaied, Currency DeliveryOrderCurrency, string DeliveryDescription)
        {
            this.DeliveryId = DeliveryID;
            this.DeliveryOpenDate = DeliveryOpenDate;
            this.DeliveryDateTime = DeliveryDateTime;
            this.ClientForDelivery = ClientForDelivery;
            this.DeliveryAddress = DeliveryAddress;
            this.DeliveryAmount = DeliveryAmount;
            this.DeliverySummPaied = DeliverySummPaied;
            this.DeliveryOrderCurrency = DeliveryOrderCurrency;
            this.DeliveryDescription = DeliveryDescription;
            IsDelFullyPaied = DeliverySummPaied >= DeliveryAmount ? true : false;

        }

        public virtual void DisplayAddress()
        {
            Console.WriteLine(DeliveryAddress);
        }

    }

    public class Payment
    {
        public static Currency PaymentCurrency { get; set; }
        protected int PaiedSummOfOrder { get; set; }
        protected int OrderSumm { get; set; }
        public DateTime PaymentDateTime { get; set; }
        protected int PaymentAmount { get; set; }
        public int PaymentDocNumber { get; set; }
        protected int OrderPaymentBalance { get; set; }
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
        protected string ResidenceAdress { get; set; }
        protected string PhoneNumber { get; set; }
        public string DocName { get; set; }
        protected string DocNumber { get; set; }
        protected DateOnly DocIssueDate { get; set; }
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
        protected string SurName { get; set; }
        protected string FatherName { get; set; }
        protected DateOnly Birthday { get; set; }
        protected bool IsMarried { get; set; }
        protected byte ChildrenQuantity { get; set; }

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
        public static string State { get; set; } //этот статический элемент класса предпологает что работаем только внутри одной траны либо с компаниями из
        //одной страны

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
            Director = new Human("Ivanov", "Ivan", "Ivanovich", new DateOnly(1997, 10, 19), true, 3); // Композиция
            Accounter = new Human("Jakovleva", "Svetlana", "Petrovna", new DateOnly(2000, 3, 19), true, 3);// Композиция
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
        protected DateOnly HareDate;
        protected DateOnly RetaingDate;
        public int StaffIDNumber { get; set; }
        public int Salary;

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

        public static Staff operator +(Staff a, Staff b)
        {
            return new Staff
            {
                StaffIDNumber = a.StaffIDNumber + b.StaffIDNumber,
                Salary = a.Salary + b.Salary
            };
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
        protected DateTime CompanyClientAccOpenDate { get; set; }
        public static long CompanyClientAccountAmount { get; set; }

        static Client() //накручиваем статическим конструктором количество клиентов в компании
        {
            CompanyClientAccountAmount = 900000000000;
        }
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

    public class Partners<TClientType> //where TClientType : Company //но партнером по идее может быть и человек, так что ограничение по типу универсальной
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

    public class Curiers<TClientType> : Partners<TClientType>
    {
        public TClientType Curier = default(TClientType);
        public int CuriersIDNumber;
        public DateTime CuriersDateContract;
        public DateTime CuriersCloseDateContract;
        public int CuriersFeeContract;
        public byte CuriersBalanceContract;
        public int CuriersOrdersQountity;
        public byte CurierRating;
        public string CurierDescription;

        public Curiers()
        {
            Curiers<TClientType> Curier = new Curiers<TClientType>();

        }
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
        public Curiers<TClientType> HomeCurier = default(TClientType);
        public TimeOnly ClientWishTimeFrom;
        public TimeOnly ClientWishTimeTo;
        public bool IsPOSNeeded;
        public int EnterenceCode;
        public byte Floor;
        public bool IsLift;
        public byte AmountOfDeliveryTry;

        public HomeDelivery() : base()
        {
            Curiers<TClientType> HomeCurier = new Curiers<TClientType>();
        }

        public HomeDelivery(Curiers<TClientType> Curier, TimeOnly ClientWishTimeFrom, TimeOnly ClientWishTimeTo, bool IsPOSNeeded, int EnterenceCode, byte Floor,
            bool IsLift, byte AmountOfDeliveryTry)
        {
            this.HomeCurier = Curier;
            this.ClientWishTimeFrom = ClientWishTimeFrom;
            this.ClientWishTimeTo = ClientWishTimeTo;
            this.IsPOSNeeded = IsPOSNeeded;
            this.EnterenceCode = EnterenceCode;
            this.Floor = Floor;
            this.IsLift = IsLift;
            this.AmountOfDeliveryTry = AmountOfDeliveryTry;
        }

        public override void DisplayAddress()
        {
            Console.WriteLine(DeliveryAddress, Floor, IsLift);
        }


    }

    class PickPointDelivery : Delivery
    {
        /* ... */
        Partners<Company> PickPointPartner = new Partners<Company>();
        public string PickPointName;
        public string PickPointDescription;
        public string PickPointAdress;
        public TimeOnly PickPointOpenDate;
        public TimeOnly PickPointCloseDate;
        public DateTime DeliveredToPickPoint;
        public DateTime TakeParcelDeadLine;
        public DateTime ReturnFromPickPoint;

        public PickPointDelivery() : base()
        {

        }

        public override void DisplayAddress()
        {
            Console.WriteLine(PickPointName, PickPointAdress, PickPointDescription);
        }
    }

    class ShopDelivery : Delivery
    {
        /* ... */
        Partners<Company> ShopPartner = new Partners<Company>();
        public string ShopName;
        public string ShopDescription;
        public string ShopAdress;
        public TimeOnly ShopOpenTime;
        public TimeOnly ShopCloseTime;
        public DateTime DeliveredToShop;
        public DateTime SellingPeriodFrom;
        public DateTime ReturnFromShop;
        public ShopDelivery() : base()
        {

        }

        public override void DisplayAddress()
        {
            Console.WriteLine(ShopName, ShopAdress, ShopDescription);
        }
    }

    public class Order<TDelivery, TShoppingCart> where TDelivery : Delivery where TShoppingCart : ShoppingCart

    {
        public int OrderNumber;
        TDelivery DeliveryOrder;
        TDelivery NewOrder;
        TShoppingCart NewOrderCart;
        public Order()
        {
            this.OrderNumber = 1;
            DeliveryOrder = default(TDelivery);
            NewOrder = default(TDelivery);
        }
        public Order(int OrderNumber, TDelivery DeliveryOrder)
        {
            this.OrderNumber = OrderNumber;
            this.DeliveryOrder = DeliveryOrder;
        }

        public void DisplayAddress()
        {
            Console.WriteLine(NewOrder.ToString);
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

    static class DateOnlyExtensions
    {
        public static DateOnly GetOneWeekMore(this DateOnly source)
        {
            return source[source.AddDays(7)];
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
    

