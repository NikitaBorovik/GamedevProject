using UnityEngine;
using App.World.Entity.Player.PlayerComponents;
using App.World.Shop;
using App.Systems.GameStates;

namespace App.Systems.Input
{
    public class InputSystem : MonoBehaviour
    {
        
        private Camera mainCamera;
        private Player player;
        private Shop shop;
        private bool isPaused;
        private float prepauseTimeScale;
        
        void Update()
        {
            HandlePauseInput();

            if (isPaused) return;

            HandleAimInput();
            HandleMoveInput();
            HandleShootInput();
            HandleBuyInput();
        }
        public void Init(Camera mainCamera,Player player,Shop shop)
        {
            this.mainCamera = mainCamera;
            this.player = player;
            this.shop = shop;
            this.isPaused = false;
            this.prepauseTimeScale = Time.timeScale;
        }

        private void HandlePauseInput()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Escape)) return;
            if(isPaused)
            {
                isPaused = false;
                Time.timeScale = prepauseTimeScale;
            }
            else
            {
                prepauseTimeScale = Time.timeScale;
                isPaused = true;
                Time.timeScale = 0f;
            }
        }

        private Vector3 GetMousePositionInWorld() 
        {
            Vector3 mouseOnScreenPos = UnityEngine.Input.mousePosition;
            mouseOnScreenPos = mainCamera.ScreenToWorldPoint(mouseOnScreenPos);
            mouseOnScreenPos.z = 0f;
            return mouseOnScreenPos;
        }
        private float GetDirectionAngle()
        {
            Vector3 lookDirection;
            if ((GetMousePositionInWorld() - player.WeaponAnchor.position).magnitude < (player.ShootPosition.position - player.WeaponAnchor.position).magnitude*2.2)
            {
                lookDirection = GetMousePositionInWorld() - player.WeaponAnchor.position;
            }
            else
            {
                lookDirection = GetMousePositionInWorld() - player.ShootPosition.position;
            }
                float rads = Mathf.Atan2(lookDirection.y, lookDirection.x);
                float direction = rads * Mathf.Rad2Deg;
            return direction;
        }
        private void HandleAimInput()
        {
            float aimAngle = GetDirectionAngle();
            float cursorPos = UnityEngine.Input.mousePosition.x;
            float playerPosInScreen = mainCamera.WorldToScreenPoint(player.PlayerTransform.position).x;
            player.AimEvent.CallAimEvent(aimAngle,playerPosInScreen,cursorPos);
        }
        private void HandleMoveInput()
        {
            float horizontalMove = UnityEngine.Input.GetAxis("Horizontal");
            float verticalMove = UnityEngine.Input.GetAxis("Vertical");

            Vector2 movingDirection = new Vector2(horizontalMove, verticalMove).normalized;


            
            if (movingDirection == Vector2.zero)
            {
                player.StandEvent.CallStandEvent();
               
            }
            else
            {
                player.MovementEvent.CallMovementEvent(movingDirection,player.MovementSpeed);
            }
        }
        private void HandleShootInput()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                player.Weapon.ShootEvent.CallShootEvent();
            }
        }

        private void HandleBuyInput()
        {
            
            if(UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                
                shop.SellEvent.CallSellEvent();
            }
        }
    }
}
