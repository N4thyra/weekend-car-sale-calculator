using System;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Xml;
using System.Linq;


namespace weekend_sale_calc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                List<Car> cars = new List<Car>();

                foreach (XmlNode node in doc.DocumentElement)
                {
                    string model = node["Model"].InnerText;
                    DateTime Date = DateTime.Parse(node["Date"].InnerText);
                    double price = double.Parse(node["Price"].InnerText);
                    double tax = double.Parse(node["Tax"].InnerText);
                    cars.Add(new Car() { Model = model, Date = Date, Price = price, Tax = tax });
                }

                List<WeekendSale> weekend = new List<WeekendSale>();
                List<Result> result = new List<Result>();

                foreach (var item in cars)
                {
                    Console.WriteLine("Model {0} date {1} day {2}", item.Model, item.Date, item.Date.DayOfWeek);
                    if (item.Date.DayOfWeek.ToString() == "Sunday" || item.Date.DayOfWeek.ToString() == "Saturday")
                    {
                        weekend.Add(new WeekendSale() { Model = item.Model, Price = item.Price, Tax = item.Tax });
                    }
                }

                //base price for a car
                double nfelicia = weekend.Where(item => item.Model == "Škoda Felicia").Sum(item => item.Price);
                double noctavia = weekend.Where(item => item.Model == "Škoda Oktávia").Sum(item => item.Price);
                double nfabia = weekend.Where(item => item.Model == "Škoda Fabia").Sum(item => item.Price);
                double nforman = weekend.Where(item => item.Model == "Škoda Forman").Sum(item => item.Price);
                double nfavorit = weekend.Where(item => item.Model == "Škoda Favorit").Sum(item => item.Price);

                //TAX included
                double felicia = weekend.Where(item => item.Model == "Škoda Felicia").Sum(item => item.Price + (item.Price * item.Tax / 100));
                double octavia = weekend.Where(item => item.Model == "Škoda Oktávia").Sum(item => item.Price + (item.Price * item.Tax / 100));
                double fabia = weekend.Where(item => item.Model == "Škoda Fabia").Sum(item => item.Price + (item.Price * item.Tax / 100));
                double forman = weekend.Where(item => item.Model == "Škoda Forman").Sum(item => item.Price + (item.Price * item.Tax / 100));
                double favorit = weekend.Where(item => item.Model == "Škoda Favorit").Sum(item => item.Price + (item.Price * item.Tax / 100));

                if (felicia != 0)
                {
                    string model = "Škoda Felicia";
                    result.Add(new Result() { ModelAndPrice = model + "\n" + nfelicia.ToString("N0"), PriceWithTax = felicia });
                }

                if (octavia != 0)
                {
                    string model = "Škoda Oktávia";
                    result.Add(new Result() { ModelAndPrice = model + "\n" + noctavia.ToString("N0"), PriceWithTax = octavia });
                }

                if (fabia != 0)
                {
                    string model = "Škoda Fabia";
                    result.Add(new Result() { ModelAndPrice = model + "\n" + nfabia.ToString("N0"), PriceWithTax = fabia });
                }

                if (forman != 0)
                {
                    string model = "Škoda Forman";
                    result.Add(new Result() { ModelAndPrice = model + "\n" + nforman.ToString("N0"), PriceWithTax = forman });
                }

                if (favorit != 0)
                {
                    string model = "Škoda Favorit";
                    result.Add(new Result() { ModelAndPrice = model + "\n" + nfavorit.ToString("N0"), PriceWithTax = favorit });
                }


                dataGrid.ItemsSource = cars;
                resultGrid.ItemsSource = result;
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {

        }

        public class Car
        {
            public string Model { get; set; }
            public DateTime Date { get; set; }
            public double Price { get; set; }
            public double Tax { get; set; }
        }

        public class WeekendSale
        {
            public string Model { get; set; }
            public double Price { get; set; }
            public double Tax { get; set; }
        }

        public class Result
        {
            public string Model { get; set; }
            public double BasePrice { get; set; }
            public double PriceWithTax { get; set; }
            public string ModelAndPrice { get; set; }
        }
    }
}
