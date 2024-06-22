namespace travel_api.Enums
{
    public enum EnumTripType
    {
        All = 0,
        BusinessTrip = 1,   // "Công tác"
        Couple = 2,         // "Cặp đôi"
        Family = 3,         // "Gia đình"
        Friends = 4,        // "Bạn bè"
        Alone = 5          // "Đi một mình"
    }

    public static class EnumTripTypeExtensions
    {
        public static string GetTripTypeByEnum(this EnumTripType tripType)
        {
            switch (tripType)
            {
                case EnumTripType.BusinessTrip:
                    return "Công tác";
                case EnumTripType.Couple:
                    return "Cặp đôi";
                case EnumTripType.Family:
                    return "Gia đình";
                case EnumTripType.Friends:
                    return "Bạn bè";
                case EnumTripType.Alone:
                    return "Đi một mình";
                case EnumTripType.All:
                default:
                    return "Tất cả";
            }
        }
    }
}
