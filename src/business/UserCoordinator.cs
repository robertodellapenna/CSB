using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;
using System.Collections.ObjectModel;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.business
{
    public interface IUserCoordinator : ICoordinator
    {
        event EventHandler UserContainerChanged;

        ReadOnlyCollection<ILoginUser> RegisteredUsers { get; }
        ReadOnlyCollection<ILoginUser> Filter(AuthorizationLevel authorizationLevel);
        ReadOnlyCollection<ILoginUser> Filter(Func<ILoginUser, bool> rule);
        ReadOnlyCollection<ICustomer> Filter(Func<ICustomer, bool> rule);
        ReadOnlyCollection<ICustomer> Customers { get; }

        /// <summary>
        /// Registra un cliente che dispone di informazioni di login all'interno del sistema
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        void RegisterCustomer<T>(T user) where T : ICustomer, ILoginUser;
        /// <summary>
        /// Registra un utente che dispone di informazioni di login all'interno del sistema
        /// </summary>
        /// <param name="user"></param>
        void RegisterUser(ILoginUser user);
        /// <summary>
        /// Aggiunge un cliente al sistema senza abilitarlo al login.
        /// </summary>
        /// <param name="user">cliente da aggiugnere</param>
        void AddCustomer(ICustomer user);

        bool CheckLoginData(string username, string passwordHash);
    }

    class UserCoordinator : AbstractCoordinatorDecorator, IUserCoordinator
    {
        #region Eventi
        public event EventHandler UserContainerChanged;
        #endregion

        #region Campi
        private readonly ISet<ILoginUser> _registeredUsers
            = new HashSet<ILoginUser>();
        private readonly ISet<ICustomer> _customersUser
            = new HashSet<ICustomer>();
        #endregion

        #region Proprieta
        public ReadOnlyCollection<ILoginUser> RegisteredUsers 
            => new ReadOnlyCollection<ILoginUser>(_registeredUsers.ToList());

        public ReadOnlyCollection<ICustomer> Customers 
            => new ReadOnlyCollection<ICustomer>(_customersUser.ToList());
        #endregion

        #region Costruttori
        public UserCoordinator(ICoordinator next) : base(next) {
        }
        #endregion

        #region Metodi
        protected override void Init()
        {
            base.Init();
            
            Customer client1 = new Customer("lorenzo", "antonini", "CC3", "25/07/95");
            Customer client2 = new Customer("roberto", "antonini", "CC4", "25/07/95");
            Customer client3 = new Customer("giovanni", "baratta", "CC5", "25/07/95");

            string rootHash = "admin".ToSHA512();

            RegisterCustomer(new CustomerLoginUser(client1, "lorenzo.antonini", rootHash, AuthorizationLevel.CUSTOMER));
            RegisterCustomer(new CustomerLoginUser(client3, "giovanni.baratta", rootHash, AuthorizationLevel.CUSTOMER));
            
            AddCustomer(new CustomerLoginUser(client2, "roberto.antonini", rootHash, AuthorizationLevel.CUSTOMER));

            LoginUser staff1 = new LoginUser("giovanni", "Admin", "giovanni.admin", rootHash, AuthorizationLevel.ADVANCED_STAFF);
            LoginUser staff2 = new LoginUser("admin", "admin", "admin.admin", rootHash, AuthorizationLevel.ADVANCED_STAFF);
            LoginUser staff3 = new LoginUser("basicStaff", "admin", "basic", rootHash, AuthorizationLevel.BASIC_STAFF);

            RegisterUser(staff1);
            RegisterUser(staff2);
            RegisterUser(staff3);
        }

        public void RegisterUser(ILoginUser user)
        {
            #region Precondizioni
            if (user == null)
                throw new ArgumentNullException("user null");
            if ((from u in RegisteredUsers where u.Username == user.Username select u).Any())
                throw new InvalidOperationException("esiste già un utente con quel username");
            #endregion
            _registeredUsers.Add(user);
            OnUserContainerChanged(this, EventArgs.Empty);
        }

        public void RegisterCustomer<T>(T user) where T : ILoginUser, ICustomer
        {
            #region Precondizioni
            if (user == null)
                throw new ArgumentNullException("user null");
            if ((from u in RegisteredUsers where u.Username == user.Username select u).Any())
                throw new InvalidOperationException("esiste già un utente con quel username");
            #endregion
            _registeredUsers.Add(user);
            _customersUser.Add(user);
            OnUserContainerChanged(this, EventArgs.Empty);
        }

        public void AddCustomer (ICustomer user)
        {
            #region Precondizioni
            if (user == null)
                throw new ArgumentNullException("user null");
            if ((from u in Customers where u.FiscalCode == user.FiscalCode select u).Any())
                throw new InvalidOperationException("esiste già un cliente con quel codice fiscale");
            #endregion
            _customersUser.Add(user);
            OnUserContainerChanged(this, EventArgs.Empty);
        }

        public ReadOnlyCollection<ILoginUser> Filter(AuthorizationLevel authorizationLevel)
            => Filter( u => authorizationLevel == u.AuthorizationLevel);

        public ReadOnlyCollection<ILoginUser> Filter(Func<ILoginUser, bool> rule)
         => new ReadOnlyCollection<ILoginUser>(
             (from u in _registeredUsers where rule(u) select u).ToList()
            );

        public ReadOnlyCollection<ICustomer> Filter(Func<ICustomer, bool> rule)
         => new ReadOnlyCollection<ICustomer>(
             (from u in _customersUser where rule(u) select u).ToList()
            );

        public bool CheckLoginData(string username, string passwordHash)
         => Filter(u => u.Username == username && u.PasswordHash == passwordHash).Any();
        #endregion

        #region Handler
        private void OnUserContainerChanged(Object sender, EventArgs args)
        {
           UserContainerChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
