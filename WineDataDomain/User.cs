using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Windows.Media;

namespace WineDataDomain
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public string Preference { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ZipCode { get; set; }
        public ImageSource PicUrl { get; set; }

        public User DeepCopy()
        {
            return new User
            {
                ID = this.ID,
                UserName = this.UserName,
                PassWord = this.PassWord,
                Email = this.Email,
                //struct can be deepcopied
                RegDate = this.RegDate,
                Preference = this.Preference,
                DateOfBirth = this.DateOfBirth,
                ZipCode = this.ZipCode,
                PicUrl = this.PicUrl
            };
        }

        
    }
}
