using System;
using System.IO;
using System.Linq;

// Java program to demonstrate 
// insert operation in binary 
// search tree 
internal class BinarySearchTree
{

	/* Class containing left 
	and right child of current node 
	* and key value*/
	internal class Node
	{
		private readonly BinarySearchTree outerInstance;

		internal int key;
		internal Node left, right;

		public Node(BinarySearchTree outerInstance, int item)
		{
			this.outerInstance = outerInstance;
			key = item;
			left = right = null;
		}
	}

	// Root of BST 
	internal Node root;

	// Constructor 
	internal BinarySearchTree()
	{
		root = null;
	}

	// This method mainly calls insertRec() 
	internal virtual void insert(int key)
	{
		root = insertRec(root, key);
	}

	/* A recursive function to 
	insert a new key in BST */
	internal virtual Node insertRec(Node root, int key)
	{

		/* If the tree is empty, 
		return a new node */
		if (root == null)
		{
			root = new Node(this, key);
			return root;
		}

		/* Otherwise, recur down the tree */
		if (key < root.key)
		{
			root.left = insertRec(root.left, key);
		}
		else if (key > root.key)
		{
			root.right = insertRec(root.right, key);
		}

		/* return the (unchanged) node pointer */
		return root;
	}

	// This method mainly calls InorderRec() 
	internal virtual void inorder()
	{
		inorderRec(root);
	}

	// A utility function to 
	// do inorder traversal of BST 
	internal virtual void inorderRec(Node root)
	{
		if (root != null)
		{
			inorderRec(root.left);
			Console.WriteLine(root.key);
			inorderRec(root.right);
		}
	}
	// A utility function to search 
	// a given key in BST 
	public Node search(Node root,
					int key)
	{
		// Base Cases: root is null 
		// or key is present at root 
		if (root == null ||
			root.key == key)
		{
            Console.WriteLine("1");
			return root;
		}

		// Key is greater than root's key 
		if (root.key < key)
		{
			Console.WriteLine("2");
			return search(root.right, key);
			
		}

		// Key is smaller than root's key 
		if (root.key > key)
		{
			Console.WriteLine("3");
			return search(root.right, key);

		}
		return search(root.right, key);
	}

	// This code is contributed by gauravrajput1

	// Driver Code 
	public static void Main(string[] args)
	{
		BinarySearchTree tree = new BinarySearchTree();

		/* Let us create following BST 
			50 
		/	 \ 
		30	 70 
		/ \ / \ 
	20 40 60 80 */
		string Path = @"BST15.txt";
		int[] array = { 0 };

		array = File.ReadAllText(Path).Split().Select(int.Parse).ToArray();


		
		
		for (int i = 0; i < array.Length; i++)
		{
			tree.insert(array[i]);

		}
		
		tree.search(null, 0);

		// print inorder traversal of the BST 
		//tree.inorder();
	}
}
// This code is contributed by Ankur Narain Verma
