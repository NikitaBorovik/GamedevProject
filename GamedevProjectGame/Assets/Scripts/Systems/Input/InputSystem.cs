using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.World.Entity.Player;

namespace App.Systems.Input
{
    public class InputSystem : MonoBehaviour
    {
        
        private Camera mainCamera;
        private Player player;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleAimInput();
            HandleMoveInput();
        }
        public void Init(Camera mainCamera,Player player)
        {
            this.mainCamera = mainCamera;
            this.player = player;
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
            player.Aim.AimWeaponWithMouse(player.WeaponAnchor, aimAngle, playerPosInScreen, cursorPos);
            player.AnimatorController.SetAimAnimationParams(player.PAnimator, playerPosInScreen, cursorPos);
        }
        private void HandleMoveInput()
        {
            float horizontalMove = UnityEngine.Input.GetAxis("Horizontal");
            float verticalMove = UnityEngine.Input.GetAxis("Vertical");

            Vector2 movingDirection = new Vector2(horizontalMove, verticalMove).normalized;


            
            if (movingDirection == Vector2.zero)
            {
                player.AnimatorController.SetIdleAnimationParams(player.PAnimator);
                player.Mover.Move(player.RBody, movingDirection, 0);
            }
            else
            {
                player.Mover.Move(player.RBody, movingDirection, player.MovementSpeed);
                player.AnimatorController.SetMovementAnimationParams(player.PAnimator);
            }
        }
    }
}
