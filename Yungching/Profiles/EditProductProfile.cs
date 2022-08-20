using AutoMapper;
using Yungching.Models;
using Yungching.ViewModels;

namespace Yungching.Profiles
{
    public class EditProductProfile : Profile
    {
        public EditProductProfile() 
        {
            CreateMap<EditProduct, Product>().ForMember(x=>x.ProductId,opt=>opt.Ignore());
        }
    }
}
