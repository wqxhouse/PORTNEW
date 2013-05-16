using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace PORTAPP.WineJournal
{
    public class JournalEditorVM
    {
        private readonly WineDataDomain.IJournalPageRepository _repo;
        private readonly UserSystem.IUserState _userState;
        private WineDataDomain.Journal journalToEdit;

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
                                journalToEdit = 
                                    getJournalFromJournalCollection(journalPage, journalCollection);
                            }
                        });

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
                return journalToEdit.Title;
            }
        }

        public string Text
        {
            get
            {
                return journalToEdit.Text;
            }
        }

        public DateTime Date
        {
            get
            {
                return journalToEdit.Date;
            }
        }

         
    }
}
