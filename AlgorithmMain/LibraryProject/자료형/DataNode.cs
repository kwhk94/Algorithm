using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoLibrary
{
    public class DataNode<T>
    {
        // 노드가 가지고 있는 데이터
        private T data;
        // 노드와 연결되어 있는 다른 DataNode 객체 리스트
        public List<DataNode<T>> adjacentNode;
        // 해당 노드가 접근되었는지 확인하는 bool값
        public bool marked;
        // 부모 노드
        private DataNode<T> parentNode;

        #region ===== 캡슐화
        //data는 null 이 될 수 없게 선언  
        [System.Diagnostics.CodeAnalysis.MemberNotNull(nameof(data))]     
        public T setNodeData { set => data = value ?? throw new ArgumentException("data is required"); }
        public T getNodeData { get => data; }
        public DataNode<T> setParentNode { set => parentNode = value; }
        public DataNode<T> getParentNode { get => parentNode; }
        #endregion

        public DataNode(T data)
        {
            this.setNodeData = data;
            this.marked = false;
            this.adjacentNode = new List<DataNode<T>>();
        }

        public void ConnectNode(DataNode<T> _targetNode)
        {
            bool _isValue = false;
            // 중복체크
            for (int i = 0; i < adjacentNode.Count; i++)
            {
                if(adjacentNode[i] == _targetNode)
                {
                    _isValue = true; 
                    break;
                }
            }

            // 중복 없으면 추가
            if ( _isValue == false)
            {
                adjacentNode.Add(_targetNode);
                _targetNode.adjacentNode.Add(this);
            }
        }
    }
}
