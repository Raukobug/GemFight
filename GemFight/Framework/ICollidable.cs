using Microsoft.Xna.Framework;

namespace GemFight.Framework
{
    public interface ICollidable
    {
        void CollideWith(Sprite other);

        Rectangle BoundingBox { get; }
    }
}
