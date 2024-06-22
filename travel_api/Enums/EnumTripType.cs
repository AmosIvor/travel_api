namespace travel_api.Enums
{
    public enum EnumTripType
    {
        BusinessTrip,   // "Công tác"
        Couple,         // "Cặp đôi"
        Family,         // "Gia đình"
        Friends,        // "Bạn bè"
        Alone           // "Đi một mình"
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
                default:
                    return tripType.ToString();
            }
        }
    }
}
