using System;

namespace CRUD.Models
{
    public class ClientInformation
    {
        private int id_;
        private string name_;
        private string phone_;
        private string email_;
        private string address_;
        private DateTime birthDate_;
        private DateTime registerDate_;

        public int Id
        {
            get { return id_; }
            set { id_ = value; }
        }

        public string Name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string Phone
        {
            get { return phone_; }
            set { phone_ = value; }
        }

        public string Email
        {
            get { return email_; }
            set { email_ = value; }
        }

        public string Address
        {
            get { return address_; }
            set { address_ = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate_; }
            set { birthDate_ = value; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate_; }
            set { registerDate_ = value; }
        }

    }
}
