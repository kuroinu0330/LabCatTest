using UnityEngine;
namespace Object.Stage
{
    public class BackGround : MonoBehaviour
    {
        Camera camera;
        float xMiddleWidth;
        SpriteRenderer sprite;
        public BackGround(
            SpriteRenderer sprite,
            Camera camera,
            // 連続している画像の数
            int magnifications
        )
        {
            this.camera = camera;
            this.xMiddleWidth = sprite.bounds.size.x / magnifications;
            this.sprite = sprite;
        }

        // カメラ位置と現在の背景画像位置をもとに、背景画像のX座標を更新する
        public void CheckCameraPositionAndUpdate()
        {
            float xPosition = sprite.transform.position.x;
            DirectionMap direction = CalculateDirectionToReplace(xPosition, xMiddleWidth);
            if (direction == DirectionMap.center)
                return;
            sprite.transform.position = new Vector3(
                CalculateTargetPositionX(xPosition, xMiddleWidth, direction),
                sprite.transform.position.y,
                sprite.transform.position.z
            );
        }

        // 移動先のX座標を計算する
        float CalculateTargetPositionX(float xPosition, float xMiddleWidth, DirectionMap direction)
        {
            return xPosition + ((int)direction * xMiddleWidth);
        }

        // 背景画像を動かす方向を計算する
        DirectionMap CalculateDirectionToReplace(float xPosition, float xMiddleWidth)
        {
            float xCameraPosition = camera.transform.position.x;
            if (xCameraPosition > CalculateTargetPositionX(xPosition, xMiddleWidth, DirectionMap.front))
                return DirectionMap.front;
            if (xCameraPosition < CalculateTargetPositionX(xPosition, xMiddleWidth, DirectionMap.back))
                return DirectionMap.back;
            return DirectionMap.center;
        }
    }
    enum DirectionMap : int
    {
        front = 1,
        back = -1,
        center = 0
    }
}
