﻿using AutoMapper;
using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Author;
using BookStoreApp.Api.Models.Book;
using BookStoreApp.Api.Models.User;

namespace BookStoreApp.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorDetailsDto, Author>().ReverseMap();

            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();

            CreateMap<Book, BookDetailsDto>()
                .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
