namespace PW3_5
{
    class SmsMessage
    {
        private string Messagetext;
        public int MaxLength;
        public double Price;
        public double SymbolTax;
        public SmsMessage(int MaxLength, double Price, double SymbolTax, string Messagetext)
        {
            this.MaxLength = MaxLength;
            this.Price = Price;
            this.SymbolTax = SymbolTax;
            this.Messagetext = Messagetext;
        }
        public string smstext
        {
            get { return Messagetext; }
            set { Messagetext = Normalizesms(value); }
        }
        public string Normalizesms(string value)
        {
            if (Messagetext.Length <= 65)
            {
                Console.WriteLine($"Цена за сообщение - {Price} руб.");
            }
            else
            {
                if (Messagetext.Length <= MaxLength && Messagetext.Length > 65)
                {
                    int extraSymbols = Messagetext.Length - 65;
                    double tax = extraSymbols * SymbolTax;
                    double PriceTax = Price + tax;
                    Console.WriteLine($"Цена за сообщение - {PriceTax} руб.(в сумму входят: стоимоть отправки сообщения - {Price} руб.; стоимость за превышения лимитов по символам сообщения - символы после лимита {extraSymbols}*{SymbolTax}руб.(за 1 символ) = {tax})");
                }
                else
                {
                    int length = Messagetext.Length;
                    Console.WriteLine($"Сообщение не отправлено, так как превышен лимит символов{MaxLength}. Символов в сообщении: {length}");
                }
            }
            return value;
        }
        public void SendInfo()
        {
            Console.WriteLine($"{Normalizesms(Messagetext)}");
        }
    }
    class programm
    {
        static void Main()
        {
            Console.Write("Установка параметров SMS\nВведите максимальную длину сообщения(от 66 символов): ");
            int MaxLength = Convert.ToInt32(Console.ReadLine());
            if (MaxLength > 65)
            {
                Console.Write("Введите стоимость базового сообщения(за 65 символов): ");
                double Price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите цену за 1 символ после лимита по базовому сообщению: ");
                double SymbolTax = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nОтправка SMS\nВведите текст: ");
                string Messagetext = Console.ReadLine();
                SmsMessage message = new SmsMessage(MaxLength, Price, SymbolTax, Messagetext);

                message.SendInfo();

                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine($"Вы ввели неправильное значение или значение, которое меньше минимального. Введенное значение {MaxLength}");

                Console.ReadKey(true);
            }
        }
    }
}