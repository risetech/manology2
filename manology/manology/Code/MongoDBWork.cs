using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace manology.Code
{
	public class MongoWork
	{
		private MongoServer _server;

		private MongoDatabase _db;

		public MongoWork()
		{
			_server = MongoServer.Create("mongodb://127.0.0.1:27017/");
			_db = _server.GetDatabase("Manology");
		}

		public void SaveViewModelMetadata(int userId, string accessToken, string meViewModel)
		{
			MongoCollection<ManologyUser> manologyUserCollection = _db.GetCollection<ManologyUser>("ManologyUsers");
			IMongoQuery query = Query.EQ("UserId", userId);
			ManologyUser manologyUser = new ManologyUser
			{
				UserId = userId,
				AccessToken = accessToken,
				MeViewModel = meViewModel,
				UpdateDate = DateTime.Now.ToString(new System.Globalization.CultureInfo("ru-RU"))
			};
			IMongoUpdate update = Update.Replace<ManologyUser>(manologyUser);
			manologyUserCollection.Update(query, update, UpdateFlags.Upsert);
		}

		public ManologyUser LoadViewModelMetadata(int userId)
		{
			MongoCollection<ManologyUser> manologyUserCollection = _db.GetCollection<ManologyUser>("ManologyUsers");
			IMongoQuery query = Query.EQ("UserId", userId);
			return manologyUserCollection.FindOne(query);
		}

		public void AddToRecentlyViewed(int userId, string viewedUser)
		{
			MongoCollection<ManologyUser> manologyUserCollection = _db.GetCollection<ManologyUser>("ManologyUsers");
			IMongoQuery query = Query.EQ("UserId", userId);
			IMongoUpdate updateAdd = Update.AddToSet("RecentlyViewed", viewedUser);
			ManologyUser manologyUser = manologyUserCollection.FindOne(query);
			if (manologyUser.RecentlyViewed.Count >= 3)
			{
				IMongoUpdate updatePull = Update.Pull("RecentlyWatched", manologyUser.RecentlyViewed[0]);
				manologyUserCollection.Update(query, updatePull);
			}
			manologyUserCollection.Update(query, updateAdd, UpdateFlags.Upsert);
		}

		public List<string> LoadRecentlyViewed(int userId)
		{
			MongoCollection<ManologyUser> manologyUserCollection = _db.GetCollection<ManologyUser>("ViewModels");
			IMongoQuery query = Query.EQ("UserId", userId);
			ManologyUser manologyUser = manologyUserCollection.FindOne(query);
			return manologyUser.RecentlyViewed;
		}
	}

	public class ManologyUser
	{
		[BsonId]
		public ObjectId id { get; set; }
		public int UserId { get; set; }
		public string AccessToken { get; set; }
		public string MeViewModel { get; set; }
		public List<string> RecentlyViewed { get; set; }
		public string UpdateDate { get; set; }
	}
}