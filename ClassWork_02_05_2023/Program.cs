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
    public class TreeNode // Класс «Узел бинарного дерева»
    {
        private char info; // информационное поле
        private TreeNode left; // ссылка на левое поддерево
        private TreeNode right; // ссылка на правое поддерево
        public char Info
        {
            get { return info; }
            set { info = value; }
        }
        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }
        public TreeNode() { } // конструкторы
        public TreeNode(char info)
        {
            Info = info;
        }
        public TreeNode(char info, TreeNode left, TreeNode right)
        {
            Info = info; Left = left; Right = right;
        }
    }

    public class BinaryTree // Класс «Бинарное дерево произвольного вида»
    {
        private TreeNode root; // ссылка на корень дерева
        public TreeNode Root // свойство, открывающее доступ к корню дерева
        {
            get { return root; }
            set { root = value; }
        }
        public BinaryTree() // инициализация пустого дерева
        {
            root = null;
        }
        public void KLP(TreeNode root) // root – ссылка на корень дерева и любого из деревьев
        {
            if (root !=null ) // дерево не пусто?
            { 
                Console.WriteLine(root.Info );// распечатать информ. поле корневого узла
                KLP(root.Left ); // обойти левое поддерево в нисходящем порядке
                KLP(root.Right ); // обойти правое поддерево в нисходящем порядке
            }
        }
        public void LPK(TreeNode root) // root – ссылка на корень дерева и любого из деревьев
        {
            if (root != null) // дерево не пусто?
            { 
                KLP(root.Left); // обойти левое поддерево в нисходящем порядке
                KLP(root.Right); // обойти правое поддерево в нисходящем порядке
                Console.WriteLine(root.Info);// распечатать информ. поле корневого узла
            }
        }
        public void LKP(TreeNode root) // root – ссылка на корень дерева и любого из деревьев
        {
            if (root != null) // дерево не пусто?
            { 
                LKP(root.Left); // обойти левое поддерево в нисходящем порядке
                Console.WriteLine(root.Info);// распечатать информ. поле корневого узла
                LKP(root.Right); // обойти правое поддерево в нисходящем порядке
            }

        }


        public int Recursion(TreeNode root)
        {
            int count;
            if (root == null) count = 0;
            else count = 1 + Recursion(root.Left) + Recursion(root.Right);
            return count;
        }
        public TreeNode CreateRecursive(int n)
        {
            Char x; TreeNode root;
            if (n == 0) root = null;
            else
            {

                Console.Write("Введите элемент = ");
                while ((!Char.TryParse(Console.ReadLine(), out x)))
                {
                    Console.Write("Вы ввели не число ^int^! Введите число: ");
                }
                root = new TreeNode(x);
                root.Left = CreateRecursive(n/2);
                root.Right = CreateRecursive(n - n / 2 - 1);

            }
            return root;
        }
    }
    public class Program
    {
        static void Main()
        {
            BinaryTree T = new BinaryTree();
            T.Root = T.CreateRecursive(7);
            T.KLP(T.Root);
            T.LKP(T.Root);
            Console.WriteLine(T.Recursion(T.Root));
        }
    }
}