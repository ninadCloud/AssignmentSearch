using AutoMapper;

namespace TestSearch.App_Start
{
    public class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        public static void RegisterProfiles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // add profiles here
            });
            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
    }
}