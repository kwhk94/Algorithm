using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmMain.프로그래머스
{
    /*
     과제를 받은 루는 다음과 같은 순서대로 과제를 하려고 계획을 세웠습니다.
    과제는 시작하기로 한 시각이 되면 시작합니다.
    새로운 과제를 시작할 시각이 되었을 때, 기존에 진행 중이던 과제가 있다면 진행 중이던 과제를 멈추고 새로운 과제를 시작합니다.
    진행중이던 과제를 끝냈을 때, 잠시 멈춘 과제가 있다면, 멈춰둔 과제를 이어서 진행합니다.
    만약, 과제를 끝낸 시각에 새로 시작해야 되는 과제와 잠시 멈춰둔 과제가 모두 있다면, 새로 시작해야 하는 과제부터 진행합니다.
    멈춰둔 과제가 여러 개일 경우, 가장 최근에 멈춘 과제부터 시작합니다.
    과제 계획을 담은 이차원 문자열 배열 plans가 매개변수로 주어질 때, 과제를 끝낸 순서대로 이름을 배열에 담아 return 하는 solution 함수를 완성해주세요.
     */
    public class 과제진행하기
    {
        public static string[] solution(string[,] plans)
        {
            string[] answer = new string[] { };

            // 데이터 생성
            List<Plan> planList = new List<Plan>();
            for (int i = 0; i < plans.GetLength(0); i++)
            {
                string[] palnValue = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    palnValue[j] = plans[i, j];
                }
                planList.Add(new Plan(palnValue));
            }

            // 시작 시간을 기점으로 정렬
            planList = planList.OrderBy(x => x.GetStartTime).ToList();

            // 결과를 가져갈 result 리스트
            List<string> result = new List<string>();

            // 데이터를 넣고 빼면서 연산할 Stack
            Stack<Plan> ts = new Stack<Plan>();
            ts.Push(planList[0]);

            // 경과 시간
            int currentTime = planList[0].GetStartTime;
            // 경과 인덱스 --> 시작은 하나를 빼고 시작한다
            int index = 1;
            var t = ts.Pop();

            while (true)
            {
                // pop 한게 시간이 더 적게걸리면 LIst에 넣는다
                if (t.DelayTime(currentTime) <= planList[index].GetStartTime)
                {
                    // 계산 결과 먼저 빠져나온 것을 result에 넣어준다
                    result.Add(t.GetName);
                    currentTime = t.DelayTime(currentTime);
                }
                else
                {
                    //pop한 객체의 경과 시간값을 빼줘야한다
                    t.CalcPlayTime(planList[index].GetStartTime - currentTime);
                    currentTime = planList[index].GetStartTime;
                    // pop한 것을 넣고 그 다음것을 넣는다
                    ts.Push(t);
                    ts.Push(planList[index++]);
                }

                // 스택이 다 pop 되었다면 다음 것을 넣어주고 경과 시간을 갱신한다
                if (ts.Count == 0)
                {
                    currentTime = planList[index].GetStartTime;
                    ts.Push(planList[index++]);
                }
                // 데이터를 다 꺼냈으면 break하여 나가기
                if (index >= planList.Count)
                {
                    break;
                }
                // 스택에서 데이터를 하나 꺼낸다
                t = ts.Pop();
            }

            // 최종적으로 스택에 있는 데이터를 순서대로 꺼내 갱신
            while (ts.Count > 0)
            {
                result.Add(ts.Pop().GetName);
            }
            answer = result.ToArray();

            return answer;
        }
    }

    public class Plan
    {
        string mName;
        public string GetName { get => mName; }
        int mStartTime;
        public int GetStartTime { get => mStartTime; }
        int mPlayTime;
        public Plan(string[] _value)
        {
            mName = _value[0];
            string hour = _value[1].Split(':')[0];
            string min = _value[1].Split(':')[1];
            mStartTime = int.Parse(hour)*60+int.Parse(min);
            mPlayTime = int.Parse(_value[2]);
        }

        public int DelayTime(int _currentTIme)
        {
            return _currentTIme + mPlayTime;
        }

        public void CalcPlayTime(int _time)
        {
            mPlayTime -= _time;
        }

    }

}
