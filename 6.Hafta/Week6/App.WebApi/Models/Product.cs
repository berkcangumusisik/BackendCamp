namespace App.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

// Entity : Bizlerin veritabanında tuttuğumuz verileri temsil eden sınıflardır.
// DTO : Data Transfer Object, veritabanındaki verileri kullanıcıya sunarken kullanılan sınıflardır.