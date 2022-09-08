using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CandiceAIforGames.AI
{
    public enum SelectedBehaviorTree
    {
        AgressiveMelee,
        AgressiveMelee2D,
        AgtressiveRanged,
        Coward,
        Wander,
    }
    public class CandiceBehaviorTreeMono : MonoBehaviour
    {
        [SerializeField]
        private SelectedBehaviorTree selectedBehaviorTree;
        CandiceAIController aiController;
        private CandiceBehaviorNode rootNode;
        private CandiceBehaviorAction ScanForObjectsNode;
        private CandiceBehaviorAction AvoidObstaclesNode;
        private CandiceBehaviorAction CandicePathfindNode;
        private CandiceBehaviorAction canSeeEnemyNode;
        private CandiceBehaviorAction lookAtNode;
        private CandiceBehaviorAction rotateToNode;
        private CandiceBehaviorSelector attackOrChaseSelector;
        private CandiceBehaviorSequence attackSequence;
        private CandiceBehaviorAction withinAttackRange;
        private CandiceBehaviorAction attackNode;


        private CandiceBehaviorSequence wanderSequence;
        private CandiceBehaviorSequence fleeSequence;

        private CandiceBehaviorAction rangeAttackNode;
        private CandiceBehaviorAction moveNode;
        private CandiceBehaviorSequence followSequence;

        private CandiceBehaviorSequence canSeeEnemySequence;
        private CandiceBehaviorSequence patrolSequence;
        private CandiceBehaviorSequence isDeadSequence;

        private CandiceBehaviorAction initNode;

        private CandiceBehaviorAction idleNode;
        private CandiceBehaviorAction isDeadNode;
        private CandiceBehaviorAction dieNode;


        private CandiceBehaviorAction setAttack;
        private CandiceBehaviorAction setMove;

        private CandiceBehaviorAction isPatrollingNode;
        private CandiceBehaviorAction patrolNode;

        CandiceBehaviorSelector enemyDetctedSelector;
        CandiceBehaviorAction fleeNode;
        CandiceBehaviorAction wanderNode;
        CandiceDefaultBehaviors paladinBehaviours;

        public SelectedBehaviorTree SelectedBehaviorTree { get => selectedBehaviorTree; set => selectedBehaviorTree = value; }

        public void Initialise(CandiceAIController aiController)
        {
            this.aiController = aiController;
        }
        // Start is called before the first frame update
        void Start()
        {
            aiController = GetComponent<CandiceAIController>();
            rootNode = new CandiceBehaviorSequence();
            rootNode.Initialise(transform, aiController);

            /*
             * Uncomment to test out the different behaviours.
             * Remember, you can only have one of these functions running at a time.
             * Enjoy, Cheers :-D
             */
            switch(SelectedBehaviorTree)
            {
                case SelectedBehaviorTree.AgressiveMelee:
                        AggressiveAIMelee();
                    break;
                case SelectedBehaviorTree.AgressiveMelee2D:
                    AggressiveAIMelee2D();
                    break;
                case SelectedBehaviorTree.AgtressiveRanged:
                    AggressiveAIRanged();
                    break;
                case SelectedBehaviorTree.Coward:
                    CowardAI();
                    break;
                case SelectedBehaviorTree.Wander:
                    WanderAI();
                    break;
            }
            //AggressiveAIMelee();
            //AggressiveAIRanged();
            //WanderAI();
            //CowardAI();
        }

        // Update is called once per frame
        void Update()
        {
            Evaluate();
        }

        public void Evaluate()
        {
            rootNode.Evaluate();
        }


        private void AggressiveAIMelee()
        {
            ScanForObjectsNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.ScanForObjects, rootNode);
            AvoidObstaclesNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AvoidObstacles, rootNode);
            CandicePathfindNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.CandicePathfind, rootNode);
            canSeeEnemyNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.EnemyDetected, rootNode);
            lookAtNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.LookAt, rootNode);
            rotateToNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.RotateTo, rootNode);
            attackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackMelee, rootNode);
            rangeAttackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackRange, rootNode);
            moveNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.MoveForwardWithSlopeAlignment, rootNode);
            withinAttackRange = new CandiceBehaviorAction(CandiceDefaultBehaviors.WithinAttackRange, rootNode);


            attackSequence = new CandiceBehaviorSequence();
            attackSequence.SetNodes(new List<CandiceBehaviorNode> { withinAttackRange, lookAtNode, attackNode });
            followSequence = new CandiceBehaviorSequence();
            followSequence.SetNodes(new List<CandiceBehaviorNode> { rotateToNode, AvoidObstaclesNode, moveNode });
            attackOrChaseSelector = new CandiceBehaviorSelector();
            attackOrChaseSelector.SetNodes(new List<CandiceBehaviorNode> { attackSequence, followSequence });
            (rootNode as CandiceBehaviorSequence).SetNodes(new List<CandiceBehaviorNode> { ScanForObjectsNode, canSeeEnemyNode, attackOrChaseSelector });
        }
        private void AggressiveAIMelee2D()
        {
            rootNode = new CandiceBehaviorSelector();
            rootNode.Initialise(transform, aiController);
            ScanForObjectsNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.ScanForObjects2D, rootNode);
            AvoidObstaclesNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AvoidObstacles, rootNode);
            CandicePathfindNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.CandicePathfind, rootNode);
            moveNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.MoveTo, rootNode);
            lookAtNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.LookAt, rootNode);
            canSeeEnemyNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.EnemyDetected, rootNode);
            withinAttackRange = new CandiceBehaviorAction(CandiceDefaultBehaviors.WithinAttackRange, rootNode);
            attackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackMelee, rootNode);
            attackSequence = new CandiceBehaviorSequence();
            attackSequence.SetNodes(new List<CandiceBehaviorNode> { canSeeEnemyNode, withinAttackRange, attackNode });

            attackOrChaseSelector = new CandiceBehaviorSelector();
            attackOrChaseSelector.SetNodes(new List<CandiceBehaviorNode> { attackSequence, moveNode });
            canSeeEnemySequence = new CandiceBehaviorSequence();
            canSeeEnemySequence.SetNodes(new List<CandiceBehaviorNode> { canSeeEnemyNode, attackOrChaseSelector });
            patrolNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.Patrol, rootNode);
            patrolSequence = new CandiceBehaviorSequence();
            patrolSequence.SetNodes(new List<CandiceBehaviorNode> {patrolNode, moveNode });



            (rootNode as CandiceBehaviorSelector).SetNodes(new List<CandiceBehaviorNode>{new CandiceBehaviorInverter(ScanForObjectsNode), canSeeEnemySequence, patrolSequence});
        }
        private void AggressiveAIRanged()
        {
            ScanForObjectsNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.ScanForObjects2D, rootNode);
            AvoidObstaclesNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AvoidObstacles, rootNode);
            CandicePathfindNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.CandicePathfind, rootNode);
            canSeeEnemyNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.EnemyDetected, rootNode);
            lookAtNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.LookAt, rootNode);
            rotateToNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.RotateTo, rootNode);
            attackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackRange, rootNode);
            rangeAttackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackRange, rootNode);
            moveNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.MoveForward, rootNode);
            withinAttackRange = new CandiceBehaviorAction(CandiceDefaultBehaviors.WithinAttackRange, rootNode);


            attackSequence = new CandiceBehaviorSequence();
            attackSequence.SetNodes(new List<CandiceBehaviorNode> { withinAttackRange, lookAtNode, rangeAttackNode });
            followSequence = new CandiceBehaviorSequence();
            followSequence.SetNodes(new List<CandiceBehaviorNode> { rotateToNode, AvoidObstaclesNode, moveNode });
            attackOrChaseSelector = new CandiceBehaviorSelector();
            attackOrChaseSelector.SetNodes(new List<CandiceBehaviorNode> { attackSequence, followSequence });
            (rootNode as CandiceBehaviorSequence).SetNodes(new List<CandiceBehaviorNode> { ScanForObjectsNode, canSeeEnemyNode, attackOrChaseSelector });
        }

        private void CowardAI()
        {
            ScanForObjectsNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.ScanForObjects, rootNode);
            AvoidObstaclesNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AvoidObstacles, rootNode);
            CandicePathfindNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.CandicePathfind, rootNode);
            canSeeEnemyNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.EnemyDetected, rootNode);
            lookAtNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.LookAt, rootNode);
            attackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackMelee, rootNode);
            rangeAttackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackRange, rootNode);
            moveNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.MoveForward, rootNode);
            withinAttackRange = new CandiceBehaviorAction(CandiceDefaultBehaviors.WithinAttackRange, rootNode);
            fleeNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.Flee, rootNode);


            fleeSequence = new CandiceBehaviorSequence();
            fleeSequence.SetNodes(new List<CandiceBehaviorNode> {ScanForObjectsNode, canSeeEnemyNode,fleeNode,lookAtNode, moveNode });
            (rootNode as CandiceBehaviorSequence).SetNodes(new List<CandiceBehaviorNode> { fleeSequence });
        }
        private void WanderAI()
        {
            ScanForObjectsNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.ScanForObjects, rootNode);
            AvoidObstaclesNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AvoidObstacles, rootNode);
            CandicePathfindNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.CandicePathfind, rootNode);
            canSeeEnemyNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.EnemyDetected, rootNode);
            lookAtNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.LookAt, rootNode);
            attackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackMelee, rootNode);
            rangeAttackNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.AttackRange, rootNode);
            moveNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.MoveForward, rootNode);
            withinAttackRange = new CandiceBehaviorAction(CandiceDefaultBehaviors.WithinAttackRange, rootNode);
            wanderNode = new CandiceBehaviorAction(CandiceDefaultBehaviors.Wander, rootNode);

            wanderSequence = new CandiceBehaviorSequence();
            wanderSequence.SetNodes(new List<CandiceBehaviorNode> { wanderNode, AvoidObstaclesNode, moveNode });
            (rootNode as CandiceBehaviorSequence).SetNodes(new List<CandiceBehaviorNode> { wanderSequence });
        }

    }
}

