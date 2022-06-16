using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoLibrary.알고리즘
{
    public class DFS<T>
    {
        //DataNode 클래스를 가지고 깊이 탐색 알고리즘
        List<DataNode<T>> nodeList;

        Stack<DataNode<T>> stackDFS;

        public DFS(List<DataNode<T>> _dataLIst)
        {
            //깊은 복사
            nodeList = _dataLIst.ToList();

            // 모든 노드 방문 초기화.
            nodeList.ForEach(node => node.marked = false);

            stackDFS = new Stack<DataNode<T>>();

            
        }

        private bool DFS_Push(DataNode<T> _item)
        {
            if (_item.marked) return false;
            _item.marked = true;
            stackDFS.Push(_item);
            return true;
        }

    }
}
