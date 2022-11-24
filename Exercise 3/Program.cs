﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    internal class Program
    {
        class Node
        {
            public int rollNumber;
            public string name;
            public Node next;
        }
        class CircularList
        {
            Node LAST;

            public CircularList()
            {
                LAST = null;
            }

            public bool Search(int rollNO, ref Node previous, ref Node current)
            {
                for(previous = current = LAST.next; current != LAST; previous = current, current = current.next)
                {
                    if(rollNO == current.rollNumber)
                        return (true);
                }
                if (rollNO == LAST.rollNumber)
                    return true;
                else
                    return (false);
            }
            public bool listEmpty()
            {
                if (LAST == null)
                    return true;
                else
                    return false;
            }

            public void traverse()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                {
                    Console.WriteLine("\nRecords in the list are:\n");
                    Node currentNode;
                    currentNode = LAST.next;
                    while (currentNode != LAST)
                    {
                        Console.Write(currentNode.rollNumber +"   "+ currentNode.name + "\n");
                        currentNode = currentNode.next;
                    }
                    Console.Write(LAST.rollNumber + "     "+ LAST.name + "\n");
                }
            }
            public void firstNode()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                    Console.WriteLine("\nThe first record in the list is:\n\n " + LAST.next.rollNumber + "   " + LAST.next.name);
            }
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\n Menu" +
                            "\n 1. Add a record to the list" +
                            "\n 2. Delete a record from the list" +
                            "\n 3. View all records in the ascending order of roll numbers" +
                            "\n 4. View all records in the descending order of roll numbers" +
                            "\n 5. Search for a record in the list" +
                            "\n 6. Exit \n" +
                            "\n Enter your choice (1 - 6):");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nEnter the rollnumber of the student Whose record is to be searched: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("Record not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                        Console.WriteLine("\nName: " + curr.name);
                                    }
                                }
                                break;
                            case '3':
                                {
                                    obj.firstNode();
                                }
                                break;
                            case '4':
                                return;
                            default:
                                {
                                   Console.WriteLine("Invalid option");
                                   break;
                                }
                                
                            
                                
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

            }

        }       
    }
}
