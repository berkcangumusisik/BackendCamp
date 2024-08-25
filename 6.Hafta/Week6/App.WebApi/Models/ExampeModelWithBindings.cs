using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace App.WebApi.Models
{
    [Bind("sayi1, sayi2")]
    public class ExampleModelWithBindings
    {
        //[FromRoute(Name = "sayi1")]
        //public int Sayi1 { get; set; }

        //[FromRoute(Name = "sayi2")]
        //public int Sayi2 { get; set; }

        //[BindNever]
        //public int Sonuc { get; set; }


        //[BindProperty]
        public int sayi1 { get; set; }

        //[BindProperty]
        public int sayi2 { get; set; }

        [BindNever]
        public int Sonuc { get; set; }
    }
}

// FromRoute attribute, bir sınıfın property'lerinin hangi route parametresi ile eşleşeceğini belirlemek için kullanılır.
// BindNever attribute, bir property'nin model binding işlemine dahil edilmemesi gerektiğini belirtir.
// BindProperty attribute, bir property'nin model binding işlemine dahil edilmesi gerektiğini belirtir.