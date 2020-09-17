using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager //등록 삭제 관리
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];        

        int curCnt = 0;

        public void ShowMenu()
        {
            Console.WriteLine("-------------------- 주소록 --------------------");
            Console.WriteLine("  1. 입력  |  2. 목록  |  3. 검색  |  4. 삭제  |  5. 종료  ");
            Console.WriteLine("------------------------------------------------");
            Console.Write("선택 : ");
        }
        public void InputData() //입력
        {
            Console.Write("이름 : ");
            string phoName = Console.ReadLine();
            if (phoName.Length < 1)
            {
                Console.WriteLine("이름을 입력하세요");
                return;
            }
            Console.Write("전화번호 : ");
            string phoNum = Console.ReadLine();

            if(phoNum.Length < 1)
            {
                Console.WriteLine("전화번호를 입력하세요");
                return;
            }

            Console.Write("생일 : ");
            string phoBir = Console.ReadLine();

            if(phoBir.Length < 1)
            {
                infoStorage[curCnt] = new PhoneInfo(phoName, phoNum);                
            }
            else
            {
                infoStorage[curCnt] = new PhoneInfo(phoName, phoNum, phoBir);
            }
            curCnt++;
        }
        public void ListData() //목록 입력한것만 출력
        {
            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
            }
        }
        public void SearchData() //검색
        {

        }
        public void DeleteData() //삭제
        {

        }
    }
}
