using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dewey_Decimal_System_POE_Task1
{
    //This function Materializes Level 1 of the quiz game using data loaded into memory in conjunction with The tree data structure Game
    // This class was Adapted from StackOverflow
    //https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp
    //moien
    //https://stackoverflow.com/users/5592276/moien

    public class Binary_Tree : IEnumerable<Binary_Tree>
    {
        private readonly Dictionary<string, Binary_Tree> _children = new Dictionary<string, Binary_Tree>();


        public readonly string ID;
        public Binary_Tree Parent { get; private set; }

        public Binary_Tree(string id)
        {
            this.ID = id;
        }

        public Binary_Tree GetChild(string id)
        {
            return this._children[id];
        }

        public void Add(Binary_Tree item)
        {
            if (item.Parent != null)
            {
                item.Parent._children.Remove(item.ID);
            }

            item.Parent = this;
            this._children.Add(item.ID, item);
        }

        public IEnumerator<Binary_Tree> GetEnumerator()
        {
            return this._children.Values.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)Parent).GetEnumerator();
        }

        //IEnumerator<Binary_Tree> IEnumerable<Binary_Tree>.GetEnumerator()
        //{
        //    return ((IEnumerable<Binary_Tree>)Parent).GetEnumerator();
        //}

        public int Count
        {
            get { return this._children.Count; }
        }



    }
}
