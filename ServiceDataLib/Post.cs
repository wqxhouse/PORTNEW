//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace ServiceDataLib
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Reply))]
    [KnownType(typeof(User))]
    public partial class Post
    {
        #region Primitive Properties
        [DataMember]
        public virtual int post_id
        {
            get;
            set;
        }
        [DataMember]
        public virtual int wine_code
        {
            get;
            set;
        }
        [DataMember]
        public virtual int user_code
        {
            get { return _user_code; }
            set
            {
                if (_user_code != value)
                {
                    if (User != null && User.user_id != value)
                    {
                        User = null;
                    }
                    _user_code = value;
                }
            }
        }
        private int _user_code;
        [DataMember]
        public virtual string texts
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime post_date
        {
            get;
            set;
        }
        [DataMember]
        public virtual string post_ip
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<Reply> Replies
        {
            get
            {
                if (_replies == null)
                {
                    var newCollection = new FixupCollection<Reply>();
                    newCollection.CollectionChanged += FixupReplies;
                    _replies = newCollection;
                }
                return _replies;
            }
            set
            {
                if (!ReferenceEquals(_replies, value))
                {
                    var previousValue = _replies as FixupCollection<Reply>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReplies;
                    }
                    _replies = value;
                    var newValue = value as FixupCollection<Reply>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReplies;
                    }
                }
            }
        }
        private ICollection<Reply> _replies;
        
    
        [DataMember]
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private User _user;

        #endregion
        #region Association Fixup
    
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.Posts.Contains(this))
            {
                previousValue.Posts.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Posts.Contains(this))
                {
                    User.Posts.Add(this);
                }
                if (user_code != User.user_id)
                {
                    user_code = User.user_id;
                }
            }
        }
    
        private void FixupReplies(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Reply item in e.NewItems)
                {
                    item.Post = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Reply item in e.OldItems)
                {
                    if (ReferenceEquals(item.Post, this))
                    {
                        item.Post = null;
                    }
                }
            }
        }

        #endregion
    }
}