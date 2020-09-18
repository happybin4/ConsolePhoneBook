using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name; //필수
        string phoneNumber; //필수
        string birth; //선택        

        public string Name
        {
            get { return name; }
            
        }
        
        public PhoneInfo(string name, string num)
        {
            this.name = name;
            this.phoneNumber = num;
            this.birth = "생략";
        }
        public PhoneInfo(string name, string num, string birth)
        {
            this.name = name;
            this.phoneNumber = num;
            this.birth = birth;
        }
        
        public virtual void ShowPhoneInfo()
        {
            Console.WriteLine($"이름 : {name}, 전화번호 : {phoneNumber}, 생일 : {birth}");
        }

        //ToString()를 override해서 PhoneManager에서 사용해보기
    }

    public class PhoneUnivInfo : PhoneInfo
    {
        string major;
        int year;
        public PhoneUnivInfo(string name, string phonenumber, string major, int year) : base(name, phonenumber)
        {
            this.major = major;
            this.year = year;
        }

        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
        }
    }
    public class PhoneCompany : PhoneInfo
    {
        string company;
        public PhoneCompany(string name, string num, string company) : base(name, num)
        {
            this.company = company;
        }

        public override void ShowPhoneInfo()
        {
            base.ShowPhoneInfo();
        }
    }
}
