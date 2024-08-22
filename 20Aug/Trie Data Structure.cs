/*Task 2: Trie for Prefix Checking
Implement a trie data structure in C# that supports insertion of strings and provides a method to check 
if a given string is a prefix of any word in the trie.*/

using System;
using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children;
    public bool IsEndOfWord;

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char ch in word)
        {
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new TrieNode();
            }
            node = node.Children[ch];
        }
        node.IsEndOfWord = true;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = root;
        foreach (char ch in prefix)
        {
            if (!node.Children.ContainsKey(ch))
            {
                return false;
            }
            node = node.Children[ch];
        }
        return true;
    }
}

    class Program1
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("hello");
            trie.Insert("world");

            Console.WriteLine(trie.StartsWith("hell")); // True
            Console.WriteLine(trie.StartsWith("worl")); // True
            Console.WriteLine(trie.StartsWith("hero")); // False
        }
    }
