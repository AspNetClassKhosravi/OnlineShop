using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.DomainModels;
using OnlineShop.Models.Frameworks.Contracts;
using System;

namespace OnlineShop.Models.Services
{
    public class PersonRepository(OnlineShopDbContext context) : IPersonRepository
    {
        #region [- Select -]
        public async Task<List<Person>> Select()
        {
            await using (context)
            {
                try
                {
                    var person = await context.Person.ToListAsync();
                    return person;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    await context.DisposeAsync();
                }
            }
        }
        #endregion

        #region [- Insert -]
        public async Task Insert(Person person)
        {
            await using (context)
            {
                try
                {
                    context.Person.Add(person);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    context.DisposeAsync();
                }
            }
        }
        #endregion

        #region [- Update -]
        public async Task Update(Person person)
        {
            try
            {
                context.Update(person);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

        }
        #endregion

        #region [- Delete -]
        public async Task Delete(Person person)
        {
            context.Person.Remove(person);
            await context.SaveChangesAsync();
        } 
        #endregion

        public async Task<Person?> FindById(Guid id)
        {
            var person = await context.Person.FindAsync(id);
            return person;
        }

    }
}
