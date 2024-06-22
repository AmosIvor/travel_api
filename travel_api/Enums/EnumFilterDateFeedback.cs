namespace travel_api.Enums
{
    public enum EnumFilterDateFeedback
    {
        TatCa = 0,
        MotNgayQua = 1,
        MotTuanQua = 2,
        MotThangQua = 3,
        BaThangQua = 4,
        SauThangQua = 5,
        MotNamQua = 6
    }

    public static class EnumFilterDateFeedbackExtensions
    {
        public static string GetFilterDateFeedbackByEnum(this EnumFilterDateFeedback filterDateFeedback)
        {
            switch (filterDateFeedback)
            {
                case EnumFilterDateFeedback.TatCa:
                    return "Tất cả";
                case EnumFilterDateFeedback.MotNgayQua:
                    return "1 ngày qua";
                case EnumFilterDateFeedback.MotTuanQua:
                    return "1 tuần qua";
                case EnumFilterDateFeedback.MotThangQua:
                    return "1 tháng qua";
                case EnumFilterDateFeedback.BaThangQua:
                    return "3 tháng qua";
                case EnumFilterDateFeedback.SauThangQua:
                    return "6 tháng qua";
                case EnumFilterDateFeedback.MotNamQua:
                    return "1 năm qua";
                default:
                    return "Tất cả";
            }
        }
    }
}
