using System;

namespace Equation
{
    class Coefficients
    {
        private int[,] _coefMatrix;
        public Coefficients(int maxDelta, int maxH)
        {
            _coefMatrix = new int[maxDelta+1, maxH + maxDelta+1];
        }

        public void Solve()
        {
            for (int delta = _coefMatrix.GetLength(0) - 1; delta > 0; delta--)
                for (int h = _coefMatrix.GetLength(1) - 1; h >= 0; h--)
                    if (_coefMatrix[delta, h] != 0)
                    {
                        _coefMatrix[delta - 1, h] -= _coefMatrix[delta, h];
                        _coefMatrix[delta - 1, h + 1] += _coefMatrix[delta, h];
                        _coefMatrix[delta, h] = 0;
                    }
        }

        public int GetOrder()
        {
            for (int delta = 1; delta < _coefMatrix.GetLength(0); delta++)
                for (int h = 0; h < _coefMatrix.GetLength(1); h++)
                    if (_coefMatrix[delta, h] != 0)
                        throw new Exception("Simplify equation");
            int min = 0;
            int max = _coefMatrix.GetLength(1) - 1;
            while (_coefMatrix[0, min] == 0)
                min++;
            while (_coefMatrix[0, max] == 0)
                max--;
            return max - min;

        }

        public override string ToString()
        {
            string result = "";
            for (int delta = 0; delta < _coefMatrix.GetLength(0); delta++)
                for (int h = 0; h < _coefMatrix.GetLength(1); h++)
                    if (_coefMatrix[delta, h] != 0)
                    {
                        if (_coefMatrix[delta, h] > 0)
                            result += String.Format(" +{0}", _coefMatrix[delta, h].ToString());
                        else
                            result += String.Format(" {0}", _coefMatrix[delta, h].ToString());
                        if (delta > 0)
                            result += String.Format("d{0}", delta);
                        if (h > 0)
                            result += String.Format("u(x+{0}h)", h);
                        else
                            result += "u(x)";
                    }
            result += " = 0\n";
            return result;
        }

        public void Input()
        {
            int coef;
            do
            {
                Console.WriteLine("Enter coef");
                coef = int.Parse(Console.ReadLine());
                if (coef != 0)
                {
                    Console.WriteLine("enter delta");
                    int delta = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter H coef");
                    int h = int.Parse(Console.ReadLine());
                    _coefMatrix[delta, h] = coef;
                }
            } while (coef != 0);
        }
    }
}
