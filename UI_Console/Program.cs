using Application.Dto;
using Application.Mappers;
using Application.UseCases;
using Infrastructure.Persistence.Repositories;
namespace UI_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CatJsonRepo _catRepo = new CatJsonRepo();
            AdopterJsonRepo _adopterRepo = new AdopterJsonRepo();
            AdoptionJsonRepo _adoptionRepo = new AdoptionJsonRepo();
            AdoptionService adoptionService = new AdoptionService(_catRepo, _adoptionRepo,_adopterRepo);
            CatService catService = new CatService(_catRepo, _adoptionRepo);
            DateOnly arrivedDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly birthDate = DateOnly.FromDateTime(new DateTime(2022, 5, 1));
            DateOnly? leftCattery = null;
            //da ricontrollare sexDTo che nn deve essere string ma un int
            CatDto cat1 = new CatDto("Whiskers", "siberiano", new SexDto("male"), "il piu gango di tutta la siberia", birthDate, arrivedDate, leftCattery, null, null);
            CatDto cat2 = new CatDto("Mittens", "persiano", new SexDto("female"), "il piu gango di tutta la persia", birthDate, arrivedDate, leftCattery, null, null);
            AdopterDto adopter1 = new AdopterDto("Mario ", "Rossi", new AddressDto("via parma", "parma", "43100", "Italia"), new PhoneNumberDto("+393274534492"), new FiscalCodeDto("LTFMRA08B15C573E"), new EmailDto("mariolatifi1@icloud.com"));
            adoptionService.AdoptCat(cat1, adopter1, DateOnly.FromDateTime(DateTime.Now));
            adoptionService.AdoptCat(cat2, adopter1, DateOnly.FromDateTime(DateTime.Now));
            catService.AddCat(cat1);
            
        }
    }
}
