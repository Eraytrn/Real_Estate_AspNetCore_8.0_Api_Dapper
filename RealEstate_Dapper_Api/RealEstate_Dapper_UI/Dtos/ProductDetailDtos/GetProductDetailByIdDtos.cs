namespace RealEstate_Dapper_UI.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDtos
    {
        public int productDetailID { get; set; }
        public int productSize { get; set; }
        public int bedRoomCount { get; set; }
        public int bathCount { get; set; }
        public int roomCount { get; set; }
        public int garageSize { get; set; }
        public string buildYear { get; set; }
        public decimal price { get; set; }
        public string location { get; set; }
        public string videoUrl { get; set; }
        public int productID { get; set; }
    }
}
