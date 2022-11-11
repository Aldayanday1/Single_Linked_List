using System;

    namespace singly_linked_list
{
    //each node consist of the information part and link to the next mode

    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class list
    {
        Node START;

        public List()
        {
            START = null;
 
        }
        public void addNote() //add a note in the list
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the Student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            //if the node to be inserted is the first node
            if (START != null || nim <= START.rollNumber)
            {
                if((START == null) && (nim == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;

                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //locate the position of the new node in the list
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber)) ;
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            /*once the above for loop is executed, prev and current are 
              positioned in such away that the position for the new node*/

            newnode.next = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empt.\n");
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)

                    Console.Write(currentNode.rollNumber + " " + currentNode.name + " \n");

                Console.WriteLine();
            }
        }
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check if the spesified node is present in the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (nim != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {

        //check wheter the specified node is present in the list or not

        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;

                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of" +
                                " the student whose record is to be deleted :");
                                int nim = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(nim) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with roll number "
                                        + nim + " Deleted");
                            }
                            break;

                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the roll number of the " + "student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false) 
                                Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + current.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered ");
                }
            }
        }
    }
}

