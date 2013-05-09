﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace ServiceDataLib
{
    public partial class UsersEntities : ObjectContext
    {
        public const string ConnectionString = "name=UsersEntities";
        public const string ContainerName = "UsersEntities";
    
        #region Constructors
    
        public UsersEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
    		this.ContextOptions.ProxyCreationEnabled = false;
        }
    
        public UsersEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
    		this.ContextOptions.ProxyCreationEnabled = false;
        }
    
        public UsersEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
    		this.ContextOptions.ProxyCreationEnabled = false;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Post> Posts
        {
            get { return _posts  ?? (_posts = CreateObjectSet<Post>("Posts")); }
        }
        private ObjectSet<Post> _posts;
    
        public ObjectSet<User> Users
        {
            get { return _users  ?? (_users = CreateObjectSet<User>("Users")); }
        }
        private ObjectSet<User> _users;
    
        public ObjectSet<Reply> Replies
        {
            get { return _replies  ?? (_replies = CreateObjectSet<Reply>("Replies")); }
        }
        private ObjectSet<Reply> _replies;
    
        public ObjectSet<Color> Colors
        {
            get { return _colors  ?? (_colors = CreateObjectSet<Color>("Colors")); }
        }
        private ObjectSet<Color> _colors;
    
        public ObjectSet<Country> Countries
        {
            get { return _countries  ?? (_countries = CreateObjectSet<Country>("Countries")); }
        }
        private ObjectSet<Country> _countries;
    
        public ObjectSet<Mood> Moods
        {
            get { return _moods  ?? (_moods = CreateObjectSet<Mood>("Moods")); }
        }
        private ObjectSet<Mood> _moods;
    
        public ObjectSet<Region> Regions
        {
            get { return _regions  ?? (_regions = CreateObjectSet<Region>("Regions")); }
        }
        private ObjectSet<Region> _regions;
    
        public ObjectSet<Taste> Tastes
        {
            get { return _tastes  ?? (_tastes = CreateObjectSet<Taste>("Tastes")); }
        }
        private ObjectSet<Taste> _tastes;
    
        public ObjectSet<Wine> Wines
        {
            get { return _wines  ?? (_wines = CreateObjectSet<Wine>("Wines")); }
        }
        private ObjectSet<Wine> _wines;
    
        public ObjectSet<Year> Years
        {
            get { return _years  ?? (_years = CreateObjectSet<Year>("Years")); }
        }
        private ObjectSet<Year> _years;
    
        public ObjectSet<WMMW> WMMWs
        {
            get { return _wMMWs  ?? (_wMMWs = CreateObjectSet<WMMW>("WMMWs")); }
        }
        private ObjectSet<WMMW> _wMMWs;
    
        public ObjectSet<FriendStatus> FriendStatuses
        {
            get { return _friendStatuses  ?? (_friendStatuses = CreateObjectSet<FriendStatus>("FriendStatuses")); }
        }
        private ObjectSet<FriendStatus> _friendStatuses;
    
        public ObjectSet<sim_mat> sim_mat
        {
            get { return _sim_mat  ?? (_sim_mat = CreateObjectSet<sim_mat>("sim_mat")); }
        }
        private ObjectSet<sim_mat> _sim_mat;

        #endregion
    }
}
