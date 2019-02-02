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
        public Vertex<T> Founder = null;
        public int Distance;

        //Vertex Functions
        public Vertex(T value)
        {
            this.Value = value;
        }

    }

    //B: Edge -> Vertex A, Vertex B
    public class Edge<T>
    {
        public int Weight;
        public Vertex<T> A;
        public Vertex<T> B;

        public Edge(Vertex<T> a, Vertex<T> b)
        {

            this.A = a;
            this.B = b;

        }

    }
    public class DirectedGraph<T>
    {
        List<Vertex<T>> Vertex = new List<Vertex<T>>();
        public List<Edge<T>> Edge = new List<Edge<T>>();
        public void AddVertex(Vertex<T> V)
        {
            Vertex.Add(V);
        }
        public bool RemoveVertex(Vertex<T> V)
        {
            Vertex.Remove(V);


        }
        public void AddEdge(Vertex<T> A, Vertex<T> B)
        {
            Edge.Add(new Edge<T>(A, B));
        }
        public bool RemoveEdge(Vertex<T> A, Vertex<T> B)
        {
            Edge.Remove(new Edge<T>(A, B));
        }
        public Vertex<T> search(T value)
        {
            for (int i = 0; i < Vertex.Count; i++)
            {
                if (Vertex[i].Value.Equals(value))
                {
                    return Vertex[i];

                }

            }

            return null;
        }
        public Edge<T> search(Vertex<T> A,Vertex<T> B)
        {


        }
        //add a Vertex<T> search(T value) returns null if the item does not exist
        //return the vertex if the item exists

        public IEnumerable<Vertex<T>> Dijkstra(Vertex<T> Start, Vertex<T> End)
        {
            List<Vertex<T>> Priority = new List<Vertex<T>>();
            for (int i = 0; i < Vertex.Count; i++)
            {
                Vertex[i].Visited = false;
            }
            Start.Distance = 0;
            Priority.Add(Start);
            while (Priority.Count > 0)
            {
                Vertex<T> curr = null;
                int min = int.MaxValue;
                foreach (var vert in Priority)
                {
                    if (vert.Distance < min)
                    {
                        min = vert.Distance;
                        curr = vert;
                    }
                }

                Priority.Remove(curr);

                foreach (var edge in Edge)
                {
                    Vertex<T> neighbor = null;
                    if (edge.A == curr)
                    {
                        neighbor = edge.B;
                        int tempdist = curr.Distance + neighbor.Distance;
                        if (tempdist < neighbor.Distance)
                        {
                            neighbor.Distance = tempdist;
                            neighbor.Founder = curr;
                        }
                    }
                    else if (edge.B == curr)
                    {
                        neighbor = edge.A;
                        int tempdist = curr.Distance + neighbor.Distance;
                        if (tempdist < neighbor.Distance)
                        {
                            neighbor.Distance = tempdist;
                            neighbor.Founder = curr;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (!neighbor.Visited && !Priority.Contains(neighbor))
                    {
                        Priority.Add(neighbor);
                    }



                    //calculate temp distance curr.Distance + edgeWeight
                    //if tempDist < neigh.Dist
                    //  update the neighbor


                }
            }


            Stack<Vertex<T>> Temp = new Stack<Vertex<T>>();
            Temp.Push(End);
            while (Temp.Peek() != Start)
            {
                Temp.Push(Temp.Peek().Founder);
            }


            //var cur = End;
            //while (curr != Start)
            //{
            //    cur = cur.Founder;
            //}
            //start at end, loop through founders to generate path

            return Temp;
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
                Vertex<T> curr = Path.Peek();
                curr.Visited = true;
                if (curr == End)
                {
                    return Path.Reverse();
                }


                bool pushOccured = false;
                for (int i = 0; i < Edge.Count; i++)
                {
                    if (Edge[i].A == curr && Edge[i].B.Visited == false)
                    {
                        pushOccured = true;
                        Path.Push(Edge[i].B);
                    }
                    else if (Edge[i].B == curr && Edge[i].A.Visited == false)
                    {
                        pushOccured = true;
                        Path.Push(Edge[i].A);
                    }
                }

                if (!pushOccured)
                {
                    Path.Pop();
                }
            }

            return null;
            //set all verticies to unvisited

            //Stack 
            //push start to the stack*

            //while the stack isn't empty*
            //  peek to get the current position in graph*
            //      mark vertex as visited
            //      if current item is END, then the stack is the path, return the stack (may reverse stack)*

            //  push first unvisited neighbor to the stack*
            //  if there are NO unvisted neighbors, pop

        }
        public IEnumerable<Vertex<T>> BreadthFirstSearch(Vertex<T> Start, Vertex<T> End)
        {
            Queue<Vertex<T>> Searching;
            Searching = new Queue<Vertex<T>>();
            for (int i = 0; i < Vertex.Count; i++)
            {
                Vertex[i].Visited = false;

            }
            Searching.Enqueue(Start);
            while (Searching.Count > 0)
            {
                var cur = Searching.Dequeue();
                cur.Visited = true;
                for (int i = 0; i < Edge.Count; i++)
                {
                    if (Edge[i].A == cur && Edge[i].B.Visited == false && Searching.Contains(Edge[i].B) == false)
                    {

                        Searching.Enqueue(Edge[i].B);
                        Edge[i].B.Founder = cur;

                    }
                    else if (Edge[i].B == cur && Edge[i].A.Visited == false && Searching.Contains(Edge[i].A) == false)
                    {

                        Searching.Enqueue(Edge[i].A);
                        Edge[i].A.Founder = cur;
                    }
                }
            }

            Stack<Vertex<T>> temp = new Stack<Vertex<T>>();
            temp.Push(End);
            while (temp.Peek() != Start)
            {
                temp.Push(temp.Peek().Founder);
            }

            return temp.Reverse();


            //&& - for each while loop wont they technically never end because it will always be greater than 0 (also ask how we are going to know if it didnt wwork at all for the bfs)


            //BreadthFirstSearch*
            //queue*
            //set all verticies to univisted*
            //enqueue the start*
            //while queue is not emtpy*
            //  dequeue to get the current node [ var cur = queue.Dequeue() ]*
            //  set the current node to VISITED*
            //  go through all neighbors*
            //      if the neighbor is unvisited AND NOT in the queue, add them to the queue AND set their founder to the curr node*
            //create an enumerable, start at the end and keep adding the founders until start is added*
            //return the reverse of the created enumerable*




        }
        public IEnumerable<Vertex<T>> Dijkstra(Vertex<T> Start, Vertex<T> End)
        {
            List<Vertex<T>> Priority = new List<Vertex<T>>();
            for (int i = 0; i < Vertex.Count; i++)
            {
                Vertex[i].Visited = false;
            }
            Start.Distance = 0;
            Priority.Add(Start);
            while (Priority.Count > 0)
            {
                Vertex<T> curr = null;
                int min = int.MaxValue;
                foreach (var vert in Priority)
                {
                    if (vert.Distance < min)
                    {
                        min = vert.Distance;
                        curr = vert;
                    }
                }

                Priority.Remove(curr);

                foreach (var edge in Edge)
                {
                    Vertex<T> neighbor = null;
                    if (edge.A == curr)
                    {
                        neighbor = edge.B;
                        int tempdist = curr.Distance + neighbor.Distance;
                        if (tempdist < neighbor.Distance)
                        {
                            neighbor.Distance = tempdist;
                            neighbor.Founder = curr;
                        }
                    }
                    else if (edge.B == curr)
                    {
                        neighbor = edge.A;
                        int tempdist = curr.Distance + neighbor.Distance;
                        if (tempdist < neighbor.Distance)
                        {
                            neighbor.Distance = tempdist;
                            neighbor.Founder = curr;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    if (!neighbor.Visited && !Priority.Contains(neighbor))
                    {
                        Priority.Add(neighbor);
                    }



                    //calculate temp distance curr.Distance + edgeWeight
                    //if tempDist < neigh.Dist
                    //  update the neighbor


                }
            }


            Stack<Vertex<T>> Temp = new Stack<Vertex<T>>();
            Temp.Push(End);
            while (Temp.Peek() != Start)
            {
                Temp.Push(Temp.Peek().Founder);
            }


            //var cur = End;
            //while (curr != Start)
            //{
            //    cur = cur.Founder;
            //}
            //start at end, loop through founders to generate path

            return Temp;
        }
    }
}