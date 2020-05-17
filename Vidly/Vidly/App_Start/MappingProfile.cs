using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {//Auto mapper ,, Global asx added there
        //first create mapping profile
        //then goto Global asx.cs to add this mapping profile
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Customer, Customer>();

            Mapper.CreateMap<Movie, Movie>();

            Mapper.CreateMap<Movie, MovieFormViewModel>();

            Mapper.CreateMap<ApplicationUser, ApplicationUser>();

            //you can't actually map that , id ,name == id ,list of ids
            // Mapper.CreateMap<Rental, RentalDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                //to Prevent mapping of Id (PK) if the user changed it in the PUT or POST method
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                //to Prevent mapping of Id (PK) if the user changed it in the PUT or POST method
                .ForMember(m => m.Id, opt => opt.Ignore());

            /*
             * WE don't need this code , because actually we never map a GenreDto object to a Genre
             * Because WE NEVER CREATE GENRES
             * we added them to the app using a sql migration
             * WE NEVER CHANGE THEM
             * WE only get them from the database to set them to the customers ,
             * we map a genre to a genre Dto to present it to the user
             * we only use GenreDto to present the genre THAT'S ALL WE USE IT FOR
             *
             * same thing goes with membership type
             */

            //Mapper.CreateMap<GenreDto, Genre>()
            //    .ForMember(g => g.Id, opt => opt.Ignore());
            //Mapper.CreateMap<GenreDto, Genre>();
            //Ef tries to insert a new Genre Record
            //for the api , genre not to be null
        }
    }
}