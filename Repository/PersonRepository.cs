﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ctrujilloS5A.Models;
using SQLite;

namespace ctrujilloS5A.Repository
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string statusMessage {  get; set; }

        public PersonRepository(string path)
        {
            dbPath = path;
        }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name = name };
                result = conn.Insert(person);
                statusMessage = string.Format("Dato ingresado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERRROR "+ex);
            }
        }

        public List<Persona>GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERRROR "+ex);
            }
            return new List<Persona>();
        }

        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("Nombre no encontrado");

                person.Name = newName;
                conn.Update(person);
                statusMessage = string.Format("Dato actualizado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERRROR " + ex);
            }          
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("Nombre Eliminado");

                conn.Delete(person);
                statusMessage = string.Format("Dato eliminado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERRROR " + ex);
            }
        }
    }
}
