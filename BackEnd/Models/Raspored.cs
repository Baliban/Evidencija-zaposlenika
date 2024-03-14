namespace BackEnd.Models
{
    public class Raspored : Entitet
    {
        public int? Djelatnik { get; set; }

        public string? Odjel { get; set; }
        public string? Ponedjeljak { get; set; }
        public string? Utorak { get; set; }
        public string? Srijeda { get; set; }
        public string? Cetvrtak { get; set; }
        public string? Petak { get; set; }
        public string? Subota { get; set; }
        public string? Nedjelja { get; set; }


    }
}
