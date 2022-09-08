using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CandiceAIforGames.AI
{
    public class CandiceModuleMovement: CandiceBaseModule
    {
        float t = 0;
        public CandiceModuleMovement(string moduleName = "CandiceModuleMovement") : base(moduleName) { }
        public void MoveForward(Transform transform, CandiceAIController aiController)
        {
            transform.position += transform.forward * aiController.MoveSpeed * Time.deltaTime;
        }
        public void MoveForwardWithSlopeAlignment(Transform transform, CandiceAIController aiController)
        {
            var ray = new Ray(transform.position, Vector3.down);
            Vector3 velocity = transform.forward ;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, aiController.HalfHeight + 0.2f))
            {
                var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                velocity = slopeRotation * velocity;
            }
            transform.position += velocity * aiController.MoveSpeed * Time.deltaTime;
        }
        public void MoveTowards2D(Transform transform, CandiceAIController agent)
        {
            transform.position = Vector2.MoveTowards(transform.position, agent.MovePoint, agent.MoveSpeed * Time.deltaTime);
        }
        public void LookAt(Transform transform, CandiceAIController aiController)
        {
            transform.LookAt(aiController.MainTarget.transform);
        }
        public void LookAway(Transform transform, CandiceAIController aiController)
        {
            transform.LookAt(-aiController.MainTarget.transform.forward);
        }

        public void RotateTo(Transform transform, CandiceAIController aiController)
        {
            float desiredAngle = 180;
            int direction = 1;
            float angle = Vector3.Angle((aiController.MainTarget.transform.position - aiController.transform.position), aiController.transform.right);
            if (angle > 90)
                angle = 360 - angle;
            if (angle > desiredAngle)
                direction = -1;
            float rotation = (direction * aiController.RotationSpeed) * Time.deltaTime;
            aiController.transform.Rotate(0, rotation, 0);
        }

        public void Seek(Transform transform, CandiceAIController aiController)
        {
            float distance = Vector3.Distance(transform.position, aiController.MainTarget.transform.position);
            if (distance > aiController._stoppingDist)
            {
                Quaternion targetRotation = Quaternion.LookRotation(aiController.MainTarget.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 12 * Time.deltaTime);
                transform.position += transform.forward * aiController.MoveSpeed * Time.deltaTime;
            }

        }
        public void Orbit(Transform transform, CandiceAIController aiController)
        {
            float newX = Mathf.Cos(t);
            float newZ = Mathf.Sin(t);
            if (aiController.MainTarget != null)
                transform.position = new Vector3(newX, aiController.MainTarget.transform.position.y, newZ);
            else
                transform.position = new Vector3(newX, transform.position.y, newZ);
            t += 0.03f;
        }

        public void Rotate(Transform transform, CandiceAIController aiController)
        {
            transform.Rotate(new Vector3(0, 0, 1), aiController.RotationSpeed);
        }
    }
}

