namespace BiletOtomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ticket> tickets = new List<Ticket>();
            List<Route> routes = new List<Route>
            {
                new Route("Trabzon-Manisa", 500),
                new Route("Ankara-İstanbul", 1100),
                new Route("İstanbul-İzmir", 400)
            };

            //Route route1 = new Route("Trabzon-Manisa", 500);
            //routes.Add(route1);
            //Route route2 = new Route("Ankara-İstanbul", 1100);
            //routes.Add(route2);
            //Route route3 = new Route("İstanbul-İzmir", 400);
            //routes.Add(route3);
            Console.WriteLine("****************\n18 yaşından küçüklere %50 indirim uygulanır.");
            while (true)
            {
                Console.Write("*******\n1) Rota Ekleme\n2) Bilet Satış\n3) Bilet İptali\n4) Rapor Hazırlama\n5) Çıkış\n*******\nLütfen seçim yapınız: ");
                int myChoice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (myChoice)
                {
                    case 1:
                        Console.Write("\nLütfen eklemek istediğiniz rota miktarını giriniz: ");
                        int routeCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < routeCount; i++)
                        {
                            Console.Write($"Lütfen eklemek istediğiniz {i + 1}. güzergahı yazınız: ");
                            string rn = Console.ReadLine();
                            Console.Write($"Lütfen {i + 1}. güzergah fiyatını yazınız: ");
                            double rp = double.Parse(Console.ReadLine());
                            TicketSystem ticketSystem3 = new TicketSystem();
                            ticketSystem3.addRoute(rn, rp, routes);
                        }
                        Console.Clear();
                        break;
                    case 2:
                        for (int i = 0; i < routes.Count; i++)
                        {
                            Console.WriteLine($"Güzergah {i + 1}: {routes[i].RouteName}, fiyat: {routes[i].BasePrice}\n****************");
                        }
                        Console.Write("\nLütfen kaç adet bilet alacağınızı giriniz: ");
                        int ticketCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < ticketCount; i++)
                        {
                            Console.Write($"****************\nLütfen {i + 1}. yolcunun adını giriniz: ");
                            string passengerName = Console.ReadLine();
                            Console.Write($"Lütfen {i + 1}. yolcunun yaşını giriniz: ");
                            int passengerAge = int.Parse(Console.ReadLine());
                            Console.Write($"Lütfen {i + 1}. yolcunun güzergahı seçiniz: ");
                            int routeChoice = int.Parse(Console.ReadLine());
                            Ticket ticket = new Ticket(passengerName, passengerAge, routes[routeChoice - 1]);
                            tickets.Add(ticket);
                        }
                        break;
                    case 3:
                        if (tickets.Count < 1)
                        {
                            Console.WriteLine("\nSatın alınmış bilet yok!");
                        }
                        else
                        {
                            Console.Write("Lütfen silmek istediğiniz ismi giriniz: ");
                            string deletedName = Console.ReadLine();
                            TicketSystem ticketSystem = new TicketSystem();
                            ticketSystem.removeTicket(deletedName, tickets);
                        }
                        break;
                    case 4:
                        TicketSystem ticketSystem1 = new TicketSystem();
                        ticketSystem1.showTickets(tickets);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("****************\nLütfen geçerli bir değer giriniz!");
                        break;
                }
            }
        }
    }

    class Route
    {
        public string RouteName { get; set; }
        public double BasePrice { get; set; }
        public Route(string routeName, double basePrice)
        {
            RouteName = routeName;
            BasePrice = basePrice;
        }
    }
    class Ticket
    {
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public Route Route { get; set; }
        public double TicketPrice { get; set; }
        public Ticket(string passengerName, int passengerAge, Route route)
        {
            PassengerName = passengerName;
            PassengerAge = passengerAge;
            Route = route;
            TicketPrice = PriceCalculate();
        }
        public double PriceCalculate()
        {
            if (PassengerAge < 18)
            {
                TicketPrice = Route.BasePrice * 0.5;
                return TicketPrice;
            }
            else
            {
                TicketPrice = Route.BasePrice;
                return TicketPrice;
            }
        }
    }
    class TicketSystem
    {
        public void addRoute(string routeName, double basePrice, List<Route> routes)
        {
            Route route = new Route(routeName, basePrice);
            routes.Add(route);
        }

        public void removeTicket(string deletedName, List<Ticket> tickets)
        {
            Ticket deletedTicket = tickets.FirstOrDefault(x => x.PassengerName == deletedName);
            if (deletedTicket != null)
            {
                tickets.Remove(deletedTicket);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nSilinecek bilet bulunamadı!");
            }
        }

        public void showTickets(List<Ticket> tickets)
        {
            if (tickets.Count != 0)
            {
                foreach (Ticket item in tickets)
                {
                    Console.WriteLine($"\nYolcu adı: {item.PassengerName}, yolcu yaşı: {item.PassengerAge}, güzergah: {item.Route.RouteName}, fiyat: {item.TicketPrice}\n");
                }
            }
            else
            {
                Console.WriteLine("\nBilet satışı yok!");
            }

        }
        public void showRoutes(List<Route> routes)
        {
            foreach (var item in routes)
            {
                Console.WriteLine($"Rotalar\nGüzergah: {item.RouteName}, fiyat: {item.BasePrice}");
            }
        }
    }
}