using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewOne_CLI
{
    public class RateLimit
    {
        private class RateDS
        {
            public int hit;
            public int spare;
        }

        private long _rateUnixSeconds;
        private Dictionary<int, RateDS> _rates = new Dictionary<int, RateDS>();
        
        private readonly int _maxRate;

        public RateLimit(int maxRate)
        {
            _rateUnixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            _maxRate = maxRate;
        }

        public bool DoProcess(int customer)
        {
            // If the second has moved onto the next second then I can assume old data is unneeded
            long unixSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (unixSeconds > _rateUnixSeconds)
            {
                _rates.Clear(); //todo loop though and set hit to zero and credit spares
                _rateUnixSeconds = unixSeconds; // Reset to new seconds
            }

            //Inc hit for customer, make new if nothing exist
            if (_rates.ContainsKey(customer))
                _rates[customer].hit++;
            else
                _rates.Add(customer, new RateDS(){ hit = 1});


            // Check Rate, return false
            if (_rates[customer].hit > _maxRate)
            {
                // Check for any spare credits
                if (_rates[customer].spare > 0)
                {
                    _rates[customer].spare--;
                    return true;
                }
                return false;
            }


            // Do other stuff if needed
            // ...

            return true;
        }


    }
}
