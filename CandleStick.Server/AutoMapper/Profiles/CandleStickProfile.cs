using AutoMapper;
using CandleStick.Server.Models;
using CandleStick.Server.Models.ViewModels;

namespace CandleStick.Server.AutoMapper.Profiles
{
    public class CandleStickProfile : Profile
    {
        public CandleStickProfile()
        {
            CreateMap<CandleStickTreeItem, CandleStickTreeViewModel>()
                .ForMember(dst => dst.Open, src => src.MapFrom(i => i.Open.Price))
                .ForMember(dst => dst.Close, src => src.MapFrom(i => i.Close.Price))
                .ForMember(dst => dst.High, src => src.MapFrom(i => i.High.Price))
                .ForMember(dst => dst.Low, src => src.MapFrom(i => i.Low.Price));
                //.ForMember(dst => dst.TimeRange, src => src.MapFrom(i => i.TimeRange))
                //.ForMember(dst => dst.SumVolume, src => src.MapFrom(i => i.SumVolume));
        }
    }
}
