using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Programe
{
    class Program
    {

        static void Main(string[] args)
        {
            string keyword;
            string plan_txt;

            Console.Write("키워드를 입력해주세요 : ");
            keyword = Console.ReadLine();
            keyword = keyword.Replace(" ", "");
            keyword = keyword.ToUpper();


            Console.Write("평문을 입력해주세요 : ");
            plan_txt = Console.ReadLine();
            plan_txt = plan_txt.Replace(" ", "");
            plan_txt = plan_txt.ToUpper();

            Console.Write("암호화 >> ");
            Console.WriteLine(Encryption(keyword, plan_txt,true));

            Console.Write("복호화 >> ");
            Console.WriteLine(Decryption(keyword, plan_txt,false));

        }

        public static string Encryption(string e1, string e2, bool ok)
        {
            //키워드
            char[] single = RemoveDuplicates(e1.ToCharArray(0, e1.Length));
            //평문

            char[] plan = e2.ToCharArray(0, e2.Length);

            List<char> list = new List<char>(single);
            for (int i = single[single.Length - 1] + 1; i < 91; i++)
            {
                list.Add((char)i);
            }

            for (int i = 65; i < 91; i++)
            {
                list.Add((char)i);
            }

            //리스트 중복제거
            list = list.Distinct().ToList();
            string dist = "";
            foreach (char iter in list)
            {
                dist += iter;
            }


            char[] di = dist.ToCharArray(0, dist.Length);
            string str = "";
            char[] alpa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            for (int i = 0; i < e2.Length; i++)
            {
                for (int j = 0; j < di.Length; j++)
                {
                    if (ok == true)
                    {
                        if (plan[i] == alpa[j])
                        {
                            str += di[j];
                        }
                    }
                    else
                    {
                        if (plan[i] == di[j])
                        {
                            str += di[j];
                        }
                    }
                }
            }
            return str;
        }

        public static string Decryption(string d1, string d2, bool ok)
        {
            return Encryption(d1,d2,ok);
        }

        public static char[] RemoveDuplicates(char[] s)
        {
            HashSet<char> set = new HashSet<char>(s);
            char[] result = new char[set.Count];
            set.CopyTo(result);
            return result;
        }
    }

}



