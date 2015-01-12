using System;

class Queen
{
    private int column, row;
    private Queen parent;

    //the constructor of the class queen
    public Queen(int Column, int Row, Queen Parent)
    {
        this.row = Row;
        this.column = Column;
        this.parent = Parent;
    }

    //the properties of the queen class
    public int Row
    {
        get
        {
            return this.row;
        }
    }

    public int Column
    {
        get
        {
            return this.column;
        }
    }

    public Queen Parent
    {
        get
        {
            return this.parent;
        }
    }
}

