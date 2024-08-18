var builder = WebApplication.CreateBuilder(args); 

/*
 * builder objesi üzerinden uygulama üzerindeki ne gibi yapýlarýn olacaðýný belirlendiði kýsým
 * Uygulama içerisindende var olacak yapýlarý bu kýsýmda tanýmlayabiliriz.
 */

// Add services to the container.

builder.Services.AddControllers(); // Uygulama içerisinde controller yapýsýný kullanabilmek için eklenen servis
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Uygulama içerisinde api endpointlerini kullanabilmek için eklenen servis
builder.Services.AddSwaggerGen();// Uygulama içerisinde swagger kullanabilmek için eklenen servis

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Uygulama gelitirme aþamasýnda ise swagger kullanýlacak
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Uygulama üzerindeki http isteklerini https'e yönlendirme

app.UseAuthorization(); // Uygulama üzerinde yetkilendirme iþlemleri

app.MapControllers(); // Requestlerin controllerlara yönlendirilmesi



app.Run(); // Uygulamanýn çalýþtýrýlmasý
