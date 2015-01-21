using System;
using iOS4Unity;
using NUnit.Framework;

public class SKPaymentQueueTests 
{
    [Test]
    public void DefaultQueue()
    {
        var queue = SKPaymentQueue.DefaultQueue;

        Assert.AreNotEqual(IntPtr.Zero, queue.Handle);
    }

    [Test]
    public void DefaultQueueDispose()
    {
        var queue = SKPaymentQueue.DefaultQueue;
        queue.Dispose();
    }

    [Test]
    public void CanMakePayments()
    {
        //Just make sure there isn't a crash
        bool value = SKPaymentQueue.CanMakePayments;
    }

    [Test]
    public void Transactions()
    {
        var transactions = SKPaymentQueue.DefaultQueue.Transactions;
        Assert.AreEqual(0, transactions.Length);
    }

    [Test]
    public void RestoreCompletedTransactions()
    {
        var queue = SKPaymentQueue.DefaultQueue;
        queue.RestoreCompleted += (sender, e) => 
        {
            Console.WriteLine("Restore completed!");
        };
        queue.RestoreFailed += (sender, e) => 
        {
            Console.WriteLine("Restore failed: " + e.Value.LocalizedDescription);
        }; 

        queue.RestoreCompletedTransactions();
    }
}
