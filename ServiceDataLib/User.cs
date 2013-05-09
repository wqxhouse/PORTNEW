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
    [KnownType(typeof(Post))]
    public partial class User
    {
        #region Primitive Properties
        [DataMember]
        public virtual int user_id
        {
            get;
            set;
        }
        [DataMember]
        public virtual string nickname
        {
            get;
            set;
        }
        [DataMember]
        public virtual string password
        {
            get;
            set;
        }
        [DataMember]
        public virtual string email
        {
            get;
            set;
        }
        [DataMember]
        public virtual System.DateTime reg_date
        {
            get;
            set;
        }
        [DataMember]
        public virtual string reg_ip
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
        public virtual ICollection<Post> Posts
        {
            get
            {
                if (_posts == null)
                {
                    var newCollection = new FixupCollection<Post>();
                    newCollection.CollectionChanged += FixupPosts;
                    _posts = newCollection;
                }
                return _posts;
            }
            set
            {
                if (!ReferenceEquals(_posts, value))
                {
                    var previousValue = _posts as FixupCollection<Post>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPosts;
                    }
                    _posts = value;
                    var newValue = value as FixupCollection<Post>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPosts;
                    }
                }
            }
        }
        private ICollection<Post> _posts;

        #endregion
        #region Association Fixup
    
        private void FixupReplies(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Reply item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Reply item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupPosts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Post item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Post item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }

        #endregion
    }
}