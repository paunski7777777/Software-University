using System.Collections;
using System.Collections.Generic;
public class Lake : IEnumerable<int>
{
    public IList<int> Stones { get; set; }
    public Lake(IList<int> stones)
    {
        this.Stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.Stones.Count; i += 2)
        {
            yield return this.Stones[i];
        }

        int lastOddIndex = this.Stones.Count % 2 == 0 ? this.Stones.Count - 1 : this.Stones.Count - 2;

        for (int i = lastOddIndex; i > 0; i -= 2)
        {
            yield return this.Stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

