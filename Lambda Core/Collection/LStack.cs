using System;
using System.Collections.Generic;
using System.Linq;
using LambdaCore_Skeleton.Contracts;

namespace LambdaCore_Skeleton.Collection
{
   public class LStack
    {
        private LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int TotalPressureAffection
        {
            get => this.innerList.Select(p => p.PressureAffection).Sum();
        }

        public int TotalPressureOnCore
        {
            get => this.innerList.Select(p => p.PressureOnCore).Sum();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public IFragment Push(IFragment item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public IFragment Peek()
        {
            IFragment peekedItem = this.innerList.Last();
            return peekedItem;
        }

        public Boolean IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
