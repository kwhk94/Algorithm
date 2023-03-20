using monoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmMain
{
    public class DFS_Test
    {
        List<DataNode<int>> nodeList;

        public DFS_Test()
        {
            nodeList = new List<DataNode<int>>();

            nodeList.Add(new DataNode<int>(0));
            nodeList.Add(new DataNode<int>(1));
            nodeList.Add(new DataNode<int>(2));
            nodeList.Add(new DataNode<int>(3));
            nodeList.Add(new DataNode<int>(4));
            nodeList.Add(new DataNode<int>(5));
            nodeList.Add(new DataNode<int>(6));
            nodeList.Add(new DataNode<int>(7));

            //                         0
            //                      1      3
            //                   2   5     7
            //                4   6

            nodeList[0].ConnectNode(nodeList[1]);
            nodeList[0].ConnectNode(nodeList[3]);
            nodeList[1].ConnectNode(nodeList[2]);
            nodeList[1].ConnectNode(nodeList[5]);
            nodeList[2].ConnectNode(nodeList[4]);
            nodeList[2].ConnectNode(nodeList[6]);
            nodeList[3].ConnectNode(nodeList[7]);

            //중복 값 넣어보기
            nodeList[4].ConnectNode(nodeList[2]);
            nodeList[2].ConnectNode(nodeList[1]);

        }

        public void ShowAllNode()
        {
            DFS<int> objectBFS = new DFS<int>(nodeList);
            Console.WriteLine("========== 시작노드부터 마지막 노드까지 수직 순서로 Draw =====");
            objectBFS.SimpleDFS_showAllNode(0);
        }

        public void SearchNode(int _startIndex, int _targetIndex)
        {
            if (_startIndex > nodeList.Count)
            {
                Console.WriteLine("시작 인덱스가 너무 큽니다.");
                return;
            }

            if (_targetIndex > nodeList.Count)
            {
                Console.WriteLine("찾으려는 인덱스가 너무 큽니다.");
                return;
            }


            DFS<int> objectBFS = new DFS<int>(nodeList);
            Console.WriteLine("========== 시작노드부터 찾으려는 대상 노드까지 수직 순서로 Draw =====");
            objectBFS.DFS_PathSearch(_startIndex, _targetIndex);
        }
    }
}
