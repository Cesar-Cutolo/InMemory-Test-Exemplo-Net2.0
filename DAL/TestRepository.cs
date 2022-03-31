using InMemory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace InMemory.DAL
{
    public static class TestRepository
    {
        static TestRepository()
        {
            using (var context = new TestContext())
            {
                AdicionarLivro(context, "How to capture posts via APIs", "How to use fetch to get a list of blog posts");
                AdicionarLivro(context, "Using Indexed DB", "How to save a list of posts using IndexedDB");
                AdicionarLivro(context, "Clean Code: A Handbook of Agile Software Craftsmanship", "Robert C. Martin");
                AdicionarLivro(context, "Implementing Domain-Driven Design", "Vaughn Vernon");
                AdicionarLivro(context, "Patterns, Principles, and Practices of Domain-Driven Design", "Scott Millet");
                AdicionarLivro(context, "Refactoring: Improving the Design of Existing Code", "Martin Fowler");

                context.SaveChanges();
            }
        }

        private static void AdicionarLivro(TestContext context, string titulo, string shortdescription)
        {
            context.Teste.Add(new Teste()
                {
                    Title = titulo,
                    ShortDescription = shortdescription,
                });
        }

        public static List<Teste> Listar()
        {
            using (var context = new TestContext())
            {
                return context.Teste.OrderBy(c => c.Title).ToList();
            }
        }

        public static void ExcluirPrimeiro()
        {
            using (var context = new TestContext())
            {
                context.Teste.Remove(context.Teste.FirstOrDefault());
                context.SaveChanges();
            }
        }
    }
}