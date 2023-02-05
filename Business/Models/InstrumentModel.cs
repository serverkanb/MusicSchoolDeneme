using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
#nullable disable

namespace Business.Models
{
    public class InstrumentModel : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Instrument Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Unit Price")]
        public double? UnitPrice { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Stock Amount")]
        public int? StockAmount { get; set; }

        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }


    }
}