namespace Application.Settings.Dto
{
    public class GetSettingsDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string SettingName { get; set; }
        public string ItemName { get; set; }
        public string ItemPluralName { get; set; }
        public string PrimaryColor { get; set; }
        public bool IsWaitingListInUse { get; set; }
        public int PrimeTimeHour { get; set; }
        public int PrimeTimeMinutes { get; set; }
        public int LengthOfReservation { get; set; }
    }
}