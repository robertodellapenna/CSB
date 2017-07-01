using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public abstract class AbstractCoordinator : ICoordinator
    {
        #region Eventi
        public event EventHandler Changed;
        #endregion

        #region Campi
        #endregion

        #region Proprietà
        #endregion

        #region Costruttori
        public AbstractCoordinator()
        {
            init();
        }
        #endregion

        #region Metodi
        protected virtual void init()
        {
            OnChanged(this, EventArgs.Empty);
        }

        public virtual void Reload()
        {
            init();
        }

        public virtual bool ContainsCoordinator(Type type)
        {
            #region Precondizioni
            if (type == null)
                throw new ArgumentNullException("tipo di coordinatore cercato è nullo");
            #endregion

            return GetType() == type 
                || GetType().GetInterfaces().Contains(type);
        }


        public virtual ICoordinator GetCoordinatorOf( Type type )
        {
            /* 
             * O sono del tipo giusto e mi restituisco oppure non ci possono
             * essere altri coordinatori di quel tipo e ritorno null
             */
            return ContainsCoordinator(type) ? this : null;
        }
        #endregion

        #region Handler
        protected virtual void OnChanged(Object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }
        #endregion
    }

    public abstract class AbstractCoordinatorDecorator : AbstractCoordinator, ICoordinatorDecorator
    {
        

        #region Campi
        private readonly ICoordinator _next;
        #endregion

        #region Proprietà
        public ICoordinator NextCoordinator => _next;
        #endregion

        #region Costruttori
        public AbstractCoordinatorDecorator(ICoordinator next)
        {
            #region Precondizioni
            if (next == null)
                throw new ArgumentNullException("coordinatore interno nullo");
            #endregion
            _next = next;
            _next.Changed += NextCoordinatorChangedHandler;
            init();
        }
        #endregion

        #region Metodi

        public override bool ContainsCoordinator(Type type)
        {
            #region Precondizioni
            if (type == null)
                throw new ArgumentNullException("tipo di coordinatore cercato è nullo");
            #endregion

            /* Verifico se io sono di quel tipo, altrimenti delego */
            return GetType() == type || NextCoordinator.ContainsCoordinator(type);
        }

        public override ICoordinator GetCoordinatorOf(Type type)
        {
            if (GetType() == type)
                return this;
            return NextCoordinator.GetCoordinatorOf(type);
        }
        #endregion

        #region Handler
        private void NextCoordinatorChangedHandler(Object sender, EventArgs e)
        {
            OnChanged(sender, e);
        }
        #endregion
    }
}
