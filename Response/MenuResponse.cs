namespace HomeFood.Response
{
    public class MenuResponse
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CollaboratorId { get; set; }
        public decimal? Price { get; set; }
        public string State { get; set; }
        public int? QuantityMenuCurrent { get; set; }
        public int? MenuTypeId { get; set; }

    }

}