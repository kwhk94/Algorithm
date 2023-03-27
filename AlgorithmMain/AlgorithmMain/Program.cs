// See https://aka.ms/new-console-template for more information


using AlgorithmMain;
using AlgorithmMain.알고리즘테스트;

#region ===== BFS_Test ======
//BFS_Test bFS_Test = new BFS_Test();

//bFS_Test.ShowAllNode();

//bFS_Test.SearchNode(0, 7);
#endregion

#region ===== DFS_Test ======
//DFS_Test mDFS_Test = new DFS_Test();

//mDFS_Test.ShowAllNode();

//mDFS_Test.SearchNode(0, 4);
#endregion

#region ===== 광물캐기

광물캐기 test = new 광물캐기();
var t = test.solution(new int[3] { 1, 3, 2 }, new string[] { "diamond", "diamond", "diamond", "iron", "iron", "diamond", "iron", "stone" });
Console.WriteLine(t);

t = test.solution(new int[3] { 0,1,1 }, new string[] { "diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond" });
Console.WriteLine(t);

#endregion