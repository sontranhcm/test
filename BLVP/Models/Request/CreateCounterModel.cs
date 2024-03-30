namespace BLVP.Models.Request
{
    public class CreateCounterModel
    {
        public string Key { get; set; }
        public string Format { get; set; } = "000000";
        public string NumberFormat { get; set; } = "{0}";
    }
}
