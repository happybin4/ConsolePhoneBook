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
            Console.WriteLine("1. 일반  2. 대학  3. 회사");
            Console.Write("선택 >> ");
            int choice = Utility.ConvertInt(Console.ReadLine());            
            ChoInputData(choice);
        }
        //입력 함수
        private void ChoInputData(int choice)
        {
            Console.Write("이름(필수) : ");
            string phoName = Console.ReadLine().Replace(" ", "");
            if (string.IsNullOrEmpty(phoName))  // == string.IsNullorEmpty(phoName), phoName.Length < 1
            {
                Console.WriteLine("이름을 입력하세요");
                return;
            }
            else
            {
                int dataInx = SearchName(phoName);
                if (dataInx > -1)
                {
                    Console.WriteLine("이미 등록된 이름입니다. 다른 이름으로 입력하세요");
                    return;
                }
            }
            Console.Write("전화번호(필수) : ");
            string phoNum = Console.ReadLine().Replace(" ", "");

            if (phoNum.Length < 1)
            {
                Console.WriteLine("전화번호를 입력하세요");
                return;
            }
            Console.Write("생일 : ");
            string phoBir = Console.ReadLine().Replace(" ", "");
            //일반
            
            if (choice == 1)
            {               
                if (phoBir.Length < 1)
                {
                    infoStorage[curCnt++] = new PhoneInfo(phoName, phoNum);
                }
                else
                {
                    infoStorage[curCnt++] = new PhoneInfo(phoName, phoNum, phoBir);
                }
            }
            //대학
            else if(choice == 2)
            {
                string phoMajor, phoYear;
                Console.Write("학과(필수) : ");
                phoMajor = Console.ReadLine().Replace(" ", "");
                if(phoMajor.Length < 1)
                {
                    Console.WriteLine("학과를 입력하세요");
                    return;
                }
                else
                {
                    Console.Write("학년(1,2,3,4) : ");
                    phoYear = Console.ReadLine().Replace(" ", "");
                }
                if (phoYear.Length < 1)
                {
                    Console.WriteLine("학년를 입력하세요");
                    return;
                }
                else
                {
                    infoStorage[curCnt++] = new PhoneUnivInfo(phoName, phoNum, phoMajor,Utility.ConvertInt(phoYear));
                }                    
            }
            else if(choice == 3)
            {
                Console.Write("회사(필수) : ");
                string phoCompany;
                phoCompany = Console.ReadLine().Replace(" ", "");
                if (phoCompany.Length < 1)
                {
                    Console.WriteLine("회사명을 입력하세요");
                    return;
                }
                else
                {
                    infoStorage[curCnt++] = new PhoneCompany(phoName,phoNum,phoCompany);
                }
            }
            else
            {
                Console.WriteLine("주소 유형 번호을 다시 선택하세요");
                return;
            }
        }

        public void ListData() //목록 입력한것만 출력
        {
            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
            }
        }
        public void SearchData() //검색  trim 앞뒤 공백 제거, Replace 문자 교체
        {
            Console.WriteLine("주소록 검색을 시작합니다......");

            #region for문에서 break; 안씀
            //int findCnt++
            //for(int i=0; i<curCnt; i++)
            //{
            //    if(infoStorage[i].Name.Replace(" ","").CompareTo(name)==0) // Equals(), CompareTo() => 숫자로 결과가 나옴(-1,1,0), ==
            //    {
            //        infoStorage[i].ShowPhoneInfo();
            //        //break;  // 안쓰면 끝까지 돌면서 다찾는다
            //        findCnt++
            //    }
            //}
            //if(findCnt < 1)
            //{
            //    Console.WriteLine("검색된 데이터가 없습니다");
            //}
            //else
            //{
            //    Console.WriteLine($"총 {findCnt} 명이 검색되었습니다);
            //}
            #endregion
            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                Console.WriteLine("검색된 데이터가 없습니다");
            }
            else
            {
                infoStorage[dataIdx].ShowPhoneInfo();
            }
        }

        private int SearchName()
        {
            Console.Write("이름 : ");
            string name = Console.ReadLine().Trim().Replace(" ", "");
            
            
            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0) // Equals(), CompareTo() => 숫자로 결과가 나옴(-1,1,0), ==
                {
                    return i;
                }
            }
            return -1;
        }
        private int SearchName(string name)
        {            
            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0) // Equals(), CompareTo() => 숫자로 결과가 나옴(-1,1,0), ==
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeleteData() //삭제
        {
            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                Console.WriteLine("삭제할 데이터가 없습니다");
            }
            else
            {
                for(int i=dataIdx; i<curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine("주소록 삭제가 완료되었습니다");
            }
        }
    }
}
