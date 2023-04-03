// See https://aka.ms/new-console-template for more information


using AlgorithmMain;
using AlgorithmMain.알고리즘테스트;
using AlgorithmMain.프로그래머스;

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
/*
광물캐기 test = new 광물캐기();
var t = test.solution(new int{3} { 1, 3, 2 }, new string{} { "diamond", "diamond", "diamond", "iron", "iron", "diamond", "iron", "stone" });
Console.WriteLine(t);

t = test.solution(new int{3} { 0,1,1 }, new string{} { "diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond" });
Console.WriteLine(t);

t = test.solution(new int{3} { 1,1,0 }, new string{} { "diamond", "diamond", "diamond", "iron", "iron", "diamond", "iron", "stone", "iron", "iron", "diamond", "diamond" });
Console.WriteLine(t);
*/
#endregion

#region ===== 과제진행하기
string[,] vs = new string[,] 
{
    //{"korean", "11:40", "30"}, {"english", "12:10", "20"}, {"math", "12:30", "40"}

    {"science", "12:40", "50"}, {"music", "12:20", "40"}, {"history", "14:00", "30"}, {"computer", "12:30", "30"}

};
string[] result= 과제진행하기.solution(vs);
Console.WriteLine(String.Join("  ", result));

#endregion