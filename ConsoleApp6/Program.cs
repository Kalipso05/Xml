using System;
using System.Runtime.Remoting.Contexts;
using System.Xml;

namespace ConsoleApp6
{
    class Program
    {
        static void Main()
        {
            string xmlFilePath = "1.5_mondial.xml.xml";

            XmlDocument doc = new XmlDocument();

            doc.Load(xmlFilePath);
            using (AppContext db = new AppContext())
            {
                XmlElement root = doc.DocumentElement;

                XmlNodeList continents = root.SelectNodes("//continent");
                foreach (XmlNode continent in continents)
                {
                    Continent newContinent = new Continent
                    {
                        Id = continent.Attributes["id"].Value,
                        Name = continent.Attributes["name"].Value,
                    };

                    db.Continents.Add(newContinent);

                }
                XmlNodeList countries = root.SelectNodes("//country");
                foreach (XmlNode country in countries)
                {


                    var countryData = new Country
                    {
                        Id = country.Attributes["id"].Value,
                        Name = country.Attributes["name"].Value,
                        Capital = country.Attributes["capital"].Value,
                        Population = int.Parse(country.Attributes["population"].Value),
                        TotalArea = int.Parse(country.Attributes["total_area"].Value)
                    };

                    db.Countries.Add(countryData);
                    XmlNodeList cities = country.SelectNodes("city");
                    foreach (XmlNode city in cities)
                    {


                        var citiesData = new City
                        {
                            Id = city.Attributes["id"].Value,
                            Name = city.SelectSingleNode("name").InnerText,
                            Longitude = city.Attributes["longitude"].Value,
                            Latitude = city.Attributes["latitude"].Value,
                        };
                        db.Cities.Add(citiesData);
                    }

                    XmlNodeList ethnicGroups = country.SelectNodes("ethnicgroups");
                    foreach (XmlNode ethnicGroup in ethnicGroups)
                    {


                        var ethnicData = new EthnicGroup
                        {
                            Percentage = double.Parse(ethnicGroup.Attributes["percentage"].Value),
                            Name = ethnicGroup.InnerText.Trim(),
                        };
                        db.EthnicGroups.Add(ethnicData);
                    }

                    XmlNodeList religions = country.SelectNodes("religions");
                    foreach (XmlNode religion in religions)
                    {


                        var religionsData = new Religion
                        {
                            Percentage = double.Parse(religion.Attributes["percentage"].Value),
                            Name = religion.InnerText.Trim(),
                        };
                        db.Religions.Add(religionsData);
                    }
                    db.SaveChanges();
                }
            }

        }
    }

}