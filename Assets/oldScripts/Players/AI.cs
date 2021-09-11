using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixJam.Team4
{
    //the name of the class should be your name, it extends abstaract class player
    public class YourName : Player
    {
        public override void YourTurn(TurnData turnData)
        {
            //do your logic here how ever you want
            //fill the data in the turnObject inside turnData
            //player abstract class will validate the turn object is either
            //return the validate filled turnObject is either empty or all required members are set
            //return ValidateTurnObject(turnData.turnObject);
        }
    }

    /*
    public abstract class Player
    {
        
        public virtual TurnObject yourTurn(TurnData turnData) { return null; }

        protected TurnObject validateTurnObject(TurnObject validationObject)
        {
            if (validationObject.ChosenPositionIndex == null)
            {
                return null;
            }

            if (validationObject.ChosenUnit == null)
            {
                return null;
            }

            //TODO: validate that the dictionary leads to a valid position
            return validationObject;
        }
    }

    //this is the turnData class which you receive in yourTurn method
    public class TurnData
    {
        public TurnObject turnObject;
        private BoardData boardData;
        private PositionOptions positionOptions;
    }

    //this is the class youtTurn method needs to return,
    public class TurnObject
    {
        //the unit the player chose
        private Unit _chosenUnit;
        //where the player chose to lay the unit, chosen position is the index of the move
        //out of the possible moves array (see class PositionOptions)
        private int? _chosenPositionIndex;
        //the direction of the attack
        private Direction _direction;

        public int? ChosenPositionIndex { get => _chosenPositionIndex; set => _chosenPositionIndex = value; }
        public Direction Direction { get => _direction; set => _direction = value; }
        public Unit ChosenUnit { get => _chosenUnit; set => _chosenUnit = value; }
    }

    public class PositionOptions
    {
        //a dictionary where the key is a unit, the value is a list with all possible positions 
        //for that unit
    
        private Dictionary<Unit, List<Position>> _unitToPossiblePositions;

        public List<Position> GetPossiblePositions(Unit unit)
        {
            return _unitToPossiblePositions[unit];
        }
    }

    public class Unit
    {
        private Player _owner;
        private int _value;
        private Position position;

        public Unit(Player player, int value)
        {
            _owner = player;
            _value = value;
        }

        public Position Position { get => position; set => position = value; }
    }

    public class BoardData
    {

    }

    public class Position
    {
        private int posX;
        private int posY;

        public void setPosition(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public int getX()
        {
            return posX;
        }

        public int getY()
        {
            return posY;
        }
    }*/

    

}

