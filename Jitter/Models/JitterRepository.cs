using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context { get {return _context;}}

        public JitterRepository()
        {
            _context = new JitterContext();
        }

        public JitterRepository(JitterContext a_context)
        {
            _context = a_context;
        }

        public List<JitterUser> GetAllUsers()
        {
            // JitterUsers is a set where the elements are rows
            // items returned from that table are assigned to users
            // by returning users we are returning all of the users
            var query = from users in _context.JitterUsers select users;
            // above is the same as -->  SELECT users.Handles FROM _context.JitterUsers AS users
            return query.ToList();
        }
    }
}