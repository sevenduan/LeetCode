public class SolutionFindOrder {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }

        int[] inDegree = new int [numCourses];

        foreach (var item in prerequisites)
        {
            graph[item[1]].Add(item[0]);
            inDegree[item[0]]++;
        }

        //en queue
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        int numChoose = 0;
        int[] topoOrder = new int[numCourses];
        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            topoOrder[numChoose] = course;
            numChoose++;

            foreach (var nextCourse in graph[course])
            {
                inDegree[nextCourse]--;

                if (inDegree[nextCourse] == 0)
                    queue.Enqueue(nextCourse);
            }
        }

        if (numChoose == numCourses)
            return topoOrder;
        
        return new int[0];
    }
}