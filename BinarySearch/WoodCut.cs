using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution {
        /**
         * @param l: Given n pieces of wood with length L[i]
         * @param k: An integer
         * @return: The maximum length of the small pieces
         */
        public int WoodCut(int[] l, int k) {
            // write your code here
            if (l == null || l.Length == 0)
                return 0;

            long sum = 0;
            int max = 0;
            for (int i = 0; i < l.Length; i++) {
                sum += l[i];
                max = Math.Max(max, l[i]);
            }

            if (sum < k)
                return 0;

            int left = 1;
            int right = max;
            while (left + 1 < right) {
                int mid = left + (right - left) / 2;
                if (IsValid(l, k, mid))
                    left = mid;
                else
                    right = mid;
            }

            if (IsValid(l, k, right))
                return right;
            
            return left;
        }

        private bool IsValid(int[]l, int k, int len) {
            int count = 0;
            for (int i = 0; i < l.Length; i++) {
                count += l[i] / len;
            }

            if (count >= k)
                return true;
            
            return false;
        }
    }
}