
   public partial class Language
    {
        public int id { get; set; }
        public int LanguageID { get; set; }
        public string? LanguageName { get; set; }
        public string? DisplayName { get; set; }
        public string? VariableCode { get; set; }
        public string? EnglishName { get; set; }
        public string? NativeName { get; set; }
        public string? NumberFormat { get; set; }
        public string? DateTimeFormat { get; set; }
        public Nullable<bool> IsNeutralCulture { get; set; }
        public Nullable<bool> IsDefaultApplicationLanguage { get; set; }
        public Nullable<System.DateTime> CreatedUTCDate { get; set; }
        public string? FlagIcon { get; set; }
    }

