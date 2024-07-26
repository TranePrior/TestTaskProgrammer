public class BulletFactory : AbstractBulletFactory
{
    public BulletFactory(IObjectPool<IBullet> bulletPool) : base(bulletPool)
    {
    }

    public override IBullet GetNewObject()
    {
        var bullet = bulletPool.GetFirstAvailableObject();
        bullet.OnBulletFinishedLifetime += ReturnObjectToPool;
        return bullet;
    }
}
