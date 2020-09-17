using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneInfo
    {
        string name; //필수
        string phoneNumber; //필수
        string birth; //선택

        
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
        public void ShowPhoneInfo()
        {
            Console.WriteLine($"이름 : {name}, 전화번호 : {phoneNumber}, 생일 : {birth}");
        }
    }
}
