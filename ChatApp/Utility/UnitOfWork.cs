using ChatApp.Context;
using ChatApp.Models;
using ChatApp.Repository;
using System;

namespace ChatApp.Utility
{
    public class UnitOfWork : IDisposable
    {
        private ChatContext context = new ChatContext();
        private GenericRepository<UserRegistration> userRegistrationRepository;

        public GenericRepository<UserRegistration> UserRegistrationRepository
        {
            get
            {
                if (this.userRegistrationRepository == null)
                {
                    this.userRegistrationRepository = new GenericRepository<UserRegistration>(context);
                }
                return userRegistrationRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}