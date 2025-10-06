using SQLite;
using System.Collections.ObjectModel;

namespace TestLab
{
	public class MySQLiteDatabase
	{
		private SQLiteConnection dbConnection;
		public const string DB_FILENAME = "MyDB.db3";
		public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite |
											SQLiteOpenFlags.Create |
											SQLiteOpenFlags.SharedCache;

		public string dbPath = "";

        public const string TAKENOTE_TABLE = "Takenote";
		public const string ID_COL = "ID";
		public const string NOTE_KEY_COL = "NoteKey";

        public MySQLiteDatabase()
		{
			init();
		}

		public void init()
		{
			dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
			dbConnection = new SQLiteConnection(dbPath);
			dbConnection.CreateTable<TakeNotePage>();
		}

		public int insertTakeNote(TakeNotePage tn)
		{
			return dbConnection.Insert(tn);
		}

		public ObservableCollection<TakeNotePage> loadTakeNote()
		{
			return (new ObservableCollection<TakeNotePage>(dbConnection.Table<TakeNotePage>().ToList()));
		}
	}
}

