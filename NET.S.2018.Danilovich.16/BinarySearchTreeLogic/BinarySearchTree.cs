using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLogic
{
    class BinarySearchTree<T>
    {
        #region Fields
        private TreeNode<T> node;
        private IComparer<T> comparer;
        private int size;
        #endregion

        #region Constructors
        public BinarySearchTree()
        {
            node = null;
            size = 0;
        }
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException($"{(nameof(comparer))} must not be a null");
        }
        #endregion
        #region Properties
        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{(nameof(size))} cant be a less than zero");
                }
            }
        }
        #endregion
        #region Methods
        public void AddNode(T node)
        {
            if(this.node != null)
            {
                if(comparer == null)
                {
                    /// to be continued
                }
            }
            else
            {
                this.node = new TreeNode<T>(node);
            }
        }
        
        #endregion

    }
}
