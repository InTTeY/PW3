using System;
namespace PW3_4
{
    class MyintList
    {
        private List<int> numberList = new List<int>();
        public double Average
        {
            get
            {
                return CalculateAveragre();
            }
        }
        public void AddNumber(int number)
        {
            numberList.Add(number);
        }
        public void RemoveNumber(int number)
        {
            numberList.Remove(number);
        }
        private double CalculateAveragre()
        {
            int sum = 0;
            foreach (int number in numberList)
            {
                sum += number;
            }
            return sum / numberList.Count;
        }
        
        // добавлено свойство и метод //
        public double GeometricMean
        {
            get
            {
                return CalculateGeometricMean();
            }
        }
        private double CalculateGeometricMean()
        {
            int proizv = 1;
            foreach (int number in numberList)
            {
                proizv *= number;
            }
            return Math.Pow(proizv, 1.0 / numberList.Count);
        }

        // добавлено свойство и метод //
        public double TotalSum
        {
            get
            {
                return CalculateTotalSum();
            }
        }
        private double CalculateTotalSum()
        {
            int sum = 0;
            foreach (int number in numberList)
            {
                sum += number;
            }
            return sum;
        }
    }
    class programm
    {
        static void Main()
        {
            MyintList numbers = new MyintList();
            numbers.AddNumber(1);
            numbers.AddNumber(2);
            numbers.AddNumber(8);
            numbers.AddNumber(16);
            numbers.AddNumber(20);
            numbers.AddNumber(38);

            Console.WriteLine("Сред арифм: " + numbers.Average);
            Console.WriteLine("Сред геометр: " + numbers.GeometricMean);
            Console.WriteLine("Общая сумма: " + numbers.TotalSum);

            Console.ReadKey(true);
        }
    }
}