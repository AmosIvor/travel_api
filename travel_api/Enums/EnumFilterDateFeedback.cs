namespace travel_api.Enums
{
    public enum EnumFilterDateFeedback
    {
        TatCa,
        MotNgayQua,
        MotTuanQua,
        MotThangQua,
        BaThangQua,
        SauThangQua,
        MotNamQua
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
