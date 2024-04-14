using Newtonsoft.Json;
using System.Reflection;

namespace Holiday.Test
{
    [TestClass]
    public class UnitTest1
    {


        Class1 holidaySearch = new Class1();
        [TestMethod]
        public void Customer1()
        {




            // test cases
            Tuple<Flight, Hotel> customer1 = holidaySearch.SearchHoliday("Manchester Airport(MAN)", "Malaga Airport(AGP)", new DateTime(2023, 07, 01), 7);
            // Tuple<Flight, Hotel> customer2 = holidaySearch.SearchHoliday("Any London Airport", "Mallorca Airport(AGP)", new DateTime(2023, 06, 15), 10);
            //Tuple<Flight, Hotel> customer3 = holidaySearch.SearchHoliday("Any Airport", "Gran Canaria Airport(LPA)", new DateTime(2022, 11, 10), 14);

            //Tuple<Flight, Hotel> finalResult = holidaySearch.SearchHoliday("MAN", "AGP", new DateTime(2023, 07, 01), 7);
            Console.WriteLine(customer1.Item1.id);
            Console.WriteLine(customer1.Item2.id);


            Assert.AreEqual(2, customer1.Item1.id, "Flight ID should match");
           
            Assert.AreEqual(9, customer1.Item2.id, "Hotel ID should match");

            Console.WriteLine(" Customer1 result search sucess");
        }


        [TestMethod]
        public void Customer2()
        {
            Tuple<Flight, Hotel> customer2 = holidaySearch.SearchHoliday("Any London Airport", "Mallorca Airport(PMI)", new DateTime(2023, 06, 15), 10);

            Console.WriteLine(customer2.Item1.id);
            Console.WriteLine(customer2.Item2.id);
            Assert.AreEqual(6, customer2.Item1.id, "Flight ID should match");

            Assert.AreEqual(5, customer2.Item2.id, "Hotel ID should match");

            Console.WriteLine(" Customer2 result search sucess");

        }



        [TestMethod]
        public void Customer3()
        {
            Tuple<Flight, Hotel> customer3 = holidaySearch.SearchHoliday("Any Airport", "Gran Canaria Airport(LPA)", new DateTime(2022, 11, 10), 14);

            Console.WriteLine(customer3.Item1.id);
            Console.WriteLine(customer3.Item2.id);
            Assert.AreEqual(7, customer3.Item1.id, "Flight ID should match");

            Assert.AreEqual(6, customer3.Item2.id, "Hotel ID should match");

            Console.WriteLine(" Customer3 result search sucess");

        }





    }
}