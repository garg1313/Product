namespace Product
{
    internal class Collection3
    {
        public void Swap<t>(ref List<t> l1, int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 > l1.Count || index2 > l1.Count)
            {
                Console.WriteLine("Not vaild swpping");
            }
            else
            {
                t temp = l1[index1];
                l1[index1] = l1[index2];
                l1[index2] = temp;
            }
        }
        /*public static void Main(string[] args)
        {
            Collection3 c = new Collection3();
            List<int> l = new List<int> { 2,3,4,5,6};
            
            c.Swap(ref l, 3, 4);
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }*/
    }
}
