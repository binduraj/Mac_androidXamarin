using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace SharedLibrary
{
    public class DatabaseOperations
    {
        public DatabaseOperations()
        {
        }

        public string GetDataBasePath()
        {
            //data/user/0/personal/gamerdata.db3
            return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "gamerdata.db3");
        }

        public SQLiteConnection CreateDatabase(string dbPath)
        {
            //Create a new database or use an existing one
            return new SQLiteConnection(dbPath);
        }

        public int insertGamerInfo(GameScore gameInfo)
        {
            var db = CreateDatabase(GetDataBasePath());

            //creates a new table if it doesn't exists
            db.CreateTable<GameScore>();

            db.Insert(gameInfo);

            return db.Table<GameScore>().Count();
        }

        public List<GameScore> GetGamers()
        {
            var gamers = new List<GameScore>();

            var db = CreateDatabase(GetDataBasePath());
            var records = db.Table<GameScore>();
            foreach(var rec in records)
            {
                gamers.Add(new GameScore() {
                    Id = rec.Id,
                    Name = rec.Name,
                    Score = rec.Score
                });

            }

            return gamers;
        }

        public GameScore GetGamerById(int id)
        {
            var db = CreateDatabase(GetDataBasePath());

            var rec = db.Get<GameScore>(id);

            return new GameScore() { Id = rec.Id, Name = rec.Name, Score = rec.Score };
        }

        public int DeleteGamer(int id)
        {
            var db = CreateDatabase(GetDataBasePath());
            return db.Delete<GameScore>(id);
        }

        public void UpdateGamer(GameScore gamer)
        {
            var db = CreateDatabase(GetDataBasePath());
            db.Update(gamer);
        }
    }
}
