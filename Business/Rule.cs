using System;
using System.Collections.Generic;
using System.Linq;

namespace Carbon.Business
{
    /// <summary>
    /// A generic class that handles the check of a specific rule
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Rule<T> 
    {
        private readonly List<Predicate<T>> _ruleList = new List<Predicate<T>>();

        public void Add(Predicate<T> rule)
        {
            _ruleList.Add(rule);
        }

        public bool Check(T target) 
        {
            return _ruleList.All(r => r.Invoke(target) == true);
        }
    }
}
