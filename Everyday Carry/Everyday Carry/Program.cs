using System;

namespace EDCManagement
{
    
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    
    public class CustomLinkedList<T>
    {
        private Node<T> head;
        private int count;

        public CustomLinkedList()
        {
            head = null;
            count = 0;
        }

        
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        
        public void InsertAt(T data, int position)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException("Invalid position.");
            }

            Node<T> newNode = new Node<T>(data);
            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
        }

       
        public void Remove(T data)
        {
            if (head == null)
                return;

            if (head.Data.Equals(data))
            {
                head = head.Next;
                count--;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                count--;
            }
        }

        
        public Node<T> Find(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

       
        public int Count()
        {
            return count;
        }

        
        public void Reverse()
        {
            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }


        public void Clear()
        {
            head = null;
            count = 0;
        }

       
        public void Display()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    
    public class Gadget
    {
        public string Name { get; set; }
        public string DaysCarried { get; set; } 

        public Gadget(string name, string daysCarried)
        {
            Name = name;
            DaysCarried = daysCarried;
        }

        public override string ToString()
        {
            return $"{Name} (Carried: {DaysCarried})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<Gadget> edcList = new CustomLinkedList<Gadget>();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Gadget");
                Console.WriteLine("2. Remove Gadget");
                Console.WriteLine("3. Find Gadget");
                Console.WriteLine("4. Display All Gadgets");
                Console.WriteLine("5. Reverse Gadget List");
                Console.WriteLine("6. Clear Gadget List");
                Console.WriteLine("7. Insert Gadget at Position");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGadget(edcList);
                        break;
                    case 2:
                        RemoveGadget(edcList);
                        break;
                    case 3:
                        FindGadget(edcList);
                        break;
                    case 4:
                        Console.WriteLine("\nEDC Gadget List:");
                        edcList.Display();
                        break;
                    case 5:
                        edcList.Reverse();
                        Console.WriteLine("Gadget list reversed.");
                        break;
                    case 6:
                        edcList.Clear();
                        Console.WriteLine("Gadget list cleared.");
                        break;
                    case 7:
                        InsertGadgetAtPosition(edcList);
                        break;
                    case 8:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddGadget(CustomLinkedList<Gadget> list)
        {
            Console.Write("Enter gadget name: ");
            string name = Console.ReadLine();

            Console.Write("Enter days carried (e.g., Everyday, Weekdays, Gym Days): ");
            string daysCarried = Console.ReadLine();

            list.Add(new Gadget(name, daysCarried));
            Console.WriteLine("Gadget added successfully.");
        }

        static void RemoveGadget(CustomLinkedList<Gadget> list)
        {
            Console.Write("Enter gadget name to remove: ");
            string name = Console.ReadLine();

            Gadget gadgetToRemove = new Gadget(name, ""); 
            list.Remove(gadgetToRemove);
            Console.WriteLine("Gadget removed if it existed.");
        }

        static void FindGadget(CustomLinkedList<Gadget> list)
        {
            Console.Write("Enter gadget name to find: ");
            string name = Console.ReadLine();

            Gadget gadgetToFind = new Gadget(name, "");
            var foundGadget = list.Find(gadgetToFind);
            if (foundGadget != null)
            {
                Console.WriteLine($"Gadget found: {foundGadget.Data}");
            }
            else
            {
                Console.WriteLine("Gadget not found.");
            }
        }

        static void InsertGadgetAtPosition(CustomLinkedList<Gadget> list)
        {
            Console.Write("Enter gadget name: ");
            string name = Console.ReadLine();

            Console.Write("Enter days carried: ");
            string daysCarried = Console.ReadLine();

            Console.Write("Enter position to insert at: ");
            int position = int.Parse(Console.ReadLine());

            list.InsertAt(new Gadget(name, daysCarried), position);
            Console.WriteLine("Gadget inserted at the specified position.");
        }
    }
}
