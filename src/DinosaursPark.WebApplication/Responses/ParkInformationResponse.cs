namespace DinosaursPark.WebApplication.Responses
{
    public class ParkInformationResponse
    {
        public string Name { get; set; }

        public double Area { get; set; }

        public string Address { get; set; }

        public int DinosaursCount { get; set; }

        public int SpeciesCount { get; set; }

        public double Density => DinosaursCount / Area;
    }
}