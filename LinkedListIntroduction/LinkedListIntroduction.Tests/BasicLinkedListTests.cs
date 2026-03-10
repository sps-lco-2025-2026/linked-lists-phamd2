using LinkedListIntroduction.Lib;


namespace LinkedListIntroduction.Tests;


[TestClass]
public sealed class BasicLinkedListTests
{


    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }


    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }


    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }


    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        ill.Prepend(3);
        Assert.AreEqual("{3, 5, 7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestDeleteWhenPresent()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsTrue(ill.Delete(7));
        Assert.AreEqual("{5, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestDeleteHead()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsTrue(ill.Delete(5));
        Assert.AreEqual("{7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestDeleteWhenNotPresent()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsFalse(ill.Delete(6));
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestInserts()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsTrue(ill.Insert(8, 0));
        Assert.AreEqual("{8, 5, 7, 9}", ill.ToString());
        Assert.IsTrue(ill.Insert(8, 3));
        Assert.AreEqual("{8, 5, 7, 8, 9}", ill.ToString());
        Assert.IsFalse(ill.Insert(8, 94));
    }


    [TestMethod]
    public void TestListInitialisation()
    {
        var ill = new IntegerLinkedList([5,7,9]);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestJoin()
    {
        var ill = new IntegerLinkedList([5,7,9]);
        var ill2 = new IntegerLinkedList([11,13,17]);
        ill.Join(ill2);
        Assert.AreEqual("{5, 7, 9, 11, 13, 17}", ill.ToString());
    }


    [TestMethod]
    public void TestReverse()
    {
        var ill = new IntegerLinkedList([5,7,9]);
        var ill2 = ill.Reverse();
        Assert.AreEqual("{9, 7, 5}", ill2.ToString());
    }
   
    [TestMethod]
    public void TestContainsWhenPresent()
    {
        var ill = new IntegerLinkedList([5,7,9]);
        Assert.IsTrue(ill.Contains(7));
    }


    [TestMethod]
    public void TestContainsWhenNotPresent()
    {
        var ill = new IntegerLinkedList([5,7,9]);
        Assert.IsFalse(ill.Contains(10));
    }


    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var ill = new IntegerLinkedList([5,7,7,9,9,9]);
        ill.RemoveDuplicates();
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }


    [TestMethod]
    public void TestMergeAlternate()
    {
        var ill1 = new IntegerLinkedList([1,3,5]);
        var ill2 = new IntegerLinkedList([2,4,6]);


        ill1.MergeAlternate(ill2);


        Assert.AreEqual("{1, 2, 3, 4, 5, 6}", ill1.ToString());
    }
}
