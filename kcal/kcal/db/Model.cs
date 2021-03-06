﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kcal.db
{
    public class Model
    {
        #region DBconnection

        //access to DB must be synchronized, so this is lock
        private static object _locker = new object();
        // database connection, we need one for application run
        // it will be open in constructor
        private SQLiteConnection _conn;
        #endregion

        #region singleton
        private static Model instance;

        //singleton need private ctor
        private Model()
        {
            // initialize database connection
            _conn = DependencyService.Get<zerox.core.IDb>().GetConnection("kcal");


            // create the tables (if they exists it will skip this )
            _conn.CreateTable<Category>();


            // populate eventually empty tables
            populate_tables();

        }

        public static Model Instance {
            get {
                    if (instance == null)
                    {
                        instance = new Model();
                    }
                    return instance;
                }
            }
        #endregion


        #region Currents
        public Diary CurentDiaryEntry { get; set; }
        public Category CurentCategory { get; set; }
        public Ingredients CurentIngredient { get; set; }
        public Foods CurentFood { get; set; }
        public FIngredients CurentFIngredient { get; set; }
        #endregion


        #region dataFunctions
        public IList<Diary> Diary
        {
            get
            {
                List<Diary> tmp = new List<Diary>();
                tmp.Add(new Diary() { ID = 1, Date = "27/07/2016", FK_IngredientID = 2, FK_FoodID = null });
                tmp.Add(new Diary() { ID = 1, Date = "27/07/2016", FK_IngredientID = 1, FK_FoodID = null });
                tmp.Add(new Diary() { ID = 1, Date = "27/07/2016", FK_IngredientID = null, FK_FoodID = 1 });
                return tmp;
            }
        }
        public IEnumerable<Category> Categories
        {
            get
            {
                return _conn.Table<Category>();
                /*
                List<Category> tmp = new List<Category>();
                tmp.Add(new Category() { ID = 1, Name = "Zelenina" });
                tmp.Add(new Category() { ID = 2, Name = "Ovocie" });
                tmp.Add(new Category() { ID = 3, Name = "Mliecne vyrobky" });
                tmp.Add(new Category() { ID = 4, Name = "Maso" });
                return tmp;
                */
            }
        }

        public IList<Ingredients> Ingredients
        {
            get
            {
                List<Ingredients> tmp = new List<Ingredients>();
                tmp.Add(new Ingredients() { ID = 1, CatName = "Zelenina", Name = "Mrkva", Kcalg = 0.35 });
                tmp.Add(new Ingredients() { ID = 2, CatName = "Zelenina", Name = "Zemiaky", Kcalg = 0.77 });
                tmp.Add(new Ingredients() { ID = 3, CatName = "Ovocie", Name = "Jablko", Kcalg = 0.45 });
                tmp.Add(new Ingredients() { ID = 4, CatName = "Ovocie", Name = "Pomaranc", Kcalg = 0.34 });
                tmp.Add(new Ingredients() { ID = 5, CatName = "Mliecne vyrobky", Name = "Mlieko ciastocne odtucnene", Kcalg = 0.48 });
                tmp.Add(new Ingredients() { ID = 6, CatName = "Mliecne vyrobky", Name = "Maslo", Kcalg = 7.5 });
                return tmp;
            }
        }

        public IList<Foods> Foods
        {
            get
            {
                List<Foods> tmp = new List<Foods>();
                tmp.Add(new Foods() { ID = 1, Name = "Zemiakova kasa", Kcalg = 7.5 });
                tmp.Add(new Foods() { ID = 2, Name = "Zeleninova polievka", Kcalg = 0.25 });
                return tmp;
            }
        }

        public IList<FIngredients> FoodIngredients
        {
            get
            {
                List<FIngredients> tmp = new List<FIngredients>();
                tmp.Add(new FIngredients() { ID = 1, FK_FoodID = 1, FK_IngredientID = 6, Quantity = 100, Kcals = 750 });
                return tmp;
            }
        }
        #endregion

        #region diary_functions
        public string getFoodNameById(int ID)
        {
           try
            {
                return Foods.Where(i => i.ID == ID).First().Name;
            }catch(Exception e) { }

            return "Not Found!";    
        }

        public string getIngredientNameById(int ID)
        {
            try
            {
                return Ingredients.Where(i => i.ID == ID).First().Name;
            }
            catch (Exception e) { }

            return "Not Found!";
        }
        #endregion


        #region TESTING
        private void populate_tables() {
            // categories
            if(_conn.Table<Category>().Count() <= 0)
            {
                _conn.Insert(new Category() { Name = "Zelenina" });
                _conn.Insert(new Category() { Name = "Ovocie" });
                _conn.Insert(new Category() { Name = "Mliecne vyrobky" });
                _conn.Insert(new Category() { Name = "Maso" });
            }
        }

        #endregion
    }
}
