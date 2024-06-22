using travel_api.Enums;

namespace travel_api.Helpers
{
    public static class FeedbackFilterHelper
    {
        public static DateTime GetStartDateTimeFeedbackFilter(EnumFilterDateFeedback filter)
        {
            switch (filter)
            {
                case EnumFilterDateFeedback.MotNgayQua:
                    return DateTime.Now.AddDays(-1);
                case EnumFilterDateFeedback.MotTuanQua:
                    return DateTime.Now.AddDays(-7);
                case EnumFilterDateFeedback.MotThangQua:
                    return DateTime.Now.AddMonths(-1);
                case EnumFilterDateFeedback.BaThangQua:
                    return DateTime.Now.AddMonths(-3);
                case EnumFilterDateFeedback.SauThangQua:
                    return DateTime.Now.AddMonths(-6);
                case EnumFilterDateFeedback.MotNamQua:
                    return DateTime.Now.AddYears(-1);
                case EnumFilterDateFeedback.TatCa:
                default:
                    return DateTime.MinValue;
            }
        }
    }
}
