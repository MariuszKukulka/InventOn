﻿using InventOn.BusinessLogicLayer;
using InventOn.BusinessLogicLayer.BusinessModels;
using InventOn.DataSourceLayer;
using InventOn.PresentationLayer;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using Unity;

namespace InventOn
{
    class Program
    {
        public IBusinessLogicService Business { get; set; }
        public IDataSourceConnectionService DataSource { get; set; }
        public IPresentationService Presentation { get; set; }

        public Program(IBusinessLogicService business, IDataSourceConnectionService dataSource, IPresentationService presentation)
        {
            Business = business;
            DataSource = dataSource;
            Presentation = presentation;
        }

        static void Main(string[] args)
        {
            var databaseContainer = GetServiceByName("DatabaseService");
            var program = databaseContainer.Resolve<Program>();
            var books = program.Business.GetAllBooks();
            program.Presentation.Print(string.Join("\n", books));

            var book = program.Business.GetBookById(5);
            program.Presentation.Print(book.ToString());

            var fileContainer = GetServiceByName("FileService");
            var program2 = fileContainer.Resolve<Program>();

            var booksFile = program2.Business.GetAllBooks();
            program2.Presentation.Print(string.Join("\n", booksFile));

            program2.Business.AddBook(new BusinessBook() { Id = 6, Name = "Test add book" });

            var booksToAdd = new List<BusinessBook>()
            {
                new BusinessBook(){ Id = 7, Name = "AddedFirst" },
                new BusinessBook(){ Id = 8},
            };

            program2.Business.AddBooks(booksToAdd);
            program2.Presentation.Print(string.Join("\n", program2.Business.GetAllBooks()));

            Console.ReadKey();
        }

        private static IUnityContainer GetServiceByName(string name)
        {
            var databaseContainer = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(databaseContainer, name);

            return databaseContainer;
        } 

    }
}
