namespace PW3_2
{
    class SmsMessage
    {
        private string Messagetext;
        public double Price;
        public SmsMessage( string Messagetext)
        {
            this.Messagetext = Messagetext;
        }
        public string smstext
        {
            get { return Messagetext; }
            set { Messagetext = Normalizesms(value); }
        }
        public string Normalizesms( string value)
        {
            if (Messagetext.Length <= 65)
            {
                Price = 1.5;
                Console.WriteLine($"Цена за сообщение - {Price} руб.");
            }
            else
            {
                if (Messagetext.Length <=250 && Messagetext.Length>65)
                {
                    int extraSymbols = Messagetext.Length - 65;
                    double tax = extraSymbols * 0.5;
                    Price += tax;
                    Console.WriteLine($"Цена за сообщение - {Price} руб.(в сумму входят: стоимоть отправки сообщения - 1.5 руб.; стоимость за превышения лимитов по символам сообщения - символы после лимита {extraSymbols}*0.5руб.(за 1 символ) = {tax})");
                }
                else
                {
                    int length = Messagetext.Length;
                    Console.WriteLine($"Сообщение не отправлено, так как превышен лимит символов(250). Символов в сообщении: {length}");
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

            Console.Write("Отправка SMS\nВведите текст: ");
            string Messagetext = Console.ReadLine();
            SmsMessage message = new SmsMessage(Messagetext);
            message.SendInfo();

            Console.ReadKey(true);
        }
    }
}