using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmMain.프로그래머스
{
    /*
     2차원 행렬 arr1과 arr2를 입력받아, arr1에 arr2를 곱한 결과를 반환하는 함수, solution을 완성해주세요.

    제한 조건
    행렬 arr1, arr2의 행과 열의 길이는 2 이상 100 이하입니다.
    행렬 arr1, arr2의 원소는 -10 이상 20 이하인 자연수입니다.
    곱할 수 있는 배열만 주어집니다. 
     */
    public class 행렬의곱
    {
        public static int[,] solution(int[,] arr1, int[,] arr2)
        {
            int row = arr1.Length / arr1.GetLength(1);//행
            int col = arr2.Length / (arr2.Length / arr2.GetLength(1));//열

            int[,] answer = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int m = 0;
                    while (m < arr2.GetLength(0))
                    {
                        answer[i, j] += arr1[i, m] * arr2[m, j];
                        m++;
                    }
                }
            }
            return answer;
        }
    }
}
