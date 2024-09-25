using System;


namespace Task3
{
    public class Program
    {

        public class Currency 
        {
            public double Value { get; set; }

            public Currency(double Value) 
            {
                this.Value = Value;
            }
        }

        public class CurrencyUSD: Currency 
        {
            public double exchange_rateUSD_RUB { get; set; }
            public double exchange_rateUSD_EUR { get; set; }
            public double exchange_rateEUR_RUB { get; set; }
            public CurrencyUSD(double exchange_rateUSD_RUB, double exchange_rateUSD_EUR, double exchange_rateEUR_RUB, double Value) : base(Value)
            {
                this.exchange_rateUSD_RUB = exchange_rateUSD_RUB;
                this.exchange_rateUSD_EUR = exchange_rateUSD_EUR;
                this.exchange_rateEUR_RUB = exchange_rateEUR_RUB;
            }
            public static explicit operator CurrencyRUB(CurrencyUSD USD)
            {
                return new CurrencyRUB(USD.exchange_rateUSD_RUB, USD.exchange_rateEUR_RUB, USD.exchange_rateUSD_EUR, USD.Value * USD.exchange_rateUSD_RUB);
            }
            public static explicit operator CurrencyEUR(CurrencyUSD USD)
            {
                return new CurrencyEUR(USD.exchange_rateEUR_RUB, USD.exchange_rateUSD_EUR, USD.exchange_rateUSD_RUB, USD.Value * USD.exchange_rateUSD_EUR);
            }
        }
        public class CurrencyEUR : Currency
        {
            public double exchange_rateEUR_RUB { get; set; }
            public double exchange_rateEUR_USD { get; set; }
            public double exchange_rateUSD_RUB { get; set; }
            public CurrencyEUR(double exchange_rateEUR_RUB, double exchange_rateEUR_USD, double exchange_rateUSD_RUB, double Value) : base(Value)
            {
                this.exchange_rateEUR_RUB = exchange_rateEUR_RUB;
                this.exchange_rateEUR_USD = exchange_rateEUR_USD;
                this.exchange_rateUSD_RUB = exchange_rateUSD_RUB;
            }
            public static explicit operator CurrencyRUB(CurrencyEUR EUR)
            {
                return new CurrencyRUB(EUR.exchange_rateUSD_RUB, EUR.exchange_rateEUR_RUB, EUR.exchange_rateEUR_USD, EUR.Value * EUR.exchange_rateEUR_RUB);
            }
            public static explicit operator CurrencyUSD(CurrencyEUR EUR)
            {
                return new CurrencyUSD(EUR.exchange_rateUSD_RUB, EUR.exchange_rateEUR_USD, EUR.exchange_rateEUR_RUB, EUR.Value / EUR.exchange_rateEUR_USD);
            }
        }
        public class CurrencyRUB : Currency
        {
            public double exchange_rateRUB_USD { get; set; }
            public double exchange_rateRUB_EUR { get; set; }
            public double exchange_rateUSD_EUR { get; set; }
            public CurrencyRUB(double exchange_rateRUB_USD, double exchange_rateRUB_EUR, double exchange_rateUSD_EUR, double Value) : base(Value)
            {
                this.exchange_rateRUB_USD = exchange_rateRUB_USD;
                this.exchange_rateRUB_EUR = exchange_rateRUB_EUR;
                this.exchange_rateUSD_EUR = exchange_rateUSD_EUR;
            }
            public static explicit operator CurrencyUSD(CurrencyRUB RUB) 
            {
                return new CurrencyUSD(RUB.exchange_rateRUB_USD, RUB.exchange_rateUSD_EUR, RUB.exchange_rateRUB_EUR, RUB.Value / RUB.exchange_rateRUB_USD );
            }
            public static explicit operator CurrencyEUR(CurrencyRUB RUB)
            {
                return new CurrencyEUR(RUB.exchange_rateRUB_EUR, RUB.exchange_rateUSD_EUR, RUB.exchange_rateRUB_USD, RUB.Value / RUB.exchange_rateRUB_EUR );
            }
        }
        static void Main()
        {
            Console.WriteLine("Напишите сумму в RUB:");
            string temp1 = Console.ReadLine();
            double value = Convert.ToDouble(temp1);
            Currency cur = new Currency(value);
            Console.WriteLine("Напишите курс USD к RUB:");
            string temp2 = Console.ReadLine();
            double USD = Convert.ToDouble(temp2);
            Console.WriteLine("Напишите курс EUR к RUB:");
            string temp3 = Console.ReadLine();
            double EUR = Convert.ToDouble(temp3);
            Console.WriteLine("Напишите курс EUR к USD:");
            string temp4 = Console.ReadLine();
            double USD_EUR = Convert.ToDouble(temp4);
            CurrencyRUB bank = new CurrencyRUB(USD, EUR, USD_EUR, cur.Value);
            Console.WriteLine($"Рубли:{bank.Value}");
            CurrencyUSD bank1 = (CurrencyUSD)bank;
            Console.WriteLine($"Доллары:{bank1.Value}");
            CurrencyEUR bank2 = (CurrencyEUR)bank1;
            Console.WriteLine($"Евро:{bank2.Value}");
        }
    }
}
