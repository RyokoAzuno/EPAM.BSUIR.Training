using System.Collections.Generic;
using AutoMapper;

namespace ImageGalleryApp.DAL.Mappers
{
    /// <summary>
    /// Class wrapper for auto mapper package to convert objects
    /// </summary>
    /// <typeparam name="Src"></typeparam>
    /// <typeparam name="Dest"></typeparam>
    public static class CustomMapper<Src, Dest>
    {
        public static IEnumerable<Dest> Map(IEnumerable<Src> source)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Src, Dest>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Src>, List<Dest>>(source);

            return result;
        }

        public static Dest Map(Src source)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Src, Dest>()).CreateMapper();
            var result = mapper.Map<Src, Dest>(source);

            return result;
        }
    }
}
