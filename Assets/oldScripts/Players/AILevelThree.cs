using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixJam.Team4
{
    public class TurnPositionData
    {
        public Position position;
        public AttackDirection attackDirection;
        public int score;
    }

    public class AILevelThree : AiBrain
    {
        // this is an AI which chooses the best scoring unit and returns a random answer

        public override TurnObject MakeDecision(TurnData turnData, Player player)
        {

            var randomIndex = UnityEngine.Random.Range(0, player.MyUnits.Count);
            var randomUnit = player.MyUnits[randomIndex];

            var index = 0;
            var bestUnit = player.MyUnits[index];
            var lowestScore = 36;
            var attackDirection = AttackDirection.colum;
            for (int i = 0; i < player.MyUnits.Count; i++)
            {
                var unit = player.MyUnits[i];
                var unitOptions = turnData._positionOptions[unit];

                if (unitOptions.Count == 0)
                {
                    continue;
                }

                 var unitBestOption = GetBestAttack(unit, unitOptions, turnData.boardData._boardData);  
                
                if (unitBestOption.score < lowestScore)
                {
                    index = i;
                    bestUnit = unit;
                    attackDirection = unitBestOption.attackDirection;
                    lowestScore = unitBestOption.score;
                    bestUnit.Position = unitBestOption.position;
                }
            }

            var turnObject = new TurnObject();
            turnObject.ChosenUnit = bestUnit;
            turnObject.AttackDirection = attackDirection;
           
            return turnObject;
        }

        private TurnPositionData GetBestAttack(Unit unit, List<Position> unitOptions, Unit[,] boardData)
        {
            var answer = new TurnPositionData();

            var maxPoints = 0;
            var index = 0;
            var bestDirection = AttackDirection.colum;
            for (int i = 0; i < unitOptions.Count; i++)
            {
                var rowPoints = GetRowPoints(unitOptions[i], unit, boardData);
                var columnPoints = GetColumnPoints(unitOptions[i], unit, boardData);
                var squarePoints = GetSquarePoints(unitOptions[i], unit, boardData);

                if (rowPoints > maxPoints)
                {
                    index = i;
                    maxPoints = rowPoints;
                    bestDirection = AttackDirection.row;
                }

                if (columnPoints > maxPoints)
                {
                    index = i;
                    maxPoints = columnPoints;
                    bestDirection = AttackDirection.colum;
                }

                if (columnPoints > maxPoints)
                {
                    index = i;
                    maxPoints = columnPoints;
                    bestDirection = AttackDirection.square;
                }
            }

            answer.position = unitOptions[index];
            answer.attackDirection = bestDirection;
            answer.score = maxPoints;

            return answer;
        }

        private int GetSquarePoints(Position unitOption, Unit unit, Unit[,] boardData)
        {
            var ans = 0;
            var square = new Square(unitOption.GetX(), unitOption.GetY());

            for (int i = square.startX; i < square.startX + 3; i++)
            {
                for (int j = square.startY; j < square.startY + 3; j++)
                {
                    var unitToCheck = boardData[i, j];

                    if (unitToCheck == null) //|| player == unitToCheck.Owner)
                    {
                        continue;
                    }

                    var gainedPoints = Mathf.Min(unitToCheck.Value, unit.Value);

                    ans += gainedPoints;
                }
            }

            return ans;
        }

        private int GetColumnPoints(Position unitOption, Unit unit, Unit[,] boardData)
        {
            int ans = 0;
            for (int i = 0; i < 9; i++)
            {
                var x = unitOption.GetX();
                var unitToCheck = boardData[x, i];

                if (unitToCheck == null)//|| player == unitToCheck.Owner)
                {
                    continue;
                }

                var gainedPoints = Mathf.Min(unitToCheck.Value, unit.Value);

                ans += gainedPoints;
            }

            return ans;
        }

        private int GetRowPoints(Position unitOption, Unit unit, Unit[,] boardData)
        {
            int ans = 0;
            for (int i = 0; i < 9; i++)
            {
                var y = unitOption.GetY();
                var unitToCheck = boardData[i, y];

                if (unitToCheck == null)//|| player == unitToCheck.Owner)
                {
                    continue;
                }

                var gainedPoints = Mathf.Min(unitToCheck.Value, unit.Value);

                ans += gainedPoints;
            }

            return ans;
        }
    }
}
