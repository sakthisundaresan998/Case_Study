using System;

class Program
{
    //1
    static long CalculateFactorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.");

        long factorial = 1;
        for (int i = 2; i <= number; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    // 2
    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Values must be non-negative.");

        return (principal * rate * time) / 100;
    }

    // 3.
    static void CalculateInterestAndTotal(double principal, double rate, double time, out double interest, out double totalAmount)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Values must be non-negative.");

        interest = (principal * rate * time) / 100;
        totalAmount = principal + interest;
    }

    // 4.
    static double CalculateSimpleInterestOptional(double principal, double time, double rate = 10)
    {
        if (principal < 0 || time < 0 || rate < 0)
            throw new ArgumentException("Values must be non-negative.");

        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        try
        {
            // 1. Factorial
            Console.Write("Enter a number to calculate factorial: ");
            int num = int.Parse(Console.ReadLine());
            long fact = CalculateFactorial(num);
            Console.WriteLine($"Factorial of {num} is {fact}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating factorial: {ex.Message}");
        }

        try
        {
            // 2. Simple Interest using function
            Console.Write("\nEnter principal amount: ");
            double p1 = double.Parse(Console.ReadLine());
            Console.Write("Enter rate of interest: ");
            double r1 = double.Parse(Console.ReadLine());
            Console.Write("Enter time (in years): ");
            double t1 = double.Parse(Console.ReadLine());

            double si1 = CalculateSimpleInterest(p1, r1, t1);
            Console.WriteLine($"Simple Interest is: {si1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating simple interest: {ex.Message}");
        }

        try
        {
            // 3. Simple Interest using out parameters
            Console.Write("\nEnter principal amount: ");
            double p2 = double.Parse(Console.ReadLine());
            Console.Write("Enter rate of interest: ");
            double r2 = double.Parse(Console.ReadLine());
            Console.Write("Enter time (in years): ");
            double t2 = double.Parse(Console.ReadLine());

            CalculateInterestAndTotal(p2, r2, t2, out double interest, out double totalAmount);
            Console.WriteLine($"Simple Interest: {interest}");
            Console.WriteLine($"Total Amount Payable: {totalAmount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating total payable amount: {ex.Message}");
        }

        try
        {
            // 4. Simple Interest with optional rate
            Console.Write("\nEnter principal amount: ");
            double p3 = double.Parse(Console.ReadLine());
            Console.Write("Enter time (in years): ");
            double t3 = double.Parse(Console.ReadLine());

            Console.Write("Enter rate of interest (or press Enter to use default 10): ");
            string rateInput = Console.ReadLine();
            double si2;

            if (string.IsNullOrWhiteSpace(rateInput))
                si2 = CalculateSimpleInterestOptional(p3, t3);
            else
                si2 = CalculateSimpleInterestOptional(p3, t3, double.Parse(rateInput));

            Console.WriteLine($"Simple Interest: {si2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating optional interest: {ex.Message}");
        }
    }
}
