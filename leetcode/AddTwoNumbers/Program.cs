// 2. Add Two Numbers
// Medium
// Topics
// Companies
// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each
// of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

// Example 1:


// Input: l1 = [2,4,3], l2 = [5,6,4]
// Output: [7,0,8]
// Explanation: 342 + 465 = 807.
// Example 2:

// Input: l1 = [0], l2 = [0]
// Output: [0]
// Example 3:

// Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
// Output: [8,9,9,9,0,0,0,1]
 

// Constraints:

// The number of nodes in each linked list is in the range [1, 100].
// 0 <= Node.val <= 9
// It is guaranteed that the list represents a number that does not have leading zeros.

Console.WriteLine(Solution(GenerateLinkedList([2,4,3]), GenerateLinkedList([5,6,4])).ToString()); // [7,0,8]
Console.WriteLine(Solution(GenerateLinkedList([0]), GenerateLinkedList([0])).ToString()); // [0]
Console.WriteLine(Solution(GenerateLinkedList([9,9,9,9,9,9,9]), GenerateLinkedList([9,9,9,9])).ToString()); // [8,9,9,9,0,0,0,1]
Console.WriteLine(Solution(GenerateLinkedList([1, 1, 1, 1]), GenerateLinkedList([1, 1])).ToString()); // [2211]

static ListNode Solution(ListNode l1, ListNode l2)
{
    var curentL1 = l1;
    var curentL2 = l2;
    ListNode? previousL3 = null;
    var headNode = new ListNode();
    int carryOver = 0;

    while (curentL1 != null || curentL2 != null || carryOver == 1)
    {
        int sum, l1Val = 0, l2Val = 0;

        if (curentL1 != null)
        {
            l1Val = curentL1.val;
            curentL1 = curentL1.next;
        }
        if (curentL2 != null)
        {
            l2Val = curentL2.val;
            curentL2 = curentL2.next;
        }
        sum = l1Val + l2Val + carryOver;
        if (sum >= 10)
        {
            carryOver = 1;
            sum %= 10;
        }
        else
            carryOver = 0;

        ListNode currentL3 = new()
        {
            val = sum,
            next = null
        };
        if (previousL3 == null)
            headNode = currentL3;
        else
            previousL3.next = currentL3;

        previousL3 = currentL3;
    }

    return headNode;
}

static ListNode SolutionAi(ListNode l1, ListNode l2) 
{
    // Create a dummy head node to simplify the logic
    ListNode dummyHead = new ListNode(0);
    ListNode current = dummyHead;
    int carry = 0;
    
    // Continue looping while there are digits to process in either list
    // or there's a remaining carry value
    while (l1 != null || l2 != null || carry > 0)
    {
        // Extract values (if nodes exist) or use 0
        int x = (l1 != null) ? l1.val : 0;
        int y = (l2 != null) ? l2.val : 0;
        
        // Calculate sum including any carry from previous addition
        int sum = x + y + carry;
        
        // Update carry for next calculation
        carry = sum / 10;
        
        // Create new node with ones digit of sum
        current.next = new ListNode(sum % 10);
        current = current.next;
        
        // Move to next nodes in lists if available
        if (l1 != null) l1 = l1.next;
        if (l2 != null) l2 = l2.next;
    }
    
    // Return result (skip dummy head)
    return dummyHead.next;
}

static ListNode GenerateLinkedList(int[] vals)
{
    ListNode currentNode = new();
    ListNode? previousNode = null;

    for (int i = vals.Length - 1; i >= 0; i--)
    {
        currentNode = new()
        {
            val = vals[i],
            next = previousNode
        };
        previousNode = currentNode;
    }

    return currentNode;
}

 //Definition for singly-linked list.
class ListNode {
     public int val;
     public ListNode? next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }

     public string ToString()
     {
        var output = string.Empty;
        var current = this;
        while (current != null)
        {
            output += current.val;
            current = current.next;
        }

        return output;
     }
 }
 