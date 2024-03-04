using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar3
{
    public class CollatzProcessor
    {
        private int _value;//assign only in constructor
        private int _steps;
        private delegate int Operation();//retine pointer la functii
        public delegate void OperationProcessed(bool incresead,int value);
        public event OperationProcessed OnOperationProcessed;

        public delegate void ProcessingStarted(int value);
        public event ProcessingStarted OnProcessingStarted;

        public event Action<int> OnProcessingFinished;//numai pentru void delegate

        public Action<int, string> OnImpossibleScenario;
        public CollatzProcessor(int value)
        {
            _value = value;
        }

        //nu merge ca e readonly 
        private int Increase()
        {

            var result = 3 * _value + 1;
            OnOperationProcessed?.Invoke(true, result);
            return result;
        }
        private int Decrease()
        {
        
            var result = _value / 2;
            OnOperationProcessed?.Invoke(false, result);
            return result;
        }
        public void Process()
        {
            OnProcessingStarted?.Invoke(_value);
            _steps = 0;
            var initial = _value;
            Operation operation;
            while(_value > 1) {
                //_value = _value % 2 == 0 ? Decrease() : Increase();
                if(_value % 2 == 0) {
                    operation = Decrease;
                }
                else
                {
                    operation = Increase;
                }
                _value = operation();
                _steps++;
                if (initial == _value)
                    OnImpossibleScenario?.Invoke(_value,"Impossible");
                    break;
            }
            OnProcessingFinished?.Invoke(_steps);
        }

    }
}
