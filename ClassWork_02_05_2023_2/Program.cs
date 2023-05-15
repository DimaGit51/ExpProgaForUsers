using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program
{
    public class DTreeNode // Класс «Узел дихотомического дерева»
    {
        private char info; // информационное поле
        private int key; // поле ключа
        private DTreeNode left; // ссылка на левое поддерево
        private DTreeNode right; // ссылка на правое поддерево
        public char Info
        {
            get { return info; }
            set { info = value; }
        } 
        public int Key
        {
            get { return key; }
            set { key = value; }
        }
        public DTreeNode Left
        {
            get { return left; }
            set { left = value; }
        }
        public DTreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
        public DTreeNode() { } // конструкторы
        public DTreeNode(char info, int key)
        {
            Info = info; Key = key;
        }
        public DTreeNode(char info, int key, DTreeNode left, DTreeNode right)
        {
            Info = info; Key = key; Left = left; Right = right;
        }
    }


    public class DichotomyTree // класс «Дихотомическое дерево»
    {
        private DTreeNode root; // ссылка на корень дихотомического дерева
        public DTreeNode Root // свойство, открывающее доступ к корню дерева
        {
            get { return root; }
            set { root = value; }
        }
        public DichotomyTree() // инициалиазция пустого дерева
        {
            root = null;
        }
        public DTreeNode FindDichotomyTree(DTreeNode root, int k)
        {
            DTreeNode p;

            if (root == null) p = null;
            else
            {
                if (k < root.Key) p = FindDichotomyTree(root.Left, k);
                else if (k > root.Key) p = FindDichotomyTree(root.Right, k);
                else p = root;
            }

            return p;
        }
        public DTreeNode Ins(DTreeNode root, int k)
        {
            char x;
            if (root == null)
            {
                Console.Write("Введите инф.полу ");
                x = Char.Parse(Console.ReadLine());
                root = new DTreeNode(x, k, null, null);
            }
            else
            {
                if (k < root.Key) root.Left = Ins(root.Left, k);
                else if (k > root.Key) root.Right = Ins(root.Right, k);
            }

            return root;
        }

    }
    public class Program
    {
        static void Main()
        {
            DichotomyTree T1 = new DichotomyTree();
            T1.Root = T1.Ins(T1.Root, 100);
            DTreeNode p = T1.FindDichotomyTree(T1.Root, 10);
            if (p == null) Console.WriteLine("Узел не найлен");

        }
    }
}