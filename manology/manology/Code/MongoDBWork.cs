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

		public void SaveViewModel(int userId, string accessToken, string meViewModel)
		{
			MongoCollection<ViewModel> viewModelCollection = _db.GetCollection<ViewModel>("ViewModels");
			IMongoQuery query = Query.EQ("UserId", userId);
			ViewModel newViewModel = new ViewModel
			{
				UserId = userId,
				AccessToken = accessToken,
				MeViewModel = meViewModel,
				UpdateDate = DateTime.Now.ToString(new System.Globalization.CultureInfo("ru-RU"))
			};
			IMongoUpdate update = Update.Replace<ViewModel>(newViewModel);
			viewModelCollection.Update(query, update, UpdateFlags.Upsert);
		}

		public ViewModel LoadViewModel(int userId)
		{
			MongoCollection<ViewModel> viewModelCollection = _db.GetCollection<ViewModel>("ViewModels");
			IMongoQuery query = Query.EQ("UserId", userId);
			return viewModelCollection.FindOne(query);
		}
	}
	public class ViewModel
	{
		[BsonId]
		public ObjectId id { get; set; }
		public int UserId { get; set; }
		public string AccessToken { get; set; }
		public string MeViewModel { get; set; }
		public string UpdateDate { get; set; }
	}

	public class Model
	{
		[BsonId]
		public ObjectId id { get; set; }
		public int UserId { get; set; }
		public string AccessToken { get; set; }
	}
}