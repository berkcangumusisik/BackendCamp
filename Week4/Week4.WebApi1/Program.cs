var builder = WebApplication.CreateBuilder(args); 

/*
 * builder objesi �zerinden uygulama �zerindeki ne gibi yap�lar�n olaca��n� belirlendi�i k�s�m
 * Uygulama i�erisindende var olacak yap�lar� bu k�s�mda tan�mlayabiliriz.
 */

// Add services to the container.

builder.Services.AddControllers(); // Uygulama i�erisinde controller yap�s�n� kullanabilmek i�in eklenen servis
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Uygulama i�erisinde api endpointlerini kullanabilmek i�in eklenen servis
builder.Services.AddSwaggerGen();// Uygulama i�erisinde swagger kullanabilmek i�in eklenen servis

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Uygulama gelitirme a�amas�nda ise swagger kullan�lacak
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Uygulama �zerindeki http isteklerini https'e y�nlendirme

app.UseAuthorization(); // Uygulama �zerinde yetkilendirme i�lemleri

app.MapControllers(); // Requestlerin controllerlara y�nlendirilmesi



app.Run(); // Uygulaman�n �al��t�r�lmas�
