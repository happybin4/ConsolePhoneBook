using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class Utility
    {
        //문자열을 int로 형변환
        public static int ConvertInt(string str)
        {
            int num =0;
            bool bFlag = false;
            while (!bFlag)
            {
                bFlag = int.TryParse(str, out num);//콘솔에서만 사용가능하다 
            }          
            return num;
        }

        //문자열을 double로 형변환
        public static double ConvertDouble(string str)
        {
            double num;
            bool bFlag = double.TryParse(str, out num);
            if (!bFlag)
                num = 0.0;

            return num;
        }
    }
}
