using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Cube : ICube
    {
        private Random _cubes1;
        private Random _cubes2;
        private List<int> _resalt;
        public Cube()
        {
            _cubes1 = new Random(Guid.NewGuid().GetHashCode());
            _cubes2 = new Random(Guid.NewGuid().GetHashCode());
            _resalt = new List<int>();
        }
        public IEnumerable<int> Dise => _resalt;
        public void Roll()
        {
            int num1 = _cubes1.Next(1, 7);
            int num2 = _cubes2.Next(1, 7);
            _resalt.Add(num1);
            _resalt.Add(num2);
            if (num1 == num2)
            {
                _resalt.Add(num1);
                _resalt.Add(num2);
            }
        }
        public bool IsMoreCube()
        {
            return _resalt.Count != 0;
        }

        public void Remove(int num)
        {
            _resalt.Remove(num);
        }

        public void Clear()
        {
            _resalt.Clear();
        }
    }
}