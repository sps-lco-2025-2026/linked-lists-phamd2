namespace LinkedListIntroduction.Lib;


public class IntegerLinkedList
{
    public IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }


    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }


    public IntegerLinkedList(IList<int> ls) : this()
    {
        foreach(int i in ls)
            Append(i);          
    }


    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;


    public virtual void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);


    }
    public void Prepend(int v)
    {
        IntegerNode? newNode = new IntegerNode(v);
        newNode.UpdatePointer(_head);
        _head = newNode;
    }


    public bool Delete(int doomed)
    {
        if (_head != null)
        {
            if(_head.Value == doomed){
                _head = _head.Next;
                return true;
            }
            return _head.Delete(doomed);
        } return false;
    }


    public bool Insert(int value, int position)
    {
        if(position == 0)
        {
            Prepend(value);
            return true;
        }
        if (_head == null || _head.Next == null)
            return false;
        else
        {
            _head.Next.Insert(value, position - 1);
            return true;
        }
    }


    public void Join(IntegerLinkedList? addition)
    {
        if (addition == null)
            return;
        else
        {
            if (_head == null)
                _head = addition._head;
            else
                _head.Join(addition._head);
        }
    }


    public bool Contains(int value)
    {
        if(_head == null)
            return false;
        return _head.Contains(value);
    }


    public void RemoveDuplicates()
    {
        _head?.RemoveDuplicates();
    }


    public void MergeAlternate(IntegerLinkedList addition)
    {
        if(_head == null || addition == null || addition._head == null)
            return;
        _head.MergeAlternate(addition._head);
    }


    public IntegerLinkedList Reverse()
    {
        IntegerLinkedList result = new IntegerLinkedList();
        _head?.Reverse(result);
        return result;
    }


    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}


public class IntegerNode
{
    int _value;
    IntegerNode _next;


    internal int Value => _value;
    internal IntegerNode? Next => _next;
    internal int Count => _next == null ? 1 : 1 + _next.Count;
           
    internal int Sum => _next == null ? _value : _value + _next.Sum;




    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }
    internal IntegerNode(int v, IntegerNode? ptr)
    {
        _value = v;
        _next = ptr;
    }


    internal void UpdatePointer(IntegerNode? ptr)
    {
        _next = ptr;
    }


    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }


    internal bool Delete(int doomed)
    {
        if (_next == null) return false;
        if(_next._value == doomed){
            _next = _next.Next;
            return true;
        }
        else
        {
            return _next.Delete(doomed);
        }
    }


    internal bool Insert(int value, int position)
    {
        if(position == 0)
        {
            _next = new IntegerNode(value,_next);
            return true;
        }
        if (_next == null)
            return false;
        else
        {
            return _next.Insert(value, position - 1);
        }
    }


    internal void Join(IntegerNode addition)
    {
        if(_next == null)
            _next = addition;
        else  
            _next.Join(addition);
    }


    internal bool Contains(int value)
    {
        if(_value == value)
            return true;
        if(_next == null)
            return false;
        return _next.Contains(value);
    }


    internal void RemoveDuplicates()
    {
        if(_next==null)
            return;
        if (_next.Value == _value)
        {
            _next = _next.Next;
            RemoveDuplicates();
        }
        else
        {
            _next.RemoveDuplicates();
        }
    }


    internal void MergeAlternate(IntegerNode addition)
    {
        if(addition == null)
            return;


        IntegerNode? next1 = _next;
        IntegerNode? next2 = addition.Next;


        _next = addition;
        addition.UpdatePointer(next1);


        if (next1 != null && next2 != null)
            next1.MergeAlternate(next2);
    }


    internal void Reverse(IntegerLinkedList list)
    {
        list.Prepend(_value);


        if (_next != null)
            _next.Reverse(list);
    }


    internal void InsertSorted(int value)
    {
        if(_next == null || value < _next.Value)
        {
            _next = new IntegerNode(value, _next);
        }
        else
        {
            _next.InsertSorted(value);
        }
    }


    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }


}
