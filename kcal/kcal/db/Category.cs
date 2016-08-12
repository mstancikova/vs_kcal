using SQLite;

namespace kcal.db
{
    public class Category : zerox.core.EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

    }
}
