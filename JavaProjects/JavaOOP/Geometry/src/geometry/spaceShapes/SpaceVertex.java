package geometry.spaceShapes;

import geometry.Vertex;

public class SpaceVertex extends Vertex {
	public SpaceVertex(double col, double row, double layer) {
		super(3);
		this.setCol(col);
		this.setRow(row);
		this.setDepth(layer);
	}
	
	public double getCol() {
		return super.coordinates[0];
	}	
	public double getRow() {
		return super.coordinates[1];
	}	
	public double getDepth() {
		return super.coordinates[2];
	}
	public void setCol(double value) {
		super.coordinates[0] = value;
	}	
	public void setRow(double value) {
		super.coordinates[1] = value;
	}		
	public void setDepth(double value) {
		super.coordinates[2] = value;
	}
}
