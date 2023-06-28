using System;
using System.Collections;
using System.Configuration;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Reflection;

namespace Cricri371.Framework.Databases.EntityFramework.Common
{
    /// <summary>
    /// Generic base class for all other classes. 
    /// </summary>
    /// <typeparam name="TContext"> The object context. </typeparam>
    /// <typeparam name="TEntity"> An EntityObject type. </typeparam>
    public abstract class ObjectContextBase<TContext, TEntity>
        where TContext : ObjectContext, new()
        where TEntity : EntityObject
    {
        /// <summary>
        /// Gets or sets the object context manager. 
        /// </summary>
        /// <value> The object context manager. </value>
        private ObjectContextManager<TContext> ObjectContextManager { get; set; }

        /// <summary>
        /// Gets the object context. 
        /// </summary>
        /// <value> The object context. </value>
        protected internal TContext ObjectContext
        {
            get
            {
                if (this.ObjectContextManager == null)
                    this.InstantiateObjectContextManager();

                return this.ObjectContextManager.ObjectContext;
            }
        }

        /// <summary>
        /// Instantiates a new ObjectContextManager based on application configuration settings. 
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">
        /// The managerType attribute is empty. or The managerType specified in the configuration is
        /// not valid. or A ObjectContext tag or its managerType attribute is missing in the configuration.
        /// </exception>
        private void InstantiateObjectContextManager()
        {
            /* Retrieve ObjectContextManager configuration settings */
            Hashtable ocManagerConfiguration = ConfigurationManager.GetSection("ObjectContext") as Hashtable;

            if (ocManagerConfiguration != null && ocManagerConfiguration.ContainsKey("managerType"))
            {
                string managerTypeName = ocManagerConfiguration["managerType"] as string;
                if (string.IsNullOrEmpty(managerTypeName))
                    throw new ConfigurationErrorsException("The managerType attribute is empty.");
                else
                    managerTypeName = managerTypeName.Trim().ToUpperInvariant();

                try
                {
                    /* Try to create a type based on it's name: */
                    Assembly frameworkAssembly = Assembly.GetAssembly(typeof(ObjectContextManager<>));

                    /* We have to fix the name, because its a generic class: */
                    Type managerType = frameworkAssembly.GetType(managerTypeName + "`1", true, true);
                    managerType = managerType.MakeGenericType(typeof(TContext));

                    /* Try to create a new instance of the specified ObjectContextManager type: */
                    this.ObjectContextManager = Activator.CreateInstance(managerType) as ObjectContextManager<TContext>;
                }
                catch (Exception e)
                {
                    throw new ConfigurationErrorsException("The managerType specified in the configuration is not valid.", e);
                }
            }
            else
                throw new ConfigurationErrorsException("A ObjectContext tag or its managerType attribute is missing in the configuration.");
        }

        /// <summary>
        /// Persists all changes to the underlying datastore. 
        /// </summary>
        public void SaveAllObjectChanges()
        {
            this.ObjectContext.SaveChanges();
        }

        /// <summary>
        /// Adds a new entity object to the context. 
        /// </summary>
        /// <param name="newObject"> A new object. </param>
        public virtual void Add(TEntity newObject)
        {
            this.ObjectContext.AddObject(newObject.GetType().Name, newObject);
        }

        /// <summary>
        /// Deletes an entity object. 
        /// </summary>
        /// <param name="obsoleteObject"> An obsolete object. </param>
        public virtual void Delete(TEntity obsoleteObject)
        {
            this.ObjectContext.DeleteObject(obsoleteObject);
        }
    }
}