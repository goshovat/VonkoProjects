using System;
using System.Collections.Generic;

class FieldStep
{
    private int column, row;
    private FieldStep parent;

    public FieldStep(int Row, int Column)
    {
        row = Row;
        column = Column;
        parent = null;
    }

    //define properties Row and Col which will be read only
    public int Row 
    {
        get
        {
            return this.row;
        }
    }

    public int Col
    {
        get
        {
            return this.column;
        }
    }

    //define the property parent that will be read and set
    public FieldStep Parent
    {
        get
        {
            return this.parent;
        }
        set
        {
            this.parent = value;
        }
    }
}

