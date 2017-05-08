using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HentovWebsite.Web.Tests.Mocks
{
    public class FakeDbSet<T> : DbSet<T>, IEnumerable<T>, IQueryable 
        where T : class
    {
        private readonly HashSet<T> set;
        private readonly IQueryable query;


        public FakeDbSet()
        {
            this.set = new HashSet<T>();
            this.query = this.set.AsQueryable();
        }

        public override T Add(T entity)
        {
            this.set.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            this.set.Remove(entity);
            return entity;
        }

        System.Linq.Expressions.Expression IQueryable.Expression => this.query.Expression;

        IQueryProvider IQueryable.Provider => this.query.Provider;

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

    }
}
