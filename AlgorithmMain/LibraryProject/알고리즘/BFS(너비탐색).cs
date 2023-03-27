using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoLibrary
{
    public class BFS<T>
    {
        //DataNode 클래스를 가지고 너비탐색 알고리즘
        List<DataNode<T>> nodeList;

        Queue<DataNode<T>> queueBFS;

        public BFS( List<DataNode<T>> _dataLIst)
        {
            //깊은 복사
            nodeList = _dataLIst.ToList();

            // 모든 노드 방문 초기화.
            nodeList.ForEach(node => node.marked = false);

            queueBFS = new Queue<DataNode<T>>();

        }
        private bool BFS_Enqueue(DataNode<T> _item)
        {
            if (_item.marked == true) return false;

            _item.marked = true;            
            queueBFS.Enqueue(_item);
            return true;

        }


        public void SimpleBFS_showAllNode(int _startIndex)
        {
            // 스타트 노드 넣기
            BFS_Enqueue(nodeList[_startIndex]);

            // 큐가 비어질 때 까지 확인
            while (queueBFS.Count > 0)
            {
                var _currentNode = queueBFS.Dequeue();

                Console.WriteLine(_currentNode.getNodeData.ToString());

                // 인접 노드의 수를 미리 계산하고 for문에 넣어준다.
                int _adjacenteNodeCount = _currentNode.adjacentNode.Count;

                for (int i = 0; i < _adjacenteNodeCount; i++)
                {
                    BFS_Enqueue(_currentNode.adjacentNode[i]);
                }
            }
        }

        public void BFS_PathSearch(int _startIndex, int _targetIndex)
        {
            Console.WriteLine("start Node: " + nodeList[_startIndex].getNodeData.ToString());
            Console.WriteLine("target Node: " + nodeList[_targetIndex].getNodeData.ToString());

            // 스타트 노드 넣기
            BFS_Enqueue(nodeList[_startIndex]);

            bool _bSearch = false;
            // 큐가 비어질 때 까지 확인
            while (queueBFS.Count > 0 && _bSearch == false)
            {
                var _currentNode = queueBFS.Dequeue();

                // 인접 노드의 수를 미리 계산하고 for문에 넣어준다.
                int _adjacenteNodeCount = _currentNode.adjacentNode.Count;

                for (int i = 0; i < _adjacenteNodeCount; i++)
                {

                    if (BFS_Enqueue(_currentNode.adjacentNode[i]))
                    {
                        // 부모 노드 등록
                        _currentNode.adjacentNode[i].setParentNode = _currentNode;
                    }
                    if(_currentNode.adjacentNode[i] == nodeList[_targetIndex])
                    {
                        _bSearch = true;
                        break;
                    }
                }            
            }

            var _node = nodeList[_targetIndex];
            int _Length = 0;

            while (_node.getParentNode != null)
            {
                Console.WriteLine(_node.getNodeData.ToString());
                _node = _node.getParentNode;
                _Length++;
            }
            Console.WriteLine(nodeList[_startIndex].getNodeData.ToString()); // 시작 노드 출력

            Console.WriteLine("시작과 끝 거리: " + _Length);


        }

    }
}
