//133. Clone Graph
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;
        
        var nodes = FindNodesByBFS(node);
        Dictionary<Node, Node> cloneMap = CopyNodes(nodes);
        CopyEdges(nodes, cloneMap);
        return cloneMap[node];
    }

    private IList<Node> FindNodesByBFS(Node node)
    {
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        HashSet<Node> visitedNodes = new HashSet<Node>();
        visitedNodes.Add(node);
        while(queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();            
            foreach (var neighbor in currentNode.neighbors)
            {
                if (!visitedNodes.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visitedNodes.Add(neighbor);
                }
            }
        }

        return new List<Node>(visitedNodes);
    }

    private void CopyEdges(IList<Node> nodes, Dictionary<Node, Node> cloneMap)
    {
        foreach(var node in nodes)
        {
            foreach (var neighbor in node.neighbors)
            {
                var newNeighbor = cloneMap[neighbor];
                cloneMap[node].neighbors.Add(newNeighbor);
            }
        }
    }

    private Dictionary<Node, Node> CopyNodes(IList<Node> nodes)
    {
        Dictionary<Node, Node> cloneMap = new Dictionary<Node, Node>();

        foreach(var node in nodes)
        {
            cloneMap[node] = new Node(node.val);
        }
        return cloneMap;
    }
}