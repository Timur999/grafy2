using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lista1Zad2
{
    class Program
    {
        static Dictionary<int, int> graphDegree = new Dictionary<int, int>(); //Key = vertex, value
        static void Degree(Edge<int> e)
        {
            if(!graphDegree.ContainsKey(e.Source))
            {
                graphDegree.Add(e.Source, 1);
            }
            else
            {
                graphDegree[e.Source] = graphDegree[e.Source] + 1;
            }

            if(e.Source != e.Target)
            {
                if (!graphDegree.ContainsKey(e.Target))
                {
                    graphDegree.Add(e.Target, 1);
                }
                else
                {
                    graphDegree[e.Target] = graphDegree[e.Source] + 1;
                }
            }
   
        }

        static void Main(string[] args)
        {
            var graph = new AdjacencyGraph<int, Edge<int>>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);

            //Console.WriteLine(graph.VertexCount);
            //var v = graph.Vertices.First();
            //Console.WriteLine(v);

            var e12 = new Edge<int>(1, 2);
            var e23 = new Edge<int>(2, 3);
            var e34 = new Edge<int>(3, 4);
            var e14 = new Edge<int>(1, 4);
            var e24 = new Edge<int>(2, 4);


            //var graph = new AdjacencyGraph<int, Edge<int>>();
            graph.AddEdge(e12);
            graph.AddEdge(e23);
            graph.AddEdge(e34);
            graph.AddEdge(e14);
            graph.AddEdge(e24);

            Console.WriteLine("Rzad grafu G wynosi: " + graph.VertexCount);

            Console.WriteLine("Rozmiar grafu G wynosi: " + graph.EdgeCount);

            for (int i = 0; i < graph.EdgeCount; i++)
            {
                Degree(graph.Edges.ToList()[i]);
            }

            for(int i= 1; i <= graphDegree.Count; i++)
            {
                Console.WriteLine("deg(" + i + "): " + graphDegree[i]);
            }
            Console.Write("Ciag stopni grafu G:  ");
            foreach (int d in graphDegree.Select(x => x.Value).OrderBy(x => x))
            {
                Console.Write( d + ", ");
            }
        
            


            //Dictionary<Edge<int>, double> edgeCost = new Dictionary<Edge<int>, double>(graph.EdgeCount);

            //DijkstraShortestPathAlgorithm<int, Edge<int>> dijkstra = new DijkstraShortestPathAlgorithm<int, Edge<int>>(graph, AlgorithmExtensions.GetIndexer<Edge<int>, double>(edgeCost));

            //// Attach a Vertex Predecessor Recorder Observer to give us the paths
            //QuickGraph.Algorithms.Observers.VertexPredecessorRecorderObserver<int, Edge<int>> predecessorObserver = new QuickGraph.Algorithms.Observers.VertexPredecessorRecorderObserver<int, Edge<int>>();
            //predecessorObserver.Attach(dijkstra);

            //// attach a distance observer to give us the shortest path distances
            //VertexDistanceRecorderObserver<int, Edge<int>> distObserver = new VertexDistanceRecorderObserver<int, Edge<int>>(AlgorithmExtensions.GetIndexer<Edge<int>, double>(edgeCost));
            //distObserver.Attach(dijkstra);

            //// Run the algorithm with A set to be the source
            //dijkstra.Compute(1);
            //Console.WriteLine(graph.(3));

            //foreach (var edges in graph.Edges)
            //    Console.WriteLine(edges);
            //// graph.AddEdge();
            //foreach (var vertex in graph.Vertices)
            //    foreach (var edge in graph.OutEdges(vertex))
            //        Console.WriteLine(edge);
            Console.ReadKey();
        }
    }
}
