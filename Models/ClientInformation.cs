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

        public ClientInformation() { }

        public ClientInformation(int id, string name, string phone, string email, string address, DateTime birthDate, DateTime registerDate)
        {
            id_ = id;
            name_ = name;
            phone_ = phone;
            email_ = email;
            address_ = address;
            birthDate_ = birthDate;
            registerDate_ = registerDate;
        }

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

        public override string ToString()
        {
            return Id.ToString()
                + ";"
                + Name
                + ";"
                + Phone
                + ";"
                + Email 
                + ";"
                + Address
                + ";"
                + BirthDate.ToString("yyyy-MM-dd")
                + ";"
                + RegisterDate.ToString("yyyy-MM-dd HH:mm:ss")
                +";";
        }
    }
}
