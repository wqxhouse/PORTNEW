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
    [KnownType(typeof(Wine))]
    [KnownType(typeof(Country))]
    public partial class Region
    {
        #region Primitive Properties
        [DataMember]
        public virtual int region_id
        {
            get;
            set;
        }
        [DataMember]
        public virtual int country_code
        {
            get { return _country_code; }
            set
            {
                if (_country_code != value)
                {
                    if (Country != null && Country.country_id != value)
                    {
                        Country = null;
                    }
                    _country_code = value;
                }
            }
        }
        private int _country_code;
        [DataMember]
        public virtual string name
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<Wine> Wine
        {
            get
            {
                if (_wine == null)
                {
                    var newCollection = new FixupCollection<Wine>();
                    newCollection.CollectionChanged += FixupWine;
                    _wine = newCollection;
                }
                return _wine;
            }
            set
            {
                if (!ReferenceEquals(_wine, value))
                {
                    var previousValue = _wine as FixupCollection<Wine>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupWine;
                    }
                    _wine = value;
                    var newValue = value as FixupCollection<Wine>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupWine;
                    }
                }
            }
        }
        private ICollection<Wine> _wine;
        
    
        [DataMember]
        public virtual Country Country
        {
            get { return _country; }
            set
            {
                if (!ReferenceEquals(_country, value))
                {
                    var previousValue = _country;
                    _country = value;
                    FixupCountry(previousValue);
                }
            }
        }
        private Country _country;

        #endregion
        #region Association Fixup
    
        private void FixupCountry(Country previousValue)
        {
            if (previousValue != null && previousValue.Region.Contains(this))
            {
                previousValue.Region.Remove(this);
            }
    
            if (Country != null)
            {
                if (!Country.Region.Contains(this))
                {
                    Country.Region.Add(this);
                }
                if (country_code != Country.country_id)
                {
                    country_code = Country.country_id;
                }
            }
        }
    
        private void FixupWine(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Wine item in e.NewItems)
                {
                    item.Region = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Wine item in e.OldItems)
                {
                    if (ReferenceEquals(item.Region, this))
                    {
                        item.Region = null;
                    }
                }
            }
        }

        #endregion
    }
}