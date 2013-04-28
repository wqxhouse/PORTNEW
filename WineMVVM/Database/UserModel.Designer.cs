﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM 关系源元数据

[assembly: EdmRelationshipAttribute("UsersModel", "PostReply", "Post", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(WineMVVM.Database.Post), "Reply", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(WineMVVM.Database.Reply), true)]
[assembly: EdmRelationshipAttribute("UsersModel", "UserReply", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(WineMVVM.Database.User), "Reply", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(WineMVVM.Database.Reply), true)]
[assembly: EdmRelationshipAttribute("UsersModel", "UserPost", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(WineMVVM.Database.User), "Post", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(WineMVVM.Database.Post), true)]

#endregion

namespace WineMVVM.Database
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class UsersEntities : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“UsersEntities”部分中的连接字符串初始化新 UsersEntities 对象。
        /// </summary>
        public UsersEntities() : base("name=UsersEntities", "UsersEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 UsersEntities 对象。
        /// </summary>
        public UsersEntities(string connectionString) : base(connectionString, "UsersEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 UsersEntities 对象。
        /// </summary>
        public UsersEntities(EntityConnection connection) : base(connection, "UsersEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<Post> Posts
        {
            get
            {
                if ((_Posts == null))
                {
                    _Posts = base.CreateObjectSet<Post>("Posts");
                }
                return _Posts;
            }
        }
        private ObjectSet<Post> _Posts;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<Reply> Replies
        {
            get
            {
                if ((_Replies == null))
                {
                    _Replies = base.CreateObjectSet<Reply>("Replies");
                }
                return _Replies;
            }
        }
        private ObjectSet<Reply> _Replies;

        #endregion
        #region AddTo 方法
    
        /// <summary>
        /// 用于向 Posts EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToPosts(Post post)
        {
            base.AddObject("Posts", post);
        }
    
        /// <summary>
        /// 用于向 Users EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }
    
        /// <summary>
        /// 用于向 Replies EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToReplies(Reply reply)
        {
            base.AddObject("Replies", reply);
        }

        #endregion
    }
    

    #endregion
    
    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="UsersModel", Name="Post")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Post : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 Post 对象。
        /// </summary>
        /// <param name="post_id">post_id 属性的初始值。</param>
        /// <param name="wine_code">wine_code 属性的初始值。</param>
        /// <param name="user_code">user_code 属性的初始值。</param>
        /// <param name="texts">texts 属性的初始值。</param>
        /// <param name="post_date">post_date 属性的初始值。</param>
        /// <param name="post_ip">post_ip 属性的初始值。</param>
        public static Post CreatePost(global::System.Int32 post_id, global::System.Int32 wine_code, global::System.Int32 user_code, global::System.String texts, global::System.DateTime post_date, global::System.String post_ip)
        {
            Post post = new Post();
            post.post_id = post_id;
            post.wine_code = wine_code;
            post.user_code = user_code;
            post.texts = texts;
            post.post_date = post_date;
            post.post_ip = post_ip;
            return post;
        }

        #endregion
        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 post_id
        {
            get
            {
                return _post_id;
            }
            set
            {
                if (_post_id != value)
                {
                    Onpost_idChanging(value);
                    ReportPropertyChanging("post_id");
                    _post_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("post_id");
                    Onpost_idChanged();
                }
            }
        }
        private global::System.Int32 _post_id;
        partial void Onpost_idChanging(global::System.Int32 value);
        partial void Onpost_idChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 wine_code
        {
            get
            {
                return _wine_code;
            }
            set
            {
                Onwine_codeChanging(value);
                ReportPropertyChanging("wine_code");
                _wine_code = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("wine_code");
                Onwine_codeChanged();
            }
        }
        private global::System.Int32 _wine_code;
        partial void Onwine_codeChanging(global::System.Int32 value);
        partial void Onwine_codeChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_code
        {
            get
            {
                return _user_code;
            }
            set
            {
                Onuser_codeChanging(value);
                ReportPropertyChanging("user_code");
                _user_code = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("user_code");
                Onuser_codeChanged();
            }
        }
        private global::System.Int32 _user_code;
        partial void Onuser_codeChanging(global::System.Int32 value);
        partial void Onuser_codeChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String texts
        {
            get
            {
                return _texts;
            }
            set
            {
                OntextsChanging(value);
                ReportPropertyChanging("texts");
                _texts = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("texts");
                OntextsChanged();
            }
        }
        private global::System.String _texts;
        partial void OntextsChanging(global::System.String value);
        partial void OntextsChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime post_date
        {
            get
            {
                return _post_date;
            }
            set
            {
                Onpost_dateChanging(value);
                ReportPropertyChanging("post_date");
                _post_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("post_date");
                Onpost_dateChanged();
            }
        }
        private global::System.DateTime _post_date;
        partial void Onpost_dateChanging(global::System.DateTime value);
        partial void Onpost_dateChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String post_ip
        {
            get
            {
                return _post_ip;
            }
            set
            {
                Onpost_ipChanging(value);
                ReportPropertyChanging("post_ip");
                _post_ip = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("post_ip");
                Onpost_ipChanged();
            }
        }
        private global::System.String _post_ip;
        partial void Onpost_ipChanging(global::System.String value);
        partial void Onpost_ipChanged();

        #endregion
    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "PostReply", "Reply")]
        public EntityCollection<Reply> Replies
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Reply>("UsersModel.PostReply", "Reply");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Reply>("UsersModel.PostReply", "Reply", value);
                }
            }
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "UserPost", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserPost", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserPost", "User").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserPost", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("UsersModel.UserPost", "User", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="UsersModel", Name="Reply")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Reply : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 Reply 对象。
        /// </summary>
        /// <param name="reply_id">reply_id 属性的初始值。</param>
        /// <param name="post_code">post_code 属性的初始值。</param>
        /// <param name="texts">texts 属性的初始值。</param>
        /// <param name="user_code">user_code 属性的初始值。</param>
        /// <param name="post_date">post_date 属性的初始值。</param>
        /// <param name="post_ip">post_ip 属性的初始值。</param>
        public static Reply CreateReply(global::System.Int32 reply_id, global::System.Int32 post_code, global::System.String texts, global::System.Int32 user_code, global::System.DateTime post_date, global::System.String post_ip)
        {
            Reply reply = new Reply();
            reply.reply_id = reply_id;
            reply.post_code = post_code;
            reply.texts = texts;
            reply.user_code = user_code;
            reply.post_date = post_date;
            reply.post_ip = post_ip;
            return reply;
        }

        #endregion
        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 reply_id
        {
            get
            {
                return _reply_id;
            }
            set
            {
                if (_reply_id != value)
                {
                    Onreply_idChanging(value);
                    ReportPropertyChanging("reply_id");
                    _reply_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("reply_id");
                    Onreply_idChanged();
                }
            }
        }
        private global::System.Int32 _reply_id;
        partial void Onreply_idChanging(global::System.Int32 value);
        partial void Onreply_idChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 post_code
        {
            get
            {
                return _post_code;
            }
            set
            {
                Onpost_codeChanging(value);
                ReportPropertyChanging("post_code");
                _post_code = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("post_code");
                Onpost_codeChanged();
            }
        }
        private global::System.Int32 _post_code;
        partial void Onpost_codeChanging(global::System.Int32 value);
        partial void Onpost_codeChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String texts
        {
            get
            {
                return _texts;
            }
            set
            {
                OntextsChanging(value);
                ReportPropertyChanging("texts");
                _texts = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("texts");
                OntextsChanged();
            }
        }
        private global::System.String _texts;
        partial void OntextsChanging(global::System.String value);
        partial void OntextsChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_code
        {
            get
            {
                return _user_code;
            }
            set
            {
                Onuser_codeChanging(value);
                ReportPropertyChanging("user_code");
                _user_code = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("user_code");
                Onuser_codeChanged();
            }
        }
        private global::System.Int32 _user_code;
        partial void Onuser_codeChanging(global::System.Int32 value);
        partial void Onuser_codeChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime post_date
        {
            get
            {
                return _post_date;
            }
            set
            {
                Onpost_dateChanging(value);
                ReportPropertyChanging("post_date");
                _post_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("post_date");
                Onpost_dateChanged();
            }
        }
        private global::System.DateTime _post_date;
        partial void Onpost_dateChanging(global::System.DateTime value);
        partial void Onpost_dateChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String post_ip
        {
            get
            {
                return _post_ip;
            }
            set
            {
                Onpost_ipChanging(value);
                ReportPropertyChanging("post_ip");
                _post_ip = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("post_ip");
                Onpost_ipChanged();
            }
        }
        private global::System.String _post_ip;
        partial void Onpost_ipChanging(global::System.String value);
        partial void Onpost_ipChanged();

        #endregion
    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "PostReply", "Post")]
        public Post Post
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Post>("UsersModel.PostReply", "Post").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Post>("UsersModel.PostReply", "Post").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Post> PostReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Post>("UsersModel.PostReply", "Post");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Post>("UsersModel.PostReply", "Post", value);
                }
            }
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "UserReply", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserReply", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserReply", "User").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("UsersModel.UserReply", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("UsersModel.UserReply", "User", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="UsersModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 User 对象。
        /// </summary>
        /// <param name="user_id">user_id 属性的初始值。</param>
        /// <param name="nickname">nickname 属性的初始值。</param>
        /// <param name="password">password 属性的初始值。</param>
        /// <param name="email">email 属性的初始值。</param>
        /// <param name="reg_date">reg_date 属性的初始值。</param>
        /// <param name="reg_ip">reg_ip 属性的初始值。</param>
        public static User CreateUser(global::System.Int32 user_id, global::System.String nickname, global::System.String password, global::System.String email, global::System.DateTime reg_date, global::System.String reg_ip)
        {
            User user = new User();
            user.user_id = user_id;
            user.nickname = nickname;
            user.password = password;
            user.email = email;
            user.reg_date = reg_date;
            user.reg_ip = reg_ip;
            return user;
        }

        #endregion
        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                if (_user_id != value)
                {
                    Onuser_idChanging(value);
                    ReportPropertyChanging("user_id");
                    _user_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("user_id");
                    Onuser_idChanged();
                }
            }
        }
        private global::System.Int32 _user_id;
        partial void Onuser_idChanging(global::System.Int32 value);
        partial void Onuser_idChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                OnnicknameChanging(value);
                ReportPropertyChanging("nickname");
                _nickname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("nickname");
                OnnicknameChanged();
            }
        }
        private global::System.String _nickname;
        partial void OnnicknameChanging(global::System.String value);
        partial void OnnicknameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                OnemailChanging(value);
                ReportPropertyChanging("email");
                _email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("email");
                OnemailChanged();
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime reg_date
        {
            get
            {
                return _reg_date;
            }
            set
            {
                Onreg_dateChanging(value);
                ReportPropertyChanging("reg_date");
                _reg_date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("reg_date");
                Onreg_dateChanged();
            }
        }
        private global::System.DateTime _reg_date;
        partial void Onreg_dateChanging(global::System.DateTime value);
        partial void Onreg_dateChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String reg_ip
        {
            get
            {
                return _reg_ip;
            }
            set
            {
                Onreg_ipChanging(value);
                ReportPropertyChanging("reg_ip");
                _reg_ip = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("reg_ip");
                Onreg_ipChanged();
            }
        }
        private global::System.String _reg_ip;
        partial void Onreg_ipChanging(global::System.String value);
        partial void Onreg_ipChanged();

        #endregion
    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "UserReply", "Reply")]
        public EntityCollection<Reply> Replies
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Reply>("UsersModel.UserReply", "Reply");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Reply>("UsersModel.UserReply", "Reply", value);
                }
            }
        }
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("UsersModel", "UserPost", "Post")]
        public EntityCollection<Post> Posts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Post>("UsersModel.UserPost", "Post");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Post>("UsersModel.UserPost", "Post", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}