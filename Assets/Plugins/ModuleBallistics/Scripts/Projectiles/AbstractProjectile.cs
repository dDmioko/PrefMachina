using UnityEngine;

namespace ModuleBallistics
{
    /// <summary>
    /// Base projectile
    /// </summary>
    public abstract class AbstractProjectile : MonoBehaviour
    {
        private bool isActive = false;

        /// <summary>
        /// Is projectile moving
        /// </summary>
        public bool IsActive
        {
            get
            {
                isActive = gameObject.activeSelf;                

                return isActive;
            }

            set
            {
                isActive = value;
                gameObject.SetActive(value);                
            }
        }

        /// <summary>
        /// Init projectile
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="direction">Direction</param>
        /// <param name="data">Data</param>
        public virtual void Init(ShootData shootData, AbstractProjectileData projectileData)
        {
            InitTransform(shootData);
        }

        /// <summary>
        /// Move projectile while it active    
        /// </summary>
        protected virtual void Move() { }
    }
}
