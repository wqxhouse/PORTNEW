using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System;
using System.Linq;

namespace PORTAPP.UserSystem
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FriendMatchingVM : ViewModelBase
    {

        private readonly UserSystem.IUserState _userState;
        private readonly WineDataDomain.IUserRepository _userRepo;

        private List<WineDataDomain.User> _allUserData;

        /// <summary>
        /// Initializes a new instance of the FriendMatchingVM class.
        /// </summary>
        public FriendMatchingVM(UserSystem.IUserState userState, WineDataDomain.IUserRepository userRepo)
        {
            _userState = userState;
            _userRepo = userRepo;


            //get all user data in order to perform friend matching
            _userRepo.GetAllUserData(
                (u, e) =>
                {
                    if (e != null)
                    {
                        MessageBox.Show(e.Message);
                    }
                    else
                    {
                        _allUserData = new List<WineDataDomain.User>(u);
                    }
                }
                );

            generateMatchingList();
        }


        #region private method

        private void generateMatchingList()
        {
           
            string thisUserName = _userState.getUserState().LoggedInUserName;
            var thisUser = _allUserData.Where(u => u.UserName == thisUserName).FirstOrDefault();
            var thisUserId = thisUser.ID;

            //first remove self from the list
            _allUserData.Remove(thisUser);

            foreach (WineDataDomain.User user in _allUserData)
            {
                MatchingList.Add(friend_match(thisUserId, user.ID));
            }
        }

        //TODO: needs to move to repository
        private MatchedUser friend_match(int ID_1, int ID_2)
        {

            var matched = new MatchedUser();

            if(_allUserData == null)
            {
                MessageBox.Show("BUG: All user data not queried");
                return null;
            }

            int compareID1 = ID_1;
            int compareID2 = ID_2;
            double similarity = 0.0;

            int numerator = 0;
            int denominator = 0;
            foreach (WineDataDomain.User u in _allUserData)
            {
                if (u.ID == compareID1)
                {
                    if (u.Preference == null)
                    {
                        //MessageBox.Show("user has no preference");
                        return new MatchedUser { Similarity = 0, MatchedItem = null };
                    }
                    string tempPrefer1 = u.Preference.ToString();
                    string[] split1 = tempPrefer1.Split(',');
                    List<string> list1 = new List<string>(split1);
                    denominator = split1.Length;
                    if (split1.Length == 0)
                    {
                        //MessageBox.Show("This User has no preference");
                        return null;

                    }

                    foreach (WineDataDomain.User u2 in _allUserData)
                    {
                        if (u2.ID == compareID2)
                        {
                            string tempPrefer2 = u2.Preference.ToString();
                            string[] split2 = tempPrefer2.Split(',');
                            List<string> list2 = new List<string>(split2);
                            if (split2.Length == 0)
                            {
                                //MessageBox.Show("This User has no preference");
                                return null;
                            }

                            denominator = split2.Length + denominator;

                            //matching logic
                            foreach (string l1 in list1)
                            {
                                int number1 = Convert.ToInt32(l1);
                                foreach (string l2 in list2)
                                {
                                    int number2 = Convert.ToInt32(l2);
                                    if (number1 == number2)
                                    {

                                        matched.MatchedItem.Add(number1);

                                        //Process percent
                                        ++numerator;
                                        --denominator;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            similarity = (double)numerator / (double)denominator;
            matched.Similarity = similarity;

            return matched;
        }

        #endregion


        /// <summary>
        /// The <see cref="FilterText" /> property's name.
        /// </summary>
        public const string FilterTextPropertyName = "FilterText";

        private string _filterText = "";

        /// <summary>
        /// Sets and gets the FilterText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FilterText
        {
            get
            {
                return _filterText;
            }

            set
            {
                if (_filterText == value)
                {
                    return;
                }

                _filterText = value;
                RaisePropertyChanged(FilterTextPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="MatchingList" /> property's name.
        /// </summary>
        public const string MatchingListPropertyName = "MatchingList";

        private ObservableCollection<MatchedUser> _matchingList  ;

        /// <summary>
        /// Sets and gets the MatchingList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MatchedUser> MatchingList
        {
            get
            {
                return _matchingList;
            }

            set
            {
                if (_matchingList == value)
                {
                    return;
                }

                _matchingList = value;
                RaisePropertyChanged(MatchingListPropertyName);
            }
        }
    }
}