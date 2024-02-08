namespace CandleStick.Server.Models.Configuration
{
    public class CandleStickDataConfiguration
    {
        public const string SECTION_NAME = "CandleStickData";

        public string FilePath { get; set; } = string.Empty;
        public string TimeFormat { get; set; } = string.Empty;
        public char Delimiter { get; set; }// = ',';
    }
}
