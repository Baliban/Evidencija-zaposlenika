using System.Text.RegularExpressions;

namespace BackEnd.Models
{
    public class fondsati:Raspored
    {
       
        public ICollection<Raspored>? Rasporedi{ get; } = [];
    }
}
