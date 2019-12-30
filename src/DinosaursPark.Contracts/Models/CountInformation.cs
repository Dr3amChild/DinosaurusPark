namespace DinosaursPark.Contracts.Models
{
    public class CountInformation
    {
        public CountInformation(int speciesCount, int dinosaurssCount)
        {
            SpeciesCount = speciesCount;
            DinosaurssCount = dinosaurssCount;
        }

        public int SpeciesCount { get; set; }

        public int DinosaurssCount { get; set; }
    }
}
