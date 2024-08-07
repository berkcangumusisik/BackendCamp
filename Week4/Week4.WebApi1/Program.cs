var builder = WebApplication.CreateBuilder(args); 

/*
 * builder objesi üzerinden uygulama üzerindeki ne gibi yapıların olacağını belirlendiği kısım
 * Uygulama içerisindende var olacak yapıları bu kısımda tanımlayabiliriz.
 */

// Add services to the container.

builder.Services.AddControllers(); // Uygulama içerisinde controller yapısını kullanabilmek için eklenen servis
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Uygulama içerisinde api endpointlerini kullanabilmek için eklenen servis
builder.Services.AddSwaggerGen();// Uygulama içerisinde swagger kullanabilmek için eklenen servis

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Uygulama gelitirme aşamasında ise swagger kullanılacak
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Uygulama üzerindeki http isteklerini https'e yönlendirme

app.UseAuthorization(); // Uygulama üzerinde yetkilendirme işlemleri

app.MapControllers(); // Requestlerin controllerlara yönlendirilmesi



app.Run(); // Uygulamanın çalıştırılması
