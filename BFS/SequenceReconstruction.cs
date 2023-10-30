public class SolutionSR
{

    private Dictionary<int, List<int>> BuildGraph(int[][] seqs)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        foreach (var seq in seqs)
        {
            for (int i = 0; i < seq.Length; i++)
            {
                if (!graph.ContainsKey(seq[i]))
                {
                    graph[i] = new List<int>();
                }

                if (i < seq.Length - 1)
                    graph[seq[i]].Add(seq[i + 1]);
            }
        }

        return graph;
    }

    private Dictionary<int, int> GetIndegrees(Dictionary<int, List<int>> graph)
    {
        Dictionary<int, int> indegrees = new Dictionary<int, int>();

        foreach (var node in graph.Keys)
        {
            if (!indegrees.ContainsKey(node))
                indegrees[node] = 0;

            foreach (var neighbor in graph[node])
            {
                if (!indegrees.ContainsKey(neighbor))
                    indegrees[neighbor] = 1;
                else
                    indegrees[neighbor]++;
            }
        }

        return indegrees;
    }
    private List<int> GetTopoOrder(Dictionary<int, List<int>> graph)
    {
        Dictionary<int, int> indegrees = GetIndegrees(graph);
        Queue<int> queue = new Queue<int>();
        List<int> topoOrder = new List<int>();

        foreach (var item in graph.Keys)
        {
            if (!indegrees.ContainsKey(item) || indegrees[item] == 0)
                queue.Enqueue(item);
        }

        while (queue.Count > 0)
        {
            if (queue.Count > 1)
                return null;

            int course = queue.Dequeue();
            topoOrder.Add(course);

            if (graph.ContainsKey(course))
            {
                foreach (var neighbor in graph[course])
                {
                    indegrees[neighbor]--;

                    if (indegrees[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
        }

        return topoOrder;
    }
    public bool SequenceReconstruction(int[] origin, int[][] seqs)
    {
        int n = origin.Length;

        Dictionary<int, List<int>> graph = BuildGraph(seqs);
        List<int> topoOrder = GetTopoOrder(graph);

        if (topoOrder == null || topoOrder.Count != n)
            return false;

        for (int i = 0; i < n; i++)
        {
            if (origin[i] != topoOrder[i])
                return false;
        }

        return true;
    }
}