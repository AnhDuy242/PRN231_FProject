using API.Models;
using API.ViewVM;
using API.ViewVM.Order;
using AutoMapper;

namespace API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductVM>()
       .ForMember(dest => dest.TotalUnitSale, otp => otp.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity)))
       
       
                .ForMember(dest => dest.CategoryName, otp => otp.MapFrom(src => src.Category.CategoryName))
                
               .ForMember(dest => dest.SupplierName, otp => otp.MapFrom(src => src.Supplier.ContactName))
               //.ForMember(dest => dest.CategoryDTOs, otp => otp.MapFrom(src => src.Category))
               .ReverseMap();

            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Category, CategoryUpdate>().ReverseMap();
            CreateMap<Product, ProductAdd>()
                .ReverseMap();
            CreateMap<Order, OrderDeleteProduct>().ReverseMap();

            CreateMap<Order, OrderVM>()
               .ForMember(dest => dest.TotalAmount, otp => otp.MapFrom(src => src.OrderDetails.Sum(od => od.UnitPrice)))
                   .ForMember(dest => dest.IsLateOrder, opt => opt.MapFrom(src => src.ShippedDate > src.RequiredDate))

               .ForMember(dest => dest.CustomerName, otp => otp.MapFrom(src => src.Customer.CompanyName))
               .ForMember(dest => dest.EmployeeName, otp => otp.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName))
               .ForMember(dest => dest.ShipCompanyName, otp => otp.MapFrom(src => src.ShipViaNavigation.CompanyName))


                .ReverseMap();

            CreateMap<Order, OrderDE>()
                .ForMember(dest => dest.CustomerName, otp => otp.MapFrom(src => src.Customer.ContactName))
                 .ForMember(dest => dest.EmployeeName, otp => otp.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName))

                .ForMember(dest => dest.TotalAmount, otp => otp.MapFrom(src => src.OrderDetails.Sum(od => od.UnitPrice)))
                .ForMember(dest => dest.TotalItem, otp => otp.MapFrom(src => src.OrderDetails.Sum(od => od.Quantity)))
                .ReverseMap();

            CreateMap<Customer, CustomerVM>().ReverseMap();
              CreateMap<Product, ProductDetail>().ReverseMap();

            CreateMap<Supplier, SupplierVM>().ReverseMap();
            CreateMap<Supplier, SupplierAdd>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailVm>().ReverseMap();
            CreateMap<Order, OrderAdd>().ReverseMap();
            CreateMap<Order, OrderUpdate>().ReverseMap();

        }
    }
}
