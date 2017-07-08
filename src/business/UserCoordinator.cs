using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;

namespace CSB_Project.src.business
{
    public interface IUserCoordinator : ICoordinator
    {
        void AddClient(User client);
        IEnumerable<User> Clients { get; }
        void AddStaff(User staff);
        IEnumerable<User> Staff { get; }
        IEnumerable<User> FilterClient(string name);
        IEnumerable<User> FilterStaff(string name);
        IEnumerable<User> FilterLevel(int level);
        event EventHandler UserChanged;
    }
    class UserCoordinator : AbstractCoordinatorDecorator, IUserCoordinator
    {
        #region Eventi
        public event EventHandler UserChanged;
        #endregion
        #region Campi
        private readonly List<Client> _clients = new List<Client>();
        private readonly List<Staff> _staff = new List<Staff>();
        #endregion
        #region Proprieta
        public IEnumerable<User> Clients => _clients.ToArray();
        public IEnumerable<User> Staff => _staff.ToArray();
        #endregion
        #region Costruttori
        public UserCoordinator(ICoordinator next) : base(next)
        {
        }
        #endregion
        #region Metodi
        protected override void init()
        {
            base.init();
            Client client1 = new Client(1, "lorenzo", "antonini", "CC3", "25/07/95");
            Client client2 = new Client(2, "roberto", "antonini", "CC4", "25/07/95");
            Client client3 = new Client(3, "giovanni", "antonini", "CC5", "25/07/95");
            _clients.Add(client1);
            _clients.Add(client2);
            _clients.Add(client3);
            Staff staff1 = new Staff(1, "giovanni", "antonini", 1);
            Staff staff2 = new Staff(2, "lorenzo", "antonini", 2);
            _staff.Add(staff1);
            _staff.Add(staff2);
        }

        public void AddClient (User client)
        {
            #region Precondizioni
            if (client == null || !(client is Client))
                throw new ArgumentNullException("client not valid");
            #endregion
            if (!_clients.Contains(client))
                _clients.Add(client as Client);
        }

        public void AddStaff(User staff)
        {
            #region Precondizioni
            if (staff == null || !(staff is Staff))
                throw new ArgumentNullException("staff not valid");
            #endregion
            if (!_staff.Contains(staff))
                _staff.Add(staff as Staff);
        }

        public IEnumerable<User> FilterClient (string name)
        {
            return _clients.Where(client => client.FirstName.Equals(name));
        }

        public IEnumerable<User> FilterStaff(string name)
        {
            return _staff.Where(staff => staff.FirstName.Equals(name));
        }


        public IEnumerable<User> FilterLevel (int level)
        {
            return _staff.Where(staff => staff.AuthorizationLevel == level);
        }

        #endregion
        #region Handler
        private void OnUserChanged(Object sender, EventArgs args)
        {
           UserChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
