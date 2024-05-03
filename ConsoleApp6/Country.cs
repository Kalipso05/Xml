using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public double TotalArea { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<EthnicGroup> EthnicGroups { get; set; }
        public ICollection<Religion> Religions { get; set; }
    }
}
