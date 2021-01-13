using System;

namespace PactTest.App1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PactTestAPIClient();
            var mpEvent = client.GetEvent(1);

            Console.WriteLine(mpEvent.Id);
            Console.WriteLine(mpEvent.Description);
            Console.WriteLine(mpEvent.Image);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
