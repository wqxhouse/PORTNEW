using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Collections.ObjectModel;

namespace PORTAPP.WineJournal
{
    public class JournalEditorVM
    {
        private readonly WineDataDomain.IJournalPageRepository _repo;
        private readonly UserSystem.IUserState _userState;
        private WineDataDomain.Journal _journalToEdit;

        private ObservableCollection<WineDataDomain.Journal> _userJournalCollection;
        public ObservableCollection<WineDataDomain.Journal> UserJournalCollection
        {
            get
            {
                return _userJournalCollection;
            }
        }

        public JournalEditorVM(UserSystem.IUserState userState, WineDataDomain.IJournalPageRepository repo)
        {
            _repo = repo;
            _userState = userState;

            Messenger.Default.Register<WineDataDomain.JournalPage>(this, "ToJournalEditorVM_journalPage",
                (journalPage) =>
                {
                    _repo.GetUserJournalCollection(_userState.getUserState().LoggedInUserName,
                        (journalCollection, exception) =>
                        {
                            if (exception != null)
                            {
                                MessageBox.Show(exception.Message);
                            }
                            else
                            {
                                _userJournalCollection = new ObservableCollection<WineDataDomain.Journal>(journalCollection);
                                _journalToEdit =
                                    getJournalFromJournalCollection(journalPage, _userJournalCollection);
                            }
                        });

                });

            Messenger.Default.Register<string>(
                this,
                "FromTextWindow_ToJournalEditorVM_Text",
                updateJournalDataBase);

        }

        

        private void updateJournal(string journalText)
        {
            
        }

        private void updateJournalDataBase(string journalText)
        {
            _repo.UpdateUserJournal(_userState.getUserState().LoggedInUserName,
                new ObservableCollection<WineDataDomain.Journal>{
                    new WineDataDomain.Journal
                    {
                        Text = "Hacked!!!"
                    },
                    new WineDataDomain.Journal
                    {
                        Text = "Wqxhouse"
                    }
                },

                (b, e) =>
                {
                    if (b != true || e != null)
                    {
                        MessageBox.Show("Errors: " + e.Message);
                    }
                });

        }

        private WineDataDomain.Journal 
            getJournalFromJournalCollection
            (WineDataDomain.JournalPage currentPage, 
                IEnumerable<WineDataDomain.Journal> collection)
        {
            var query = from j in collection
                        where j.JournalID == currentPage.JournalID
                        select j;

            var result = query.FirstOrDefault();
            if (result == null)
            {
                MessageBox.Show("GetJournalFromJournalCollection Failed!");
            }

            return result;
        }

        public string Title
        {
            get
            {
                return _journalToEdit.Title;
            }
        }

        public string Text
        {
            get
            {
                return _journalToEdit.Text;
            }
        }

        public DateTime Date
        {
            get
            {
                return _journalToEdit.Date;
            }
        }

         
    }
}
