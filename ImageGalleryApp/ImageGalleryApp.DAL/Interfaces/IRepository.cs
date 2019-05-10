﻿using System.Collections.Generic;

namespace ImageGalleryApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Delete(int id);
    }
}
