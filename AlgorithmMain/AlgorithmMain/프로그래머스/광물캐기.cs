using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AlgorithmMain.알고리즘테스트
{
# region  ===== 문제 설명
    /*
    마인은 곡괭이로 광산에서 광석을 캐려고 합니다.
    마인은 다이아몬드 곡괭이, 철 곡괭이, 돌 곡괭이를 각각 0개에서 5개까지 가지고 있으며, 곡괭이로 광물을 캘 때는 피로도가 소모됩니다. 
    각 곡괭이로 광물을 캘 때의 피로도는 아래 표와 같습니다.

                         다이아                      철                     돌
    다이아                1                          1                        1

    철                     5                          1                       1
     
    돌                    25                         5                        1


    예를 들어, 철 곡괭이는 다이아몬드를 캘 때 피로도 5가 소모되며, 철과 돌을 캘때는 피로도가 1씩 소모됩니다. 각 곡괭이는 종류에 상관없이 광물 5개를 캔 후에는 더 이상 사용할 수 없습니다.

    마인은 다음과 같은 규칙을 지키면서 최소한의 피로도로 광물을 캐려고 합니다.

    사용할 수 있는 곡괭이중 아무거나 하나를 선택해 광물을 캡니다.
    한 번 사용하기 시작한 곡괭이는 사용할 수 없을 때까지 사용합니다.
    광물은 주어진 순서대로만 캘 수 있습니다.
    광산에 있는 모든 광물을 캐거나, 더 사용할 곡괭이가 없을 때까지 광물을 캡니다.
    즉, 곡괭이를 하나 선택해서 광물 5개를 연속으로 캐고, 다음 곡괭이를 선택해서 광물 5개를 연속으로 캐는 과정을 반복하며,
        더 사용할 곡괭이가 없거나 광산에 있는 모든 광물을 캘 때까지 과정을 반복하면 됩니다.

    마인이 갖고 있는 곡괭이의 개수를 나타내는 정수 배열 picks와 광물들의 순서를 나타내는 문자열 배열 minerals가 매개변수로 주어질 때,
    마인이 작업을 끝내기까지 필요한 최소한의 피로도를 return 하는 solution 함수를 완성해주세요.
    */
#endregion

    public class 광물캐기
    {

        public int solution(int[] picks, string[] minerals)
        {
            string[] mMinerals;
            int MaxLength = picks.Sum() * 5;
            // 최대로 캘 수 있는 길이를 먼저 설정한다
            if (MaxLength <= minerals.Length)
            {
                mMinerals = new string[MaxLength];
                Array.Copy(minerals, mMinerals, MaxLength);
            }
            else
            {
                mMinerals = minerals;
            }

            // cost를 5개씩 묶어서 계산 후 내림차순
            var renualCost = ConvertMinerals(mMinerals);

            return Calculate(picks, renualCost);
        }

        class CostStruct
        {
            public int Cost;
            public int DiaCount;
            public int IronCount;
            public int StoneCount;
        }

        // str을 cost로 변환하는 함수
        private CostStruct ConvertMineral(CostStruct cost, string mineralName)
        {
            if (cost == null) cost = new CostStruct();

            switch (mineralName)
            {
                case "diamond":
                    return new CostStruct { Cost = cost.Cost + 25, DiaCount = cost.DiaCount + 1, IronCount = cost.IronCount, StoneCount = cost.StoneCount };
                case "iron":
                    return new CostStruct { Cost = cost.Cost + 5, DiaCount = cost.DiaCount, IronCount = cost.IronCount + 1, StoneCount = cost.StoneCount };
                case "stone":
                    return new CostStruct { Cost = cost.Cost + 1, DiaCount = cost.DiaCount, IronCount = cost.IronCount, StoneCount = cost.StoneCount + 1 };
            };
            return cost;
        }
        private CostStruct[] ConvertMinerals(string[] minerals)
        {
            CostStruct[] cost = new CostStruct[(minerals.Length + 4) / 5];
            for (int i = 0; i < minerals.Length; i++)
            {
                cost[i / 5] = ConvertMineral(cost[i / 5], minerals[i]);
            }            

            return cost.OrderByDescending(x=>x.Cost).ToArray();
        }
        private int Calculate(int[] picks, CostStruct[] cost)
        {
            int result = 0;
            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                while (picks[i] > 0)
                {
                    if (i == 0)
                    {
                        // 다이아일 경우 광석 개수 만큼이 피로도
                        result += cost[index].DiaCount + cost[index].IronCount + cost[index].StoneCount;
                    }
                    else if (i == 1)
                    {
                        // 철일 경우 피로도
                        result += cost[index].DiaCount * 5 + cost[index].IronCount + cost[index].StoneCount;
                    }
                    else
                    {
                        // 돌일 경우 피로도
                        result += cost[index].DiaCount * 25 + cost[index].IronCount * 5 + cost[index].StoneCount;
                    }

                    index++;

                    if (index >= cost.Length)
                    {
                        return result;
                    }

                    picks[i]--;
                }
            }

            return result;

        }

    }
}
