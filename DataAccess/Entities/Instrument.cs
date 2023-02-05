using AppCore.Records.Bases;
#nullable disable

namespace DataAccess.Entities
{
    public class Instrument:RecordBase
    {
        
        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public int? StockAmount { get; set; }
        public List<Teacher> Teachers { get; set;}
    }
}
