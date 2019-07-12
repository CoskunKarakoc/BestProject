﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Core.DataAccess.NHibarnete
{
    public abstract class NHibernateHelper : IDisposable
    {
        static ISessionFactory _sessionFactory;
        public virtual ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ?? (_sessionFactory = InitializeFactory());
            }
        }

        protected abstract ISessionFactory InitializeFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
