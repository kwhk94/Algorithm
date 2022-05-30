using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataNode<T>
    {
        // 노드가 가지고 있는 데이터
        private T data;
        // 노드와 연결되어 있는 다른 DataNode 객체 리스트
        public List<DataNode<T>> adjacentNode;
        // 해당 노드가 접근되었는지 확인하는 bool값
        public bool marked;

        #region ===== 캡슐화
        //data는 null 이 될 수 없게 선언  
        [System.Diagnostics.CodeAnalysis.MemberNotNull(nameof(data))]     
        public T setNodeData { set => data = value ?? throw new ArgumentException("data is required"); }
        public T getNodeData { get => data; }
        #endregion

        public DataNode(T data)
        {
            this.setNodeData = data;
            this.marked = false;
            this.adjacentNode = new List<DataNode<T>>();
        }
    }
}
