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
    public void Prepend(int value)
    {
        IntegerNode node = new IntegerNode(value);

        if (_head != null)
        {
            node.Next = _head;
        }
        _head = node;
    }


    public bool Delete(int value)
    {
        if (_head != null)
        {
            if(_head.Value == value){
                _head = _head.Next;
                return true;
            }
            return _head.Delete(value);
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

}
