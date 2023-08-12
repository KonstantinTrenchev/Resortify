using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Resortify.Data
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        [ForeignKey(nameof(AccomodationId))]
        public Accomodation Accomodation { get; set; }
        public int AccomodationId { get; set; }
    }
}
