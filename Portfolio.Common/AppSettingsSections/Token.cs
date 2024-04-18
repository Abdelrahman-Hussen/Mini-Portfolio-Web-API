namespace Portfolio.Common.AppSettingsSections
{
    public class Token
    {
        public string Key { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudiance { get; set; }
        public double JWTDurationInMinutes { get; set; }
        public double RefreshDurationInDays { get; set; }
    }
}
