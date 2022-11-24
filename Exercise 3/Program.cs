﻿using System;
using System.Collections;
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
            public Node prev;
        }
        class CircularList
        {
            Node LAST;
            Node START;

            public CircularList()
            {
                LAST = null;
            }
            public void addNode()
            {
                int rollNo;
                string nm;
                Console.Write("\nEnter the roll number of the student: ");
                rollNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter the name of the student: ");
                nm = (Console.ReadLine());
                Node newnode = new Node();
                newnode.rollNumber = rollNo;
                newnode.name = nm;

                if (START == null || rollNo <= START.rollNumber)
                {
                    if ((START != null) && (rollNo == START.rollNumber))
                    {
                        Console.WriteLine("\nDuplicate roll numbers not allowed");
                        return;
                    }
                    newnode.next = START;
                    if (START != null)
                        START.prev = newnode;
                    newnode.prev = null;
                    START = newnode;
                    return;
                }

                Node previous, current;
                for (current = previous = START; current != null &&
                    rollNo >= current.rollNumber; previous = current, current =
                    current.next)
                {
                    if (rollNo == current.rollNumber)
                    {
                        Console.WriteLine("\nDuplicate roll numbers not allowed");
                        return;
                    }
                }

                newnode.next = current;
                newnode.prev = previous;

                if (current == null)
                {
                    newnode.next = null;
                    previous.next = newnode;
                    return;
                }
                current.prev = newnode;
                previous.next = newnode;
            }

            public bool Search(int rollNO, ref Node previous, ref Node current)
            {
                for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
                {
                    if (rollNO == current.rollNumber)
                        return (true);
                }
                if (rollNO == LAST.rollNumber)
                    return true;
                else
                    return (false);
            }
            public bool delNode(int rollNo)
            {
                Node previous, current;
                previous = current = null;
                if (Search(rollNo, ref previous, ref current) == false)
                    return false;
                if (current == START)
                {
                    START = START.next;
                    if (START != null)
                        START.prev = null;
                    return true;
                }
                if (current.next == null)
                {
                    previous.next = null;
                    return true;
                }

                previous.next = current.next;
                current.next.prev = previous;
                return true;
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
            public void revtraverse()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is Empty");
                else
                {
                    Console.WriteLine("\nRecords in the descending order of " +
                        "roll numbers are : \n");
                    Node currentNode;
                    for (currentNode = START; currentNode.next != null;
                        currentNode = currentNode.next) { }
                    while (currentNode != null)
                    {
                        Console.Write(currentNode.rollNumber + " " +
                            currentNode.name + "\n");
                        currentNode = currentNode.prev;
                    }

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
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Console.Write("\nEnter the rollnumber of the student" +
                                        "Whose record is to be deleted:");
                                    int rollNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(rollNo) == false)
                                        Console.WriteLine("Record not found");
                                    else
                                        Console.WriteLine("Record with roll number" + rollNo + "deleted \n");

                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    obj.revtraverse();
                                }
                                break;
                            case '5':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\n List is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\n Enter the roll number of the student whose record you want to search: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                        Console.WriteLine("\nRoll Name: " + curr.name);
                                    }
                                }
                                break;
                            case '6':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nInvalid option");
                                }
                                break;
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
