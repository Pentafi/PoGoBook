﻿using System;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Data.Interfaces;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASI.Basecode.Data.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<Genre> GetAllGenres()
        {
            return this.GetDbSet<Genre>();
        }

        public Genre GetGenreById(int id)
        {
            return this.GetDbSet<Genre>().Find(id);
        }

        public void AddGenre(Genre genre)
        {
            this.GetDbSet<Genre>().Add(genre);
            UnitOfWork.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            this.SetEntityState(genre, EntityState.Modified);
            UnitOfWork.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genre = this.GetDbSet<Genre>().Find(id);
            if (genre != null)
            {
                this.GetDbSet<Genre>().Remove(genre);
                UnitOfWork.SaveChanges();
            }
        }

        public bool GenreExists(int id)
        {
            return this.GetDbSet<Genre>().Any(x => x.Id == id);
        }
    }
}
