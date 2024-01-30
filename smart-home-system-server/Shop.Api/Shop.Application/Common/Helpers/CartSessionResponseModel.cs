namespace Shop.Application.Common.Helpers
{
    public class CartSessionResponseModel
    {
        public bool isValid { get; set; }
        public string? ResponseMessage { get; set; }
        public int? CartSession { get; set; }
    }
}
