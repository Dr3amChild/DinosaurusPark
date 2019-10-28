namespace DinosaurusPark.WebApplication.Validation
{
    public static class ErrorCodes
    {
        public const string InternalServerError = "Internal server error";
        public const string PageNumberIsNegativeOrZero = "PageNumber is negative or zero";
        public const string PageSizeIsNegativeOrZero = "PageSize is negative or zero";
        public const string BodyIsNull = "Body is null";
        public const string SpeciesCountIsNegativeOrZero = "SpeciesCount is negative or  zero";
        public const string DinosaursCountIsNegativeOrZero = "DinosaursCount is negative or  zero";
        public const string IdIsEmpty = "Id is empty";
    }
}
