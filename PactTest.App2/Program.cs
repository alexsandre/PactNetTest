using System;

namespace PactTest.App2
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PactTestAPIClient();
            var mpEvent = client.GetEvent(1);

            Console.WriteLine(mpEvent.Id);
            Console.WriteLine(mpEvent.Description);
            Console.WriteLine(mpEvent.Start);
            Console.WriteLine(mpEvent.End);
            Console.WriteLine(mpEvent.RegistrationStart);
            Console.WriteLine(mpEvent.RegistrationEnd);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
