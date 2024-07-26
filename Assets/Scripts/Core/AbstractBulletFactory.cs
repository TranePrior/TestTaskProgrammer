using System;

public abstract class AbstractBulletFactory : IPooledFactory<IBullet>
{
    public IObjectPool<IBullet> bulletPool;

    public Action OnObjectLifetimeFinished { get; set; }

    protected AbstractBulletFactory(IObjectPool<IBullet> bulletPool)
    {
        this.bulletPool = bulletPool;
    }

    public abstract IBullet GetNewObject();
    public void DisableAllObjects()
    {
        bulletPool.DisableAllObjects();
    }

    protected void ReturnObjectToPool(IBullet bullet)
    {
        bullet.OnBulletFinishedLifetime -= ReturnObjectToPool;
        bulletPool.ReturnObjectToPool(bullet);
    }
}
