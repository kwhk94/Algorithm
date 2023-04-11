using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmMain.프로그래머스
{

    public class SumIntegers
    {
        /*문제 설명
        두 정수 a, b가 주어졌을 때 a와 b 사이에 속한 모든 정수의 합을 리턴하는 함수, solution을 완성하세요.
        예를 들어 a = 3, b = 5인 경우, 3 + 4 + 5 = 12이므로 12를 리턴합니다.

        제한 조건
        a와 b가 같은 경우는 둘 중 아무 수나 리턴하세요.
        a와 b는 -10,000,000 이상 10,000,000 이하인 정수입니다.
        a와 b의 대소관계는 정해져있지 않습니다.*/
        public long solution(int a, int b)
        {
            long answer = 0;

            int lower = a <= b ? a : b;
            int upper = a > b ? a : b;

            for (int i = lower; i <= upper; i++)
            {
                answer += i;
            }

            return answer;
        }
    }

    public class KaKaopersonalitytype
    {
        /*
         지표 번호	성격 유형
        1번 지표	라이언형(R), 튜브형(T)
        2번 지표	콘형(C), 프로도형(F)
        3번 지표	제이지형(J), 무지형(M)
        4번 지표	어피치형(A), 네오형(N)
         */
        Dictionary<string, int> mKakaoDic = new Dictionary<string, int>();

        public string solution(string[] survey, int[] choices)
        {
            string answer = "";

            mKakaoDic.Add("R", 0);
            mKakaoDic.Add("T", 0);
            mKakaoDic.Add("C", 0);
            mKakaoDic.Add("F", 0);
            mKakaoDic.Add("J", 0);
            mKakaoDic.Add("M", 0);
            mKakaoDic.Add("A", 0);
            mKakaoDic.Add("N", 0);

            for (int i = 0; i < survey.Length; i++)
            {
                Calculate(survey[i], choices[i]);
            }

            answer += Comparison("R", "T");
            answer += Comparison("C", "F");
            answer += Comparison("J", "M");
            answer += Comparison("A", "N");

            return answer;
        }
        
        public void Calculate(string _surver, int _choice)
        {
            string nameFirst = _surver.Substring(0, 1);
            string nameSecond = _surver.Substring(1, 1);
            switch (_choice)
            {
                case 0:
                    mKakaoDic[nameFirst] += 3;
                    break;
                case 1:
                    mKakaoDic[nameFirst] += 2;
                    break;
                case 2:
                    mKakaoDic[nameFirst] += 1;
                    break;
                case 3:
                    break;
                case 4:
                    mKakaoDic[nameSecond] += 1;
                    break;
                case 5:
                    mKakaoDic[nameSecond] += 2;
                    break;
                case 6:
                    mKakaoDic[nameSecond] += 3;
                    break;

                default:
                    break;
            }
        }

        public string Comparison(string _a, string _b)
        {
            return mKakaoDic[_a] >= mKakaoDic[_b] ? _a : _b;
        }

    }
}
