using System;
using Unit4.CollectionsLib;

namespace עבודה_2_תורים
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = FillQueue();
            Console.WriteLine();
            Console.WriteLine();
            PrintQueue(NoRepeat(q));
            Console.WriteLine();
            Console.WriteLine();
            PrintQueue(q);
        }

        public static Node<int> FillNode()
        {
            Node<int> list = new Node<int>(0);
            Node<int> a = list;
            int num = int.Parse(Console.ReadLine());

            while(num != -999)
            {
                a.SetNext(new Node<int>(num));
                a = a.GetNext();
                num = int.Parse(Console.ReadLine());
            }

            return list.GetNext();
        }
        public static Queue<int> FillQueue()
        {
            Queue<int> q = new Queue<int>();
            int num = int.Parse(Console.ReadLine());

            while(num != -999)
            {
                q.Insert(num);
                num = int.Parse(Console.ReadLine());
            }

            return q;
        }


        public static void PrintNode(Node<int> list)
        {
            Node<int> a = list;
            while (a != null)
            {
                Console.WriteLine(a.GetValue());
                a = a.GetNext();
            }
        }
        public static void PrintQueue(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                Console.WriteLine(q.Head());
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }




        public static Node<int> CopyMember(Queue<int> q, int k)
        {
            Node<int> list = new Node<int>(0);
            Node<int> a = list;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (k > 0)
                {
                    a.SetNext(new Node<int>(q.Head()));
                    a = a.GetNext();
                    k--;
                }
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return list.GetNext();
        }


        public static Queue<char> Cars(Queue<char> q)
        {
            Queue<char> temp1 = new Queue<char>();
            Queue<char> temp2 = new Queue<char>();
            int counter = 0;

            while (!q.IsEmpty())
            {
                if (q.Head() == 'V') counter++;
                temp1.Insert(q.Remove());
            }

            for (int i = 0; i < counter; i++)
            {
                temp2.Insert('V');
            }

            while (!temp1.IsEmpty())
            {
                q.Insert(temp1.Head());
                if (temp1.Head() == 'V')
                    temp1.Remove();
                else
                    temp2.Insert(temp1.Remove());
            }

            return temp2;
        }


        public static Queue<int> Merger(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> q = new Queue<int>();
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();

            while(!q1.IsEmpty() && !q2.IsEmpty())
            {
                if(q1.Head() < q2.Head())
                {
                    q.Insert(q1.Head());
                    temp1.Insert(q1.Remove());
                }
                else
                {
                    q.Insert(q2.Head());
                    temp2.Insert(q2.Remove());
                }
            }

            while (!q1.IsEmpty())
            {
                q.Insert(q1.Head());
                temp1.Insert(q1.Remove());
            }
            while (!q2.IsEmpty())
            {
                q.Insert(q2.Head());
                temp2.Insert(q2.Remove());
            }


            while (!temp1.IsEmpty())
            {
                q1.Insert(temp1.Remove());
            }
            while (!temp2.IsEmpty())
            {
                q2.Insert(temp2.Remove());
            }

            return q;
        }


        public static Queue<int> Diffrence(Queue<int> q)
        {
            Queue<int> diffs = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            int num;

            while (!q.IsEmpty())
            {
                num = q.Head();
                temp.Insert(q.Remove());
                diffs.Insert(num - q.Head());
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return diffs;
        }


        public static Queue<int> NoRepeat(Queue<int> q)
        {
            Queue<int> qq = new Queue<int>();
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            bool found = false;

            while (!q.IsEmpty())
            {
                while (!qq.IsEmpty())
                {
                    if (q.Head() == qq.Head()) found = true;
                    temp2.Insert(qq.Remove());
                }
                while (!temp2.IsEmpty())
                {
                    qq.Insert(temp2.Remove());
                }
                if (!found) qq.Insert(q.Head());
                found = false;

                temp1.Insert(q.Remove());
            }

            while (!temp1.IsEmpty())
            {
                q.Insert(temp1.Remove());
            }

            return qq;
        }
    }
}
