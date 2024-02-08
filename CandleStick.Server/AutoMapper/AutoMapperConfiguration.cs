using System.Reflection;

namespace CandleStick.Server.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection service)
        {
            //get and assembly, where is located all profiles from folder AutoMapper -> Profiles -> *
            var myAssembly = Assembly.GetAssembly(typeof(AutoMapperConfiguration));
            //register all Profiles from selected assembly
            service.AddAutoMapper(cfg => {
                cfg.AddMaps(myAssembly);
            });

            //service.AddAutoMapper(cfg =>
            //{
            //    cfg.AddProfile<CandleStickProfile>();
            //});
        }
    }
}
