using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmMain
{
    public class DataNode<T>
    {
        // 노드가 가지고 있는 데이터
        private T data;
        // 노드와 연결되어 있는 다른 DataNode 객체 리스트
        public List<DataNode<T>> adjacentNode;
        // 해당 노드가 접근되었는지 확인하는 bool값
        public bool marked;

        public T setNodeData { set => data = value; }
        public T getNodeData { get => data; }


        public DataNode(T data)
        {
            this.setNodeData = data;
            this.marked = false;
            this.adjacentNode = new List<DataNode<T>>();
        }
    }
}
