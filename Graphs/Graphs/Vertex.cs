using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Vertex<T>
    {
        //Vertex Properties
        public T Value;
        public bool Visited = false;

        //Vertex Functions
        public Vertex(T value)
        {
            this.Value = value;

        }

    }

    //B: Edge -> Vertex A, Vertex B
    public class Edge<T>
    {
        public Vertex<T> A;
        public Vertex<T> B;

        public Edge(Vertex<T> a, Vertex<T> b)
        {
            this.A = a;
            this.B = b;
        }

    }
    public class UndirectedGraph<T>
    {
        List<Vertex<T>> Vertex = new List<Vertex<T>>();
        public List<Edge<T>> Edge = new List<Edge<T>>();

        public void AddVertex(Vertex<T> V)
        {
            Vertex.Add(V);
        }
        public void RemoveVertex(Vertex<T> V)
        {
            Vertex.Remove(V);


        }
        public void AddEdge(Vertex<T> A, Vertex<T> B)
        {
            Edge.Add(new Edge<T>(A, B));

        }
        public void RemoveEdge(Vertex<T> A, Vertex<T> B)
        {

            Edge.Remove(new Edge<T>(A, B));
        }

        public IEnumerable<Vertex<T>> DepthFirst(Vertex<T> Start, Vertex<T> End)
        {
            Stack<Vertex<T>> Path = new Stack<Vertex<T>>();
            Path.Push(Start);
            while (Path.Count > 0)
            {
                Path.Peek().Visited = true;
                if (Path.Peek() == End)
                {
                    return Path.Reverse();
                }


                bool pushOccured = false;
                for (int i = 0; i < Edge.Count; i++)
                {
                    if (Edge[i].A == Path.Peek() && Edge[i].B.Visited == false)
                    {
                        pushOccured = true;
                        Path.Push(Edge[i].B);
                    }
                    else if (Edge[i].B == Path.Peek() && Edge[i].A.Visited == false)
                    {
                        pushOccured = true;
                        Path.Push(Edge[i].A);
                    }
                }

                if (!pushOccured)
                {
                    Path.Pop();
                }

                return Path;
            }

            return null;
            //set all verticies to visited*

            //Stack 
            //push start to the stack*

            //while the stack isn't empty*
            //  peek to get the current position in graph*
            //      mark vertex as visited
            //      if current item is END, then the stack is the path, return the stack (may reverse stack)*

            //  push first unvisited neighbor to the stack*
            //  if there are NO unvisted neighbors, pop

        }
    }



}
