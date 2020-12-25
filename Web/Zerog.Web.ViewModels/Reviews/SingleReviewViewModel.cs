namespace Zerog.Web.ViewModels.Reviews
{
    using AutoMapper;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class SingleReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }

        public string Date { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Review, SingleReviewViewModel>()
               .ForMember(x => x.UserName, opt =>
                   opt.MapFrom(x => x.User.UserName))
               .ForMember(x => x.Date, opt =>
                   opt.MapFrom(x => x.CreatedOn.ToString("G")));
        }
    }
}
